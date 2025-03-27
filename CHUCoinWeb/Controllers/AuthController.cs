using System.IO.Compression;
using System.Security.Claims;

using CNUCoin.BLL.Interfaces;

using CNUCoinWeb.Models;
using CNUCoin.DAL.Common.Dtos;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using SystemFile = System.IO.File;

namespace CNUCoinWeb.Controllers
{
	/// <summary>
	/// Controller for handling all auth action.
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
		/// Login action. Process.
		/// </summary>
		/// <param name="model">Login model.</param>
		/// <returns>If login successfully home page, and login view if not.</returns>
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
				var member = await _memberService.GetByPublicKeyAsync(publicKey);
				var claims = new List<Claim>()
				{
					new(ClaimTypes.NameIdentifier, member!.MemberId ?? ""),
					new(ClaimTypes.Role, member.IsMiner ? "Miner" : "User"),
				};
				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

				return Redirect("/Home/Index");
			}

			return RedirectToAction("Login");
		}

		/// <summary>
		/// Logout action.
		/// </summary>
		/// <returns>Home page.</returns>
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();

			return Redirect("/Home/Index");
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
				var zipPath = $"{memberId[7..]}";
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
