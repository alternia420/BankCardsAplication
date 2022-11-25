using LinqToDB.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace BankAPI.Models
{
	[ExcludeFromCodeCoverage]
	[Table(Name = "card_statuses", Schema = "dbo")]
	public class CardStatus
	{
		[Column(Name = "id", CanBeNull = false, IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		[Column(Name = "status")]
		public string Status { get; set; }


	}
}
