using System.IO.Compression;

using CNUCoin.BLL.Interfaces;

using CNUCoin.DAL.Common.Dtos;
using CNUCoinWeb.Models;
using Microsoft.AspNetCore.Mvc;

using SystemFile = System.IO.File;

namespace CNUCoinWeb.Controllers
{
	/// <summary>
	/// Controller for handking all auth action.
	/// </summary>
	public class AuthController : Controller
	{
		#region Private fileds

		/// <summary>
		/// Member service.
		/// </summary>
		private readonly IMemberService _memberService;

		#endregion

		#region Constructor

		/// <summary>
		/// Inizialise instance of <see cref="AuthController"/>.
		/// </summary>
		/// <param name="memberService">Member service.</param>
		public AuthController(IMemberService memberService)
		{
			_memberService = memberService;
		}

		#endregion

		#region Actions

		/// <summary>
		/// Login action.
		/// </summary>
		/// <returns>Login view.</returns>
		public IActionResult Login()
		{
			return View(new LoginModel());
		}

		/// <summary>
		/// Login action.
		/// </summary>
		/// <param name="model">Login model.</param>
		/// <returns>If login successfully main page, and login view if not.</returns>
		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			var publicKey = string.Empty;

			using (var reader = new StreamReader(model.PublicKeyFile!.OpenReadStream()))
			{
				publicKey = (await reader.ReadToEndAsync()).Replace("\n", "").Replace("\r", "");
			}

			if (await _memberService.LoginAsync(new()
			{
				PublicKey = publicKey,
				Password = model.Password
			}))
			{
				return Redirect("/Home/Index");
			}

			return RedirectToAction("Login");
		}

		/// <summary>
		/// Register action.
		/// </summary>
		/// <returns>Register view.</returns>
		public IActionResult Register()
		{
			return View(new RegisterDto());
		}

		/// <summary>
		/// Register action. Process.
		/// </summary>
		/// <param name="dto">Register dto.</param>
		/// <returns>If register successfully keys archive, and register view if not.</returns>
		[HttpPost]
		public async Task<IActionResult> Register(RegisterDto dto)
		{
			(var memberId, var publicKey, var privateKey) = await _memberService.RegisterAsync(dto);

			if (!string.IsNullOrEmpty(memberId))
			{
				var zipPath = $"{Directory.GetCurrentDirectory()}/{memberId}";
				var zipFilePath = Path.Combine(zipPath, "keys.zip");

				if (!Directory.Exists(zipPath))
				{
					Directory.CreateDirectory(zipPath);
				}

				using (var zipStream = new FileStream(zipFilePath, FileMode.Create))
				{
					using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
					{
						var publicKeyFile = archive.CreateEntry("public.pub");

						using (var writer = new StreamWriter(publicKeyFile.Open()))
						{
							writer.WriteLine(publicKey);
						}

						var privateKeyFile = archive.CreateEntry("private.pem");

						using (var writer = new StreamWriter(privateKeyFile.Open()))
						{
							writer.WriteLine(privateKey);
						}
					}
				}

				var fileBytes = SystemFile.ReadAllBytes(zipFilePath);

				SystemFile.Delete(zipFilePath);
				Directory.Delete(zipPath);

				return File(fileBytes, "application/zip", "keys.zip");

			}

			return RedirectToAction("Register");
		}

		#endregion
	}
}
