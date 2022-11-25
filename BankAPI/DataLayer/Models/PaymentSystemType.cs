using LinqToDB.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace BankAPI.Models
{
	[ExcludeFromCodeCoverage]
	[Table(Name = "payment_system_types", Schema = "dbo")]
	public class PaymentSystemType
	{
		[Column(Name = "id", CanBeNull = false, IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		[Column(Name = "payment_system_type", CanBeNull = false)]
		public string Type { get; set; }

	}
}
