using DAL;
using System.Linq;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess.DAO
{
	public abstract class BaseDAO
	{
		protected DataAccessLayer DAL { get; }
		protected readonly QueryBuilderInstance QueryBuilder;

		public BaseDAO(DataAccessLayer dal)
		{
			DAL = dal;
			QueryBuilder = new QueryBuilderInstance();
		}

		protected virtual async Task<bool> CheckExistsAsync<T>(string tableName, string propertName, T value)
		{
			var query = string.Format(Requests.DA_CHECK_EXISTS_BY_PROP, tableName, propertName, value);
			return (await DAL.ExecuteQueryAsync(query, (row) => (bool)row[0])).First();
		}
	}
}
