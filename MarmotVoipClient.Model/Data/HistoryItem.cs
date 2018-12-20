using System.ComponentModel.DataAnnotations;
using static MarmotVoipClient.Model.Enums;

namespace MarmotVoipClient.Model.Data
{
	public class HistoryItem
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public ActionType ItemType { get; set; }

		public int CallId { get; set; }

		public int MessageId { get; set; }
	}
}
