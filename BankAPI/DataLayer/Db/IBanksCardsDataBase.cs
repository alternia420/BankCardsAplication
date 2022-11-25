

namespace BankAPI.DataLayer
{
	public interface IBanksCardsDataBase<T> where T : class
	{
		List<T> GetTable(Func<T, bool> predicate);
		List<T> GetTable();
		void Insert(T data);
		void Update(T data);
		void Delete(Func<T, bool> predicate);
	}
}
