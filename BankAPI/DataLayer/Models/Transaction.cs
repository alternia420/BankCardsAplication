using LinqToDB.Mapping;
using System.Diagnostics.CodeAnalysis;
namespace BankAPI.DataLayer.Models
{
	[ExcludeFromCodeCoverage]
	[Table(Name = "transactions", Schema = "dbo")]
	public class Transaction
	{
		[Column(Name = "id", CanBeNull = false, IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		[Column(Name = "sender_card", CanBeNull = false)]
		public string SenderCard { get; set; }

		[Column(Name = "reciever_card", CanBeNull = false)]
		public string RecieverCard { get; set; }

		[Column(Name = "timestamp", CanBeNull = false)]
		public DateTime Timestamp { get; set; }

		[Column(Name = "amount", CanBeNull = false)]
		public decimal Amount { get; set; }

		[Column(Name = "status", CanBeNull = false)]
		public int Status { get; set; }
		[Column(Name = "sender_id", CanBeNull = false)]
		public int SenderId { get; set; }
		[Column(Name = "reciever_id", CanBeNull = true)]
		public int? RecieverId { get; set; }
	}
}
