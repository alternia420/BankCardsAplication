using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Models.Request
{

	public class CreateCardRequest
	{
		public int ClientId { get; set; }
		public int PaymentSystemType { get; set; }
		public int CurrencyId { get; set; }
		public int CardType { get; set; }

	}
}
