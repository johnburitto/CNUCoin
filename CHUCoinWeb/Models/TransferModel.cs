using CNUCoin.DAL.Common.Entities;

namespace CNUCoinWeb.Models
{
	/// <summary>
	/// Transfer model.
	/// </summary>
	public class TransferModel
	{
		/// <summary>
		/// Sender.
		/// </summary>
		public Member? Sender { get; set; }

		/// <summary>
		/// Members.
		/// </summary>
		public List<Member>? Members { get; set; }

		/// <summary>
		/// Memeber id transfer to.
		/// </summary>
		public string? ReceiverId { get; set; }

		/// <summary>
		/// Amount of coins to transfer.
		/// </summary>
		public float Amount { get; set; }

		/// <summary>
		/// Sender private key.
		/// </summary>
		public IFormFile? PrivateKeyFile { get; set; }
	}
}
