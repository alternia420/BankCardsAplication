using BankAPI.DbFactory;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardStatusesController : ControllerBase
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;

		public CardStatusesController(IBanksCardsDataBaseFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		[HttpGet("getAllStatuses")]

		public IEnumerable<CardStatus> Get()
		{
			var db = _dbFactory.CreateCardStatusRepo();
			return db.GetTable();
		}

		[HttpGet("getStatus")]
		public CardStatus GetType([FromQuery] int id)
		{
			var db = _dbFactory.CreateCardStatusRepo();
			return db.GetTable(x => x.Id == id).FirstOrDefault();
		}

		[HttpPost("createStatus")]
		public void Create(CardStatus type)
		{
			var db = _dbFactory.CreateCardStatusRepo();
			db.Insert(type);
		}

		[HttpPost("updateStatus")]
		public void Update(CardStatus type)
		{
			var db = _dbFactory.CreateCardStatusRepo();
			db.Update(type);
		}

		[HttpDelete("deleteStatus")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreateCardStatusRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
