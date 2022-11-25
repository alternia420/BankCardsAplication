using LinqToDB.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace BankAPI.Models
{
	[ExcludeFromCodeCoverage]
	[Table(Name = "card_types", Schema = "dbo")]
	public class CardType
	{
		[Column(Name = "id", CanBeNull = false, IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		[Column(Name = "card_type", CanBeNull = false)]
		public string Type { get; set; }

	}
}
