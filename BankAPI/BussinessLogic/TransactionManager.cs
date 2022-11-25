using BankAPI.DataLayer.Models;
using BankAPI.DbFactory;
using BankAPI.Models.Enums;
using BankAPI.Models.Request;
using BankAPI.Models.Response;
using BankAPI.Validation;
using BankAPI.Validation.Errors;

namespace BankAPI.BussinessLogic
{
	public interface ITransactionManager
	{
		TransactionResponse ProssesTransaction(TransactionRequest req);
	}
	public class TransactionManager : ITransactionManager
	{

		private readonly ITransactionValidator _validator;
		private readonly IBanksCardsDataBaseFactory _dbFactory;
		private bool IsRecieverOurClient { get; set; }
		public TransactionManager(ITransactionValidator validator, IBanksCardsDataBaseFactory factory)
		{
			_validator = validator;
			_dbFactory = factory;
		}

		public TransactionResponse ProssesTransaction(TransactionRequest req)
		{
			var error = _validator.ValidateTransaction(req);
			var response = new TransactionResponse
			{
				Error = error,
				Status = TransansationStatuses.Blocked
			};
			if (error != CardErrors.NoError)
			{
				SaveTransaction(TransansationStatuses.Blocked, req);
				return response;
			}
			SaveTransaction(TransansationStatuses.Succsess, req);
			UpdateCards(req);
			response.Status = TransansationStatuses.Succsess;
			return response;
		}

		private void UpdateCards(TransactionRequest req)
		{
			var repo = _dbFactory.CreateCardRepo();
			var senderCard = repo.GetTable(c => c.CardNumber == req.SenderCardNumber).FirstOrDefault();
			senderCard.Balance = senderCard.Balance - req.Amount;
			repo.Update(senderCard);
			if (IsRecieverOurClient)
			{
				var recieverCard = repo.GetTable(c => c.CardNumber == req.RecieverCardNumber).FirstOrDefault();
				recieverCard.Balance = recieverCard.Balance + req.Amount;
				repo.Update(recieverCard);
			}
		}

		private void SaveTransaction(TransansationStatuses status, TransactionRequest req)
		{
			var transaction = new Transaction
			{
				SenderCard = req.SenderCardNumber,
				SenderId = GetSenderId(req.SenderCardNumber),
				RecieverCard = req.RecieverCardNumber,
				RecieverId = GetResieverId(req.RecieverCardNumber),
				Status = (int)status,
				Amount = req.Amount,
				Timestamp = DateTime.Now
			};
			var repo = _dbFactory.CreateTransactionRepo();
			repo.Insert(transaction);
		}

		private int GetSenderId(string cardNumber)
		{
			var repo = _dbFactory.CreateCardRepo();
			var card = repo.GetTable(c => c.CardNumber == cardNumber);
			return card.FirstOrDefault().ClientId;
		}

		private int? GetResieverId(string cardNumber)
		{
			var repo = _dbFactory.CreateCardRepo();
			var card = repo.GetTable(c => c.CardNumber == cardNumber);
			if (card.FirstOrDefault() != null)
			{
				IsRecieverOurClient = true;
				return card.FirstOrDefault().ClientId;
			}
			IsRecieverOurClient = false;
			return null;
		}
	}
}
