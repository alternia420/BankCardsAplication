using LinqToDB.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace BankAPI.Models
{
	[ExcludeFromCodeCoverage]
	[Table(Name = "clients", Schema = "dbo")]
	public class Client
	{
		[Column(Name = "id", CanBeNull = false, IsPrimaryKey = true, IsIdentity = true)]
		public int Id { get; set; }

		[Column(Name = "name", CanBeNull = false)]
		public string Name { get; set; }

		[Column(Name = "last_name", CanBeNull = false)]
		public string LastName { get; set; }

		[Column(Name = "dob", CanBeNull = false)]
		public DateTime DoB { get; set; }

		[Column(Name = "phone_number", CanBeNull = false)]
		public string PhoneNumber { get; set; }

		[Column(Name = "email", CanBeNull = false)]
		public string Email { get; set; }
	}
}
