using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Config
{
	public interface IConnectionConfig
	{
		string ConnectionString { get; set; }
	}
}
