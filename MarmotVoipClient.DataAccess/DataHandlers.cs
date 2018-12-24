using MarmotVoipClient.Model;
using MarmotVoipClient.Model.Data;
using System;
using System.Data;

namespace MarmotVoipClient.DataAccess
{
	internal static class DataHandlers
	{
		internal static Contact ContactHandler(IDataReader reader)
		{
			return new Contact(
				Convert.ToInt32(reader["contact_id"]),
				(string)reader["first_name"],
				(string)reader["last_name"],
				(string)reader["sip"]);
		}

		internal static CallItem CallHandler(IDataReader reader)
		{
			return new CallItem()
			{
				Id = Convert.ToInt32(reader["call_id"]),
				SourceId = Convert.ToInt32(reader["from_id"]),
				DestinationId = Convert.ToInt32(reader["to_id"]),
				CallType = (Enums.CallType)Convert.ToInt32(reader["call_type"]),
				TimeStart = DateTime.Parse(reader["time_start"].ToString()),
				TimeEnd = DateTime.Parse(reader["time_end"].ToString())
			};
		}

		internal static Message MessagesHandler(IDataReader reader)
		{
			return new Message
			{
				Id = Convert.ToInt32(reader["msg_id"]),
				MessageResultStatus = (Enums.MessageResultStatus)Convert.ToInt32(reader["msg_result"]),
				Text = Convert.ToString(reader["text"]),
				Date = Convert.ToDateTime(reader["date"])
			};
		}

		internal static ContactDisplayItem ContactDisplayItemHandler(IDataReader reader)
		{
			return new ContactDisplayItem()
			{
				Contact = ContactHandler(reader),
				Gliph = new Gliph
				{
					Color = Convert.ToString(reader["color"]),
					Text = Convert.ToString(reader["short_name"]),
				}
			};
		}

		internal static HistoryItem HandleHistoryItem(IDataReader dataRow)
		{
			return new HistoryItem()
			{
				Id = Convert.ToInt32(dataRow["id"]),
				ItemType = (Enums.ActionType)dataRow["item_type"],
				CallId = Convert.ToInt32(dataRow["call_id"]),
				MessageId = Convert.ToInt32(dataRow["msg_id"])
			};
		}
	}
}
