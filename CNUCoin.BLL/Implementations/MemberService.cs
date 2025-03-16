using CNUCoin.BLL.Interfaces;
using CNUCoin.BLL.Crypto.Interfaces;

using CNUCoin.DAL.Data;
using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace CNUCoin.BLL.Implementations
{
	/// <summary>
	/// Realisation of <see cref="IMemberService"/>.
	/// </summary>
	public class MemberService : IMemberService
	{
		#region Private fields

		/// <summary>
		/// App db context.
		/// </summary>
		private readonly AppDbContext _context;

		/// <summary>
		/// Crypto service.
		/// </summary>
		private readonly ICryptoService _cryptoService;

		#endregion

		#region Constructor

		/// <summary>
		/// Inizialise instance of <see cref="MemberService"/>.
		/// </summary>
		/// <param name="context">App db context.</param>
		/// <param name="cryptoService">Crypto service.</param>
		public MemberService(AppDbContext context, ICryptoService cryptoService)
		{
			_context = context;
			_cryptoService = cryptoService;
		}

		#endregion

		#region Realisation of IMemberService

		/// <inheritdoc/>
		public Task<bool> LoginAsync(LoginDto dto)
		{
			return _context.Members
				.Where(m => m.PublicKey == dto.PublicKey && m.Password == _cryptoService.Sha256Hash(dto.Password))
				.AnyAsync();
		}

		/// <inheritdoc/>
		public async Task<(string, string, string)> RegisterAsync(RegisterDto dto)
		{
			var member = new Member();
			(var publicKey, var privateKey) = _cryptoService.GenerateRsaKeys();

			member.MemberId = _cryptoService.Sha256Hash(publicKey);
			member.PublicKey = publicKey;
			member.Username = dto.Username;
			member.Password = _cryptoService.Sha256Hash(dto.Password);
			member.IsMiner = dto.IsMiner;

			await _context.Members.AddAsync(member);
			await _context.SaveChangesAsync();

			return (member.MemberId, publicKey, privateKey);
		}

		#endregion
	}
}
