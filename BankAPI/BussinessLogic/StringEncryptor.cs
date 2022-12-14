using System.Security.Cryptography;
using System.Text;

namespace BankAPI.BussinessLogic
{
	public interface IStringEncryptor
	{
		string EncryptString(string plainText);
		string DecryptString(string encryptedText);
	}

	public class StringEncryptor : IStringEncryptor
	{
		private byte[] _key;
		private byte[] _iv;
		private TripleDESCryptoServiceProvider _provider;

		public StringEncryptor()
		{
			_key = Encoding.ASCII.GetBytes("GSYAHAGCBDUUADIADKOPAAAW");
			_iv = Encoding.ASCII.GetBytes("USAZBGAW");
			_provider = new TripleDESCryptoServiceProvider();
		}

		#region IStringEncryptor Members

		public string EncryptString(string plainText)
		{
			return Transform(plainText, _provider.CreateEncryptor(_key, _iv));
		}

		public string DecryptString(string encryptedText)
		{
			return Transform(encryptedText, _provider.CreateDecryptor(_key, _iv));
		}

		#endregion

		private string Transform(string text, ICryptoTransform transform)
		{
			if (text == null)
			{
				return null;
			}
			using (MemoryStream stream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write))
				{
					byte[] input = Encoding.Default.GetBytes(text);
					cryptoStream.Write(input, 0, input.Length);
					cryptoStream.FlushFinalBlock();

					return Encoding.Default.GetString(stream.ToArray());
				}
			}
		}
	}


}
