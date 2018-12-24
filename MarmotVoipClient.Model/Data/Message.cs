using System;
using System.ComponentModel.DataAnnotations;

namespace MarmotVoipClient.Model.Data
{
	public class Message
	{
		[Key]
		public int Id { get; set; }

		[StringLength(255)]
		public string Text { get; set; }

		[Required]
		public DateTime Date { get; set; }

		public Enums.MessageResultStatus MessageResultStatus { get; set; }
	}
}
