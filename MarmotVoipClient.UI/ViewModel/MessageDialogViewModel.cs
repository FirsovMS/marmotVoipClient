using MahApps.Metro.IconPacks;
using MarmotVoipClient.UI.Events;
using MarmotVoipClient.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarmotVoipClient.UI.ViewModel
{
	public class MessageDialogViewModel : ViewModelBase, IMessageDialogViewModel
	{
		private IEventAggregator eventAggregator;
		private ObservableCollection<MessageWrapper> messages;
		private MessageWrapper selectedMessage;
		private PackIconMaterial iconSend;
		private string messageText;

		public ObservableCollection<MessageWrapper> Messages
		{
			get { return messages; }
			set
			{
				messages = value;
				OnPropertyChanged();
			}
		}

		public MessageWrapper SelectedMessage
		{
			get { return selectedMessage; }
			set
			{
				selectedMessage = value;
				OnPropertyChanged();
			}
		}

		public string MessageText
		{
			get { return messageText; }
			set
			{
				messageText = value;
				OnPropertyChanged();
				UpdateSendIcon();
			}
		}

		public PackIconMaterial IconSend
		{
			get { return iconSend; }
			set
			{
				iconSend = value;
				OnPropertyChanged();
			}
		}

		public ICommand BackCommand { get; }

		public ICommand CallCommand { get; }

		public ICommand SearchCommand { get; }

		public ICommand PropertiesCommand { get; }

		public ICommand SendCommand { get; }

		public ICommand ContectInfoCommand { get; }

		public MessageDialogViewModel(IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;

			Messages = new ObservableCollection<MessageWrapper>();
			IconSend = new PackIconMaterial()
			{
				Kind = PackIconMaterialKind.Microphone
			};

			BackCommand = new DelegateCommand(OnBackCommandExecute);
			CallCommand = new DelegateCommand(OnCallCommandExecute);
			SearchCommand = new DelegateCommand(OnSearchCommandExecute);
			PropertiesCommand = new DelegateCommand(OnPropertiesCommandExecute);
			SendCommand = new DelegateCommand(OnSendCommandExecute);
			ContectInfoCommand = new DelegateCommand(OnUserInfoCommandExecute);
		}

		private void OnUserInfoCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnSendCommandExecute()
		{
			throw new NotImplementedException();
		}

		public Task LoadAsync(int contactId)
		{
			throw new NotImplementedException();
		}

		private void UpdateSendIcon()
		{
			switch (IconSend.Kind)
			{
				case PackIconMaterialKind.Send:
					IconSend.Kind = PackIconMaterialKind.Microphone;
					break;
				case PackIconMaterialKind.Microphone:
					IconSend.Kind = PackIconMaterialKind.Send;
					break;
			}
		}

		private void OnPropertiesCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnSearchCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnCallCommandExecute()
		{
			throw new NotImplementedException();
		}

		private void OnBackCommandExecute()
		{
			throw new NotImplementedException();
		}
	}
}
