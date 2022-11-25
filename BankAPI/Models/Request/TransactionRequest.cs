namespace BankAPI.Models.Request
{
	public class TransactionRequest
	{
		public string SenderCardNumber { get; set; }
		public string RecieverCardNumber { get; set; }
		public decimal Amount { get; set; }
	}
}
