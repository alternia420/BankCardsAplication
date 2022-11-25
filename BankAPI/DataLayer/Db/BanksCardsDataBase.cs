using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using System.Diagnostics.CodeAnalysis;
using System.Data.SqlClient;

namespace BankAPI.DataLayer
{
	[ExcludeFromCodeCoverage]
	public class BanksCardsDataBase<T> : IBanksCardsDataBase<T> where T : class
	{
		private readonly LinqToDbConnectionOptions _options;

		public BanksCardsDataBase(LinqToDbConnectionOptions options)
		{
			_options = options;
		}

		public List<T> GetTable(Func<T, bool> predicate)
		{
			using (var db = new DataConnection(_options))
			{
				var q = db.GetTable<T>().Where(predicate).ToList();
				return q;
			}
		}

		public List<T> GetTable()
		{
			using (var db = new DataConnection(_options))
			{
				var q = db.GetTable<T>().ToList();
				return q;
			}
		}

		public void Insert(T data)
		{
			using (var db = new DataConnection(_options))
			{
				db.Insert<T>(data);
			}
		}

		public void Update(T data)
		{
			using (var db = new DataConnection(_options))
			{
				db.Update<T>(data);
			}
		}

		public void Delete(Func<T, bool> predicate)
		{
			using (var db = new DataConnection(_options))
			{
				var q = db.GetTable<T>().Where(predicate);
				if (q.Count() > 0)
				{
					db.Delete(q.First());
				}
				return;
			}
		}

	}
}
