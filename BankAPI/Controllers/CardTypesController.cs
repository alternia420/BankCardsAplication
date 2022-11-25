using BankAPI.DbFactory;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace BankAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardTypesController : ControllerBase
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;

		public CardTypesController(IBanksCardsDataBaseFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		[HttpGet("getAllCardTypes")]

		public IEnumerable<CardType> Get()
		{
			var db = _dbFactory.CreateCardTypeRepo();
			return db.GetTable();
		}

		[HttpGet("getCardType")]
		public CardType GetType([FromQuery] int id)
		{
			var db = _dbFactory.CreateCardTypeRepo();
			return db.GetTable(x => x.Id == id).FirstOrDefault();
		}

		[HttpPost("createCardType")]
		public void Create(CardType type)
		{
			var db = _dbFactory.CreateCardTypeRepo();
			db.Insert(type);
		}

		[HttpPost("updateCardType")]
		public void Update(CardType type)
		{
			var db = _dbFactory.CreateCardTypeRepo();
			db.Update(type);
		}

		[HttpDelete("deleteCardType")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreateCardTypeRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
