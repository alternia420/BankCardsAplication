using BankAPI.BussinessLogic;
using BankAPI.DbFactory;
using BankAPI.Models;
using BankAPI.Models.Request;
using BankAPI.Validation.Errors;
using System.Text.RegularExpressions;

namespace BankAPI.Validation
{
	public interface ITransactionValidator
	{
		CardErrors ValidateTransaction(TransactionRequest req);
	}

	public class TransactionValidator : ITransactionValidator
	{
		private readonly IBanksCardsDataBaseFactory _dbFactory;

		public TransactionValidator(IBanksCardsDataBaseFactory factory)
		{
			_dbFactory = factory;
		}

		public CardErrors ValidateTransaction(TransactionRequest req)
		{
			var senderCard = GetCard(req.SenderCardNumber);
			if (senderCard == null)
			{
				return CardErrors.WrongSenderCardData;
			}
			if (!ValidateExpDate(senderCard))
			{
				return CardErrors.SenderExpiredCard;
			}
			if (!DoesSenderHaveEhoughBalance(senderCard, req.Amount))
			{
				return CardErrors.NotEnoughBalance;
			}

			var recieverCard = GetCard(req.RecieverCardNumber);
			if (!ValidateCardNumber(req.RecieverCardNumber))
			{
				return CardErrors.WrongRecieverCardData;
			}
			if (recieverCard != null)
			{
				if (!ValidateExpDate(recieverCard))
					return CardErrors.RecieverExpiredCard;
			}

			return CardErrors.NoError;

		}
		private bool ValidateCardNumber(string cardNumber)
		{
			if (cardNumber.Count() != 16)
			{
				return false;
			}

			return true;
		}

		private Card? GetCard(string cardNumber)
		{
			var db = _dbFactory.CreateCardRepo();
			var cards = db.GetTable(c => c.CardNumber == cardNumber);
			if (cards.Count > 0)
			{
				return cards[0];
			}
			return null;
		}

		private bool ValidateExpDate(Card card)
		{
			return card.ExpDate > DateTime.Now;

		}

		private bool DoesSenderHaveEhoughBalance(Card card, decimal amount)
		{
			return card.Balance > amount;
		}
	}
}
