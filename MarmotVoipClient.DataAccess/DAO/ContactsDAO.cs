using DAL;
using LoggingAPI;
using MarmotVoipClient.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MarmotVoipClient.DataAccess.DAO
{
	public class ContactsDAO : BaseDAO, IBaseActions<Contact>
	{
		public ContactsDAO(DataAccessLayer dal) : base(dal)
		{
		}

		public bool TryAdd(Contact value)
		{
			var query = QueryBuilder.Add(Requests.DA_CONTACTS_INSERT_NEW_VALUES_FMT)
				.AddParams(value.Id.ToString(), value.FirstName, value.LastName, value.Sip)
				.Build();

			return DAL.TryExecuteUpdate(query);
		}

		public bool TryGet(string sip, out Contact value)
		{
			bool opResult = false;
			value = Contact.Default();

			var query = QueryBuilder.Add(Requests.DA_CONTACTS_GET_BY_SIP_FMT)
				.AddParams(sip)
				.Build();

			try
			{
				var result = DAL.ExecuteQuery(query, reader => DataHandlers.ContactHandler(reader))
				.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get contact by sip!", ex, Level.Error, query);
			}
			return opResult;
		}

		public bool TryGet(int id, out Contact value)
		{
			bool opResult = false;
			value = Contact.Default();

			var query = QueryBuilder.Add(Requests.DA_CONTACTS_GET_BY_ID_FMT)
				.AddParams(id.ToString())
				.Build();

			try
			{
				var result = DAL.ExecuteQuery(query, reader => DataHandlers.ContactHandler(reader))
				.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get contact by id!", ex, Level.Error, query);
			}
			return opResult;
		}

		public IEnumerable<Contact> GetAll()
		{
			IEnumerable<Contact> result = null;

			try
			{
				result = DAL.ExecuteQuery(Requests.DA_CONTACTS_GET_ALL, row => DataHandlers.ContactHandler(row));
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get all contacts!", ex, Level.Error, Requests.DA_CONTACTS_GET_ALL);
			}
			return result;
		}

		public bool TryRemove(Contact value)
		{
			bool opResult = false;
			var query = string.Format(Requests.DA_CONTACTS_DELETE_VALUE_BY_ID_FMT, value.Id);

			opResult = DAL.TryExecuteUpdate(query);
			if (!opResult)
			{
				Logger.Error("Can't remove contact by id!", logLevel: Level.Error, sqlQuery: query);
			}
			return opResult;
		}

		public bool TryUpdate(Contact value)
		{
			var query = QueryBuilder.Add(Requests.DA_CONTACTS_UPDATE_VALUE_BY_ID_FMT)
				.AddParams(value.Id.ToString(), value.FirstName, value.LastName, value.Sip)
				.Build();

			return DAL.TryExecuteUpdate(query);
		}

		private bool TryGet<T>(string query, out Contact value)
		{
			bool opResult = false;
			value = Contact.Default();

			try
			{
				var result = DAL.ExecuteQuery(query, reader => DataHandlers.ContactHandler(reader))
				.FirstOrDefault();

				opResult = result != null;
				if (opResult)
				{
					value = result;
				}
			}
			catch (Exception ex)
			{
				Logger.Error("Can't handle or get contact!", ex, Level.Error, query);
			}
			return opResult;
		}
	}
}
