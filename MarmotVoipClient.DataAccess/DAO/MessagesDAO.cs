using DAL;
using MarmotVoipClient.Model.Data;
using System.Collections.Generic;

namespace MarmotVoipClient.DataAccess.DAO
{
	public class MessagesDAO : BaseDAO
	{
		public MessagesDAO(DataAccessLayer dal) : base(dal)
		{
		}

		public IEnumerable<Message> GetAllFromTo(Contact from, Contact to)
		{
			var query = QueryBuilder.Add(Requests.DA_MESSAGES_GET_FROM_TO_FMT)
					.AddParams(from.Id.ToString(), to.Id.ToString())
					.Build();
			return DAL.ExecuteQuery(query, reader => DataHandlers.MessagesHandler(reader));
		}

		public IEnumerable<Message> GetLastFromTo(Contact from, Contact to)
		{
			var query = QueryBuilder.Add(Requests.DA_MESSAGES_GET_LAST_FROM_TO_FMT)
					.AddParams(from.Id.ToString(), to.Id.ToString())
					.Build();

			return DAL.ExecuteQuery(query, reader => DataHandlers.MessagesHandler(reader));
		}
	}
}
