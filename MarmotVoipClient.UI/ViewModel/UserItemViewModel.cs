using MarmotVoipClient.Model;
using System;

namespace MarmotVoipClient.UI.ViewModel
{
	public class UserItemViewModel : ViewModelBase
	{
		private Gliph gliph;
		private string displayName;
		private DateTime date;
		private LastMessage lastMessage;

		public int Id { get; }

		public string DisplayName
		{
			get { return displayName; }
			private set
			{
				displayName = value;
				OnPropertyChanged();
			}
		}

		public Gliph Gliph
		{
			get { return gliph; }
			set
			{
				gliph = value;
				OnPropertyChanged();
			}
		}

		public DateTime Date
		{
			get { return date; }
			set
			{
				date = value;
				OnPropertyChanged();
			}
		}

		public LastMessage LastMessage
		{
			get { return lastMessage; }
			set
			{
				lastMessage = value;
				OnPropertyChanged();
			}
		}

		public UserItemViewModel(int id, string dispayName, DateTime date, Gliph gliph, LastMessage lastMessage)
		{
			Id = id;
			DisplayName = dispayName;
			Date = date;
			Gliph = gliph;
			LastMessage = lastMessage;
		}
	}
}
