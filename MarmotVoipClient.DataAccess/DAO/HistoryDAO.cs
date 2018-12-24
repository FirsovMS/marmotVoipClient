using DAL;
using MarmotVoipClient.Model.Data;
using System;
using System.Collections.Generic;

namespace MarmotVoipClient.DataAccess.DAO
{
	class HistoryDAO : BaseDAO, IBaseActions<HistoryItem>
	{
		public HistoryDAO(DataAccessLayer dataAccessLayer) : base(dataAccessLayer)
		{
		}

		public IEnumerable<HistoryItem> GetAll()
		{
			return DAL.ExecuteQuery(Requests.DA_HISTORY_GET_ALL, row => DataHandlers.HandleHistoryItem(row));
		}

		public bool TryAdd(HistoryItem value)
		{
			throw new NotImplementedException();
		}

		public bool TryGet(int id, out HistoryItem value)
		{
			throw new NotImplementedException();
		}

		public bool TryRemove(HistoryItem value)
		{
			throw new NotImplementedException();
		}

		public bool TryUpdate(HistoryItem value)
		{
			throw new NotImplementedException();
		}
	}
}
