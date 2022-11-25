using BankAPI.Models.Enums;
using BankAPI.Validation.Errors;

namespace BankAPI.Models.Response
{
	public class TransactionResponse
	{
		public CardErrors Error { get; set; }
		public TransansationStatuses Status { get; set; }
	}
}
