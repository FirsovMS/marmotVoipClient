using MarmotVoipClient.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.UI.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private readonly IEventAggregator eventAggregator;

		public IContactNavigationViewModel ContactNavigation { get; }

		public IMessageDialogViewModel MessageDialog { get; }

		public MainViewModel(IContactNavigationViewModel contactNavigation,
			IMessageDialogViewModel messageDialog,
			IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			ContactNavigation = contactNavigation;
			MessageDialog = messageDialog;

			this.eventAggregator.GetEvent<OpenMessageDialogViewEvent>()
				.Subscribe(OnOpenMessageDialogView);
		}

		private async void OnOpenMessageDialogView(int contactId)
		{
			if (MessageDialog != null)
			{
				// close old

			}
			await MessageDialog.LoadAsync(contactId);
		}

		public void Load()
		{
			ContactNavigation.Load();
		}
	}
}
