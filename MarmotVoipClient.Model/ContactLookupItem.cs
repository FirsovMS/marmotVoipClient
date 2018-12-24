namespace MarmotVoipClient.Model
{
	public class ContactLookupItem
	{
		public int Id { get; set; }

		public string DisplayMember { get; set; }

		public Gliph Gliph { get; set; }

		public LastMessage LastMessage { get; set; }
	}
}
