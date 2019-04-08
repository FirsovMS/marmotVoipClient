using Autofac;
using MarmotVoipClient.Model;
using MarmotVoipClient.UI.Data.Lookups;
using MarmotVoipClient.UI.Events;
using MarmotVoipClient.UI.View;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MarmotVoipClient.UI.ViewModel
{
	public class ContactNavigationViewModel : ViewModelBase, IContactNavigationViewModel
	{
		private IContactLookupDataService contactDataService;
		private IEventAggregator eventAggregator;
		private ObservableCollection<UserItemViewModel> contacts;
		private UserItemViewModel selectedContact;
		private string searchText;

		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged();
				// TODO: Drop event -> search text on contacts and messages
			}
		}

		public ObservableCollection<UserItemViewModel> Contacts
		{
			get { return contacts; }
			set
			{
				contacts = value;
				OnPropertyChanged();
			}
		}

		public UserItemViewModel SelectedContact
		{
			get { return selectedContact; }
			set
			{
				selectedContact = value;
				OnPropertyChanged();
				if (selectedContact != null)
				{
					eventAggregator.GetEvent<OpenMessageDialogViewEvent>()
						.Publish(selectedContact.Id);
				}
			}
		}

		public ICommand SettingsMenuCommand { get; }

		public ContactNavigationViewModel(IContactLookupDataService contactDataService,
			IEventAggregator eventAggregator)
		{
			this.contactDataService = contactDataService;
			this.eventAggregator = eventAggregator;

			Contacts = new ObservableCollection<UserItemViewModel>();
			SearchText = string.Empty;

			SettingsMenuCommand = new DelegateCommand(OnSettingsMenuCommandExecute);
		}

		public void Load()
		{
			var lookups = contactDataService.GetContactLookups();

			Contacts.Clear();
			// TODO: Remove mock Gliph, LastMessage element
			foreach (var item in lookups)
			{
				Contacts.Add(new UserItemViewModel(item.Id, item.DisplayMember, DateTime.Now,
					new Gliph()
					{
						Color = "#27E846",
						Text = "AS"
					}, new LastMessage()
					{
						IsPrefix = true,
						Text = "latesMessage"
					}));
			}
		}

		private void OnSettingsMenuCommandExecute()
		{
			var settingsMenu = App.Container.Resolve<SettingsView>();

			var dialogResult = settingsMenu.ShowDialog();
			if (dialogResult == DialogResult.Yes)
			{
				// TODO: Update new value
				var propertyBag = settingsMenu.SettingsViewModel.PropertyBag;
				if (propertyBag.Any())
				{

				}
			}
		}
	}
}
