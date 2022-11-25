using BankAPI.Models;
using BankAPI.Models.Enums;
using BankAPI.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.BussinessLogic
{
	public interface ICardGenerator
	{
		Card GenerateCard(CreateCardRequest req);
	}

	public class CardGenerator : ICardGenerator
	{
		private readonly IStringEncryptor _encriptor;
		public CardGenerator(IStringEncryptor encryptor)
		{
			_encriptor = encryptor;
		}
		public Card GenerateCard(CreateCardRequest req)
		{
			Random rnd = new Random();

			var card = new Card
			{
				Balance = 0,
				ClientId = req.ClientId,
				PaymentSystemId = req.PaymentSystemType,
				TypeId = req.CardType,
				CurrencyId = req.CurrencyId,
				StatusId = (int)CardStatuses.NotActivated,
				CardNumber = GenereteNumber(rnd),
				CVV = GenerateCVV(rnd),
				ExpDate = GenereteExpDate()
			};

			return card;
		}

		private string GenereteNumber(Random rnd)
		{
			int cardNumber1 = rnd.Next(4572, 4999);
			int cardNumber2 = rnd.Next(1000, 9999);
			int cardNumber3 = rnd.Next(1000, 9999);
			int cardNumber4 = rnd.Next(1000, 9999);

			return $"{cardNumber1}{cardNumber2}{cardNumber3}{cardNumber4}";
		}

		private DateTime GenereteExpDate()
		{
			var date = DateTime.Now;
			var day = date.Day;
			var month = date.Month;
			var year = date.Year + 3;

			return new DateTime(year, month, day);
		}

		private string GenerateCVV(Random rnd)
		{
			var cvv = rnd.Next(100, 999).ToString();
			return _encriptor.EncryptString(cvv);

		}
	}
}
