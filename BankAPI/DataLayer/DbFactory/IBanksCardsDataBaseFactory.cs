using BankAPI.Models;
using BankAPI.DataLayer;
using BankAPI.DataLayer.Models;

namespace BankAPI.DbFactory
{
	public interface IBanksCardsDataBaseFactory
	{
		IBanksCardsDataBase<Client> CreateClientRepo();
		IBanksCardsDataBase<PaymentSystemType> CreatePaymentSystemTypeRepo();
		IBanksCardsDataBase<Card> CreateCardRepo();
		IBanksCardsDataBase<Currency> CreateCurrencyRepo();
		IBanksCardsDataBase<CardStatus> CreateCardStatusRepo();
		IBanksCardsDataBase<CardType> CreateCardTypeRepo();

		IBanksCardsDataBase<Transaction> CreateTransactionRepo();

	}
}
