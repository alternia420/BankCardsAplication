namespace BankAPI.Models.Request
{
	public class UpdateCardRequest
	{
		public int ClientId { get; set; }
		public string CardNumber { get; set; }
		public DateTime ExpDate { get; set; }
		public string CVV { get; set; }
		public int CurrencyId { get; set; }
		public int TypeId { get; set; }
		public int PaymentSystemId { get; set; }
		public int StatusId { get; set; }
		public decimal Balance { get; set; }
	}
}
