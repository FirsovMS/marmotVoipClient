using System.Drawing;

namespace MarmotVoipClient.UI.ViewModel
{
	public class UserItemViewModel : ViewModelBase
	{
		private string displayMember;

		public Color Color { get; }

		public int Id { get; }

		public string DisplayMember
		{
			get { return displayMember; }
			private set
			{
				displayMember = value;
				OnPropertyChanged();
			}
		}

		public UserItemViewModel(int id, string displayMember)
		{
			Id = id;
			DisplayMember = displayMember;
		}
	}
}
