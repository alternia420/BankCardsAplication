using BankAPI.DbFactory;
using BankAPI.DataLayer;
using BankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
	[Route("api/clients")]
	[ApiController]
	public class ClientsController : ControllerBase
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;

		public ClientsController(IBanksCardsDataBaseFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		[HttpGet("getAllClients")]

		public IEnumerable<Client> Get()
		{
			var db = _dbFactory.CreateClientRepo();
			return db.GetTable();
		}

		[HttpGet("getClient")]
		public Client GetClient([FromQuery] int id)
		{
			var db = _dbFactory.CreateClientRepo();
			return db.GetTable(x => x.Id == id).FirstOrDefault();
		}

		[HttpPost("createClient")]
		public void Create(Client client)
		{
			var db = _dbFactory.CreateClientRepo();
			db.Insert(client);
		}

		[HttpPost("updateClient")]
		public void Update(Client client)
		{
			var db = _dbFactory.CreateClientRepo();
			db.Update(client);
		}

		[HttpDelete("deleteClient")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreateClientRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
