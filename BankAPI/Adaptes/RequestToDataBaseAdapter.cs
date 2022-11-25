using BankAPI.BussinessLogic;
using BankAPI.Models;
using BankAPI.Models.Request;

namespace BankAPI.Adaptes
{
	public interface IRequestToDataBaseAdapter
	{
		Card Adapt(UpdateCardRequest req, int id);
	}


	public class RequestToDataBaseAdapter : IRequestToDataBaseAdapter
	{
		public IStringEncryptor _encriptor;
		public RequestToDataBaseAdapter(IStringEncryptor encryptor)
		{
			_encriptor = encryptor;
		}

		public Card Adapt(UpdateCardRequest req, int id)
		{
			return new Card
			{
				ClientId = req.ClientId,
				CardNumber = req.CardNumber,
				CurrencyId = req.CurrencyId,
				ExpDate = req.ExpDate,
				CVV = _encriptor.EncryptString(req.CVV),
				Balance = req.Balance,
				Id = id,
				PaymentSystemId = req.PaymentSystemId,
				StatusId = req.StatusId,
				TypeId = req.TypeId
			};
		}
	}
}
