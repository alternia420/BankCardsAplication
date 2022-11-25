namespace BankAPI.Validation.Errors
{
	public enum CardErrors
	{
		NoError,
		SenderExpiredCard,
		RecieverExpiredCard,
		WrongSenderCardData,
		WrongRecieverCardData,
		NotEnoughBalance
	}
}
