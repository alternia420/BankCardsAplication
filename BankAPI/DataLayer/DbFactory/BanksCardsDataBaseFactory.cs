using BankAPI.Config;
using BankAPI.DataLayer;
using BankAPI.DataLayer.Models;
using BankAPI.Models;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;


namespace BankAPI.DbFactory
{
	public class BanksCardsDataBaseFactory : IBanksCardsDataBaseFactory
	{
		private IConnectionConfig _config;
		private LinqToDbConnectionOptions _options;
		public BanksCardsDataBaseFactory(IConnectionConfig config)
		{
			_config = config;

			var builder = new LinqToDbConnectionOptionsBuilder();
			builder.UseSqlServer(_config.ConnectionString);
			_options = builder.Build();
		}

		public IBanksCardsDataBase<Card> CreateCardRepo()
		{
			return new BanksCardsDataBase<Card>(_options);
		}

		public IBanksCardsDataBase<CardStatus> CreateCardStatusRepo()
		{
			return new BanksCardsDataBase<CardStatus>(_options);
		}

		public IBanksCardsDataBase<CardType> CreateCardTypeRepo()
		{
			return new BanksCardsDataBase<CardType>(_options);
		}

		public IBanksCardsDataBase<Client> CreateClientRepo()
		{
			return new BanksCardsDataBase<Client>(_options);
		}

		public IBanksCardsDataBase<Currency> CreateCurrencyRepo()
		{
			return new BanksCardsDataBase<Currency>(_options);
		}

		public IBanksCardsDataBase<PaymentSystemType> CreatePaymentSystemTypeRepo()
		{
			return new BanksCardsDataBase<PaymentSystemType>(_options);
		}
		public IBanksCardsDataBase<Transaction> CreateTransactionRepo()
		{
			return new BanksCardsDataBase<Transaction>(_options);
		}
	}
}
