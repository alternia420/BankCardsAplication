
namespace BankAPI.Config
{
	public class ConnectionConfig : IConnectionConfig
	{
		public ConnectionConfig(IConfiguration configuration)
		{
			configuration.GetSection("ConnectionStrings").Bind(this);
		}

		public string ConnectionString { get; set; }
	}
}
