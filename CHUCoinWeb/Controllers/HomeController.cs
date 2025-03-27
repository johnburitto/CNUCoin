using System.Security.Claims;

using CNUCoinWeb.Models;

using CNUCoin.BLL.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CNUCoinWeb.Controllers
{
	/// <summary>
	/// Controller for handling all main action.
	/// </summary>
	[Authorize]
	public class HomeController : Controller
	{
		#region Private fields

		/// <summary>
		/// Member service.
		/// </summary>
		private readonly IMemberService _memberService;

		/// <summary>
		/// Transaction service.
		/// </summary>
		private readonly ITransactionService _transactionService;

		#endregion

		#region Constructor

		/// <summary>
		/// Inizialise instance of <see cref="HomeController"/>.
		/// </summary>
		/// <param name="memberService">Member service.</param>
		public HomeController(IMemberService memberService, ITransactionService transactionService)
		{
			_memberService = memberService;
			_transactionService = transactionService;
		}

		#endregion

		#region Actions

		/// <summary>
		/// Home action.
		/// </summary>
		/// <returns>Home page.</returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Transfer action.
		/// </summary>
		/// <returns>Transfer page.</returns>
		public async Task<IActionResult> Transfer()
		{
			var model = new TransferModel();
			
			model.Sender = await _memberService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
			model.Members = await _memberService.GetAllAsync(model.Sender?.MemberId);

			return View(model);
		}

		/// <summary>
		/// Transfer action. Process.
		/// </summary>
		/// <param name="model">Model.</param>
		/// <returns>Transfer page.</returns>
		[HttpPost]
		public async Task<IActionResult> Transfer(TransferModel model)
		{
			var privateKey = string.Empty;

			using (var reader = new StreamReader(model.PrivateKeyFile!.OpenReadStream()))
			{
				privateKey = (await reader.ReadToEndAsync()).Replace("\n", "").Replace("\r", "");
			}

			 model.Sender = await _memberService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

			await _transactionService.CreateTransactionAsync(new()
			{
				SenderId = model.Sender?.MemberId,
				ReceiverId = model.ReceiverId,
				Amount = model.Amount,
				PrivateKey = privateKey
			});

			return RedirectToAction("Transfer");
		}

		/// <summary>
		/// Mine action.
		/// </summary>
		/// <returns>Mine page.</returns>
		public IActionResult Mine()
		{
			return View(new MineModel());
		}

		/// <summary>
		/// Mine action. Process.
		/// </summary>
		/// <param name="model">Model.</param>
		/// <returns>Mine page.</returns>
		[HttpPost]
		public async Task<IActionResult> Mine(MineModel model)
		{
			var minerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var privateKey = string.Empty;

			using (var reader = new StreamReader(model.PrivateKeyFile!.OpenReadStream()))
			{
				privateKey = (await reader.ReadToEndAsync()).Replace("\n", "").Replace("\r", "");
			}

			await _memberService.MineAsync(minerId, privateKey);

			return RedirectToAction("Mine");
		}

		#endregion
	}
}
