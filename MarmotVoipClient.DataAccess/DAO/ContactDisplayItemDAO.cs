using DAL;
using LoggingAPI;
using MarmotVoipClient.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarmotVoipClient.DataAccess.DAO
{
	public class ContactDisplayItemDAO : BaseDAO, IBaseActions<ContactDisplayItem>
	{
		public ContactDisplayItemDAO(DataAccessLayer dal) : base(dal)
		{
		}

		public IEnumerable<ContactDisplayItem> GetAll()
		{
			return DAL.ExecuteQuery(Requests.DA_CONTACT_DISPLAY_ITEM_GET_ALL,
					reader => DataHandlers.ContactDisplayItemHandler(reader));
		}

		public bool TryAdd(ContactDisplayItem value)
		{
			return DAL.TryExecuteUpdate(string.Format("insert into ContactDisplayItem(contact_id, color, short_name) values({0}, '{1}', '{2}');"
				, value.Contact.Id, value.Gliph.Color, value.Gliph.Text));
		}

		public bool TryGet(int contactId, out ContactDisplayItem value)
		{
			bool result = false;
			value = null;
			var query = string.Format(Requests.DA_CONTACT_DISPLAY_ITEM_GET_BY_ID_FMT, contactId);
			try
			{
				value = DAL.ExecuteQuery(query, reader => DataHandlers.ContactDisplayItemHandler(reader))?.FirstOrDefault();

				result = value != null;
			}
			catch (Exception ex)
			{
				Logger.Error("Can't get ContactDisplayItem!", ex, Level.Error, query);
			}
			return result;
		}

		public bool TryRemove(ContactDisplayItem value)
		{
			var query = QueryBuilder.Add(Requests.DA_CONTACT_DISPLAY_ITEM_REMOVE_FMT)
				.AddParams(value.Contact.Id.ToString())
				.Build();
			return DAL.TryExecuteUpdate(query);
		}

		public bool TryUpdate(ContactDisplayItem value)
		{
			var query = QueryBuilder.Add(Requests.DA_CONTACT_DISPLAY_ITEM_UPDATE_FMT)
				.AddParams(value.Contact.Id.ToString(), value.Gliph.Color, value.Gliph.Text)
				.Build();
			return DAL.TryExecuteUpdate(query);
		}
	}
}
