using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MarmotVoipClient.DataAccess
{
	public static class Requests
	{
#if DEBUG
		// Use Your Root Path ToSource Folder
		private static readonly string PathToRoot = @"C:\Users\Michael\source\repos\MarmotVoipClient";
		public static readonly string CONNECTION_STRING = $"Data Source={PathToRoot}\\test_db.db;Pooling=true;FailIfMissing=false";
#else
		public static readonly string CONNECTION_STRING = @"Data Source=./data.db;Version=3;";
#endif
		public static readonly string DA_TRANSACTION_BEGIN = "BEGIN TRANSACTION";

		public static readonly string DA_TRANSACTION_COMMIT = "COMMIT;";

		public static readonly string DA_CHECK_EXISTS_BY_PROP = "SELECT COUNT(1) FROM {0} WHERE {1} = {2};";

		#region Contacts

		public static readonly string DA_CONTACTS_GET_BY_ID_FMT =
			"SELECT contact_id, first_name, last_name, sip FROM contacts WHERE contact_id = {0};";

		public static readonly string DA_CONTACTS_GET_BY_SIP_FMT =
			"SELECT contact_id, first_name, last_name, sip FROM contacts WHERE sip = '{0}';";

		public static readonly string DA_CONTACTS_GET_ALL =
			"SELECT contact_id, first_name, last_name, sip FROM contacts;";

		public static readonly string DA_CONTACTS_INSERT_NEW_VALUES_FMT =
			"INSERT INTO contacts(contact_id, first_name, last_name, sip) VALUES ({0} ,'{1}', '{2}', '{3}');";

		public static readonly string DA_CONTACTS_DELETE_VALUE_BY_ID_FMT =
			"DELETE FROM contacts WHERE contact_id = {0};";

		public static readonly string DA_CONTACTS_UPDATE_VALUE_BY_ID_FMT =
			"UPDATE contacts SET first_name = '{1}', last_name = '{2}', sip = '{3}' WHERE contact_id = {0};";

		#endregion

		#region Calls

		public static readonly string DA_CALLS_GET_ALL = "SELECT * FROM Calls";

		public static readonly string DA_CALLS_GET_BY_ID_FMT = "SELECT * FROM Calls WHERE call_id = {0}";

		public static readonly string DA_CALLS_GET_BY_FROM_OR_TO_FMT = "SELECT * FROM Calls WHERE from_id = {0} OR to_id = {1}";

		public static readonly string DA_CALLS_GET_BY_FROM_AND_TO_FMT = "SELECT * FROM Calls WHERE from_id = {0} AND to_id = {1}";

		public static readonly string DA_CALLS_GET_BY_TYPE = "SELECT * FROM Calls WHERE call_type = {0}";

		public static readonly string DA_CALLS_GET_BY_TIME_RANGE_FMT = "SELECT * FROM Calls WHERE time_start BETWEEN '{0}' AND '{1}'";

		public static readonly string DA_CALL_INSERT_RECORD_FMT =
			"INSERT INTO Calls(call_id, from_id, to_id, call_type, time_start, time_end) VALES({0}, {1}, {2}, {3}, '{4}', '{5}')";

		public static readonly string DA_CALL_UPDATE_RECORD_BY_ID_FMT =
			"UPDATE Calls SET from_id = {1}, to_id = {2}, call_type = {3}, time_start = '{4}', time_end = '{5}' WHERE call_id = {0}";

		public static readonly string DA_CALL_REMOVE_BY_ID_FMT =
			"DELETE FROM Calls Where call_id = {0}";

		#endregion

		#region History

		public static readonly string DA_HISTORY_GET_ALL = "SELECT * FROM History;";

		public static readonly string DA_HISTORY_GET_BY_ID_FMT = "SELECT * FROM History WHERE id = {0}";

		public static readonly string DA_HISTORYS_GET_BY_TYPE_FMT = "SELECT * FROM History WHERE item_type = {0}";

		public static readonly string DA_HISTORY_REMOVE_BY_ID_INTO_FMT = "DELETE FROM History WHERE id INTO ({0})";

		public static readonly string DA_HISTORY_INSERT_RECORD_FMT = "INSERT INTO History(id, item_type, call_id, msg_id) VALUES({0}, {1}, {2}, {3})";

		#endregion

		public static readonly string DA_GET_CALL_TYPE_BY_ID_FMT = "SELECT description FROM CallType where id = {0}";

		#region ContactDisplayItem

		public static readonly string DA_CONTACT_DISPLAY_ITEM_GET_ALL = "select B.contact_id, B.first_name, B.last_name, B.sip, A.color, A.short_name from ContactDisplayItem as A inner join Contacts as B on A.contact_id = B.contact_id";

		public static readonly string DA_CONTACT_DISPLAY_ITEM_GET_BY_ID_FMT = "select B.contact_id, B.first_name, B.last_name, B.sip, A.color, A.short_name from ContactDisplayItem as A inner join Contacts as B on A.contact_id = B.contact_id where B.contact_id = {0}";

		public static readonly string DA_CONTACT_DISPLAY_ITEM_REMOVE_FMT = "delete from ContactDisplayItem where contact_id = {0};";

		public static readonly string DA_CONTACT_DISPLAY_ITEM_UPDATE_FMT = "update ContactDisplayItem set color = '{1}', short_name = '{2}' where contact_id = {0};";

		#endregion


		#region Messages

		public static readonly string DA_MESSAGES_GET_FROM_TO_FMT = "SELECT msg_id, contact_from, contact_to, text, msg_result, date FROM (SELECT * FROM Messages WHERE contact_from = {0} and contact_to = {1} union SELECT  * FROM Messages WHERE contact_to = {0} and contact_from = {1}) as T ORDER BY date ASC;";

		public static readonly string DA_MESSAGES_GET_LAST_FROM_TO_FMT = "SELECT msg_id, contact_from, contact_to, text, msg_result, date FROM (SELECT * FROM Messages WHERE contact_from = {0} and contact_to = {1} union SELECT  * FROM Messages WHERE contact_to = {0} and contact_from = {1}) as T WHERE date = (SELECT MAX(date) FROM Messages);";

		#endregion
	}
}
