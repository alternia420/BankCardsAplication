using BankAPI.DbFactory;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentSystemsController : ControllerBase
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;

		public PaymentSystemsController(IBanksCardsDataBaseFactory dbFactory)
		{
			_dbFactory = dbFactory;
		}

		[HttpGet("getAllTypes")]

		public IEnumerable<PaymentSystemType> Get()
		{
			var db = _dbFactory.CreatePaymentSystemTypeRepo();
			return db.GetTable();
		}

		[HttpGet("getType")]
		public PaymentSystemType GetType([FromQuery] int id)
		{
			var db = _dbFactory.CreatePaymentSystemTypeRepo();
			return db.GetTable(x => x.Id == id).FirstOrDefault();
		}

		[HttpPost("createType")]
		public void Create(PaymentSystemType type)
		{
			var db = _dbFactory.CreatePaymentSystemTypeRepo();
			db.Insert(type);
		}

		[HttpPost("updateType")]
		public void Update(PaymentSystemType type)
		{
			var db = _dbFactory.CreatePaymentSystemTypeRepo();
			db.Update(type);
		}

		[HttpDelete("deleteType")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreatePaymentSystemTypeRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
