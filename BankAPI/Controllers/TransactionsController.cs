using BankAPI.BussinessLogic;
using BankAPI.DataLayer.Models;
using BankAPI.DbFactory;
using BankAPI.Models.Request;
using BankAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly ITransactionManager _transactionManager;
		private readonly IBanksCardsDataBaseFactory _dbFactory;


		public TransactionsController(ITransactionManager transactionManager, IBanksCardsDataBaseFactory dbFactory)
		{
			_transactionManager = transactionManager;
			_dbFactory = dbFactory;
		}

		[HttpGet("getAll")]
		public List<Transaction> GetAll()
		{
			var db = _dbFactory.CreateTransactionRepo();
			return db.GetTable();
		}

		[HttpGet("getSent")]
		public List<Transaction> GetAllSentTransactionsForClient([FromQuery] int id)
		{
			var db = _dbFactory.CreateTransactionRepo();
			return db.GetTable(x => x.SenderId == id);
		}
		[HttpGet("getRecieved")]
		public List<Transaction> GetAllReciievedTransactionsForClient([FromQuery] int id)
		{
			var db = _dbFactory.CreateTransactionRepo();
			return db.GetTable(x => x.RecieverId == id);
		}

		[HttpPost("createTransaction")]
		public TransactionResponse Create(TransactionRequest req)
		{
			var response = _transactionManager.ProssesTransaction(req);
			return response;
		}


		[HttpDelete("deleteTransaction")]
		public void Delete([FromQuery] int id)
		{
			var db = _dbFactory.CreateTransactionRepo();
			db.Delete(x => x.Id == id);
		}
	}
}
