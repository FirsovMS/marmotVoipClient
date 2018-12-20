using System;
using System.ComponentModel.DataAnnotations;
using static MarmotVoipClient.Model.Enums;

namespace MarmotVoipClient.Model.Data
{
	public class CallItem
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int SourceId { get; set; }

		[Required]
		public int DestinationId { get; set; }

		[Required]
		public CallType CallType { get; set; }

		public DateTime TimeStart { get; set; }

		public DateTime TimeEnd { get; set; }
	}
}
