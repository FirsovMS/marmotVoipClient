namespace MarmotVoipClient.Model
{
	public class LastMessage
	{
		private string text;

		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				text = value ?? string.Empty;
			}
		}

		public bool IsPrefix { get; set; }
	}
}
