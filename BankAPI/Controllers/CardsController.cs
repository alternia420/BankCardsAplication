using BankAPI.Adaptes;
using BankAPI.BussinessLogic;
using BankAPI.DbFactory;
using BankAPI.Models;
using BankAPI.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardsController : ControllerBase
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;
		private readonly ICardGenerator _cardGenerator;
		private readonly IRequestToDataBaseAdapter _adapter;

		public CardsController(IBanksCardsDataBaseFactory dbFactory,
			ICardGenerator cardGenerator,
			IRequestToDataBaseAdapter adapter)
		{
			_dbFactory = dbFactory;
			_cardGenerator = cardGenerator;
			_adapter = adapter;
		}

		[HttpGet("getAllCards")]

		public IEnumerable<Card> Get()
		{
			var db = _dbFactory.CreateCardRepo();
			return db.GetTable();
		}

		[HttpGet("getCard")]
		public Card GetCard([FromQuery] int id)
		{
			var db = _dbFactory.CreateCardRepo();
			return db.GetTable(x => x.Id == id).FirstOrDefault();
		}

		[HttpPost("createCard")]
		public void Create(CreateCardRequest req)
		{
			var card = _cardGenerator.GenerateCard(req);
			var db = _dbFactory.CreateCardRepo();
			db.Insert(card);
		}

		[HttpPost("updateCard")]
		public void Update([FromQuery] int id, UpdateCardRequest req)
		{
			var card = _adapter.Adapt(req, id);
			var db = _dbFactory.CreateCardRepo();
			db.Update(card);
		}

		[HttpPost("topUpCard")]
		public void TopUpCard([FromQuery] int id, [FromQuery] decimal ammount)
		{
			var db = _dbFactory.CreateCardRepo();
			var card = db.GetTable(c => c.Id == id).FirstOrDefault();
			card.Balance = card.Balance + ammount;
			db.Update(card);
		}


		[HttpDelete("deleteCard")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreateCardRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
