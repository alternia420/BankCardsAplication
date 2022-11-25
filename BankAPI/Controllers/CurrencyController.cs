using BankAPI.DbFactory;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;

		public CurrencyController(IBanksCardsDataBaseFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		[HttpGet("getAllCurrencies")]

		public IEnumerable<Currency> Get()
		{
			var db = _dbFactory.CreateCurrencyRepo();
			return db.GetTable();
		}

		[HttpGet("getCurrency")]
		public Currency GetType([FromQuery] int id)
		{
			var db = _dbFactory.CreateCurrencyRepo();
			return db.GetTable(x => x.Id == id).FirstOrDefault();
		}

		[HttpPost("createCurrency")]
		public void Create(Currency type)
		{
			var db = _dbFactory.CreateCurrencyRepo();
			db.Insert(type);
		}

		[HttpPost("updateCurrency")]
		public void Update(Currency type)
		{
			var db = _dbFactory.CreateCurrencyRepo();
			db.Update(type);
		}

		[HttpDelete("deleteCurrency")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreateCurrencyRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
