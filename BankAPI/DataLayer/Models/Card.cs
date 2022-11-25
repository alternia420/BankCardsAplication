using LinqToDB.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace BankAPI.Models
{
	[ExcludeFromCodeCoverage]
	[Table(Name = "cards", Schema = "dbo")]
	public class Card
	{
		[Column(Name = "id", CanBeNull = false, IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		[Column(Name = "client_id", CanBeNull = false)]
		public int ClientId { get; set; }
		[Column(Name = "card_number", CanBeNull = false)]
		public string CardNumber { get; set; }

		[Column(Name = "exp_date", CanBeNull = false)]
		public DateTime ExpDate { get; set; }

		[Column(Name = "cvv", CanBeNull = false)]
		public string CVV { get; set; }

		[Column(Name = "currency", CanBeNull = false)]
		public int CurrencyId { get; set; }
		[Column(Name = "type", CanBeNull = false)]
		public int TypeId { get; set; }

		[Column(Name = "payment_system", CanBeNull = false)]
		public int PaymentSystemId { get; set; }
		[Column(Name = "status", CanBeNull = false)]
		public int StatusId { get; set; }

		[Column(Name = "balance", CanBeNull = false)]
		public decimal Balance { get; set; }


	}
}
