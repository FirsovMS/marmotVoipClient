using Autofac;
using DAL;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.DataAccess.DAO;
using MarmotVoipClient.UI.Data.Lookups;
using MarmotVoipClient.UI.Data.Repositories;
using MarmotVoipClient.UI.View;
using MarmotVoipClient.UI.View.Settings;
using MarmotVoipClient.UI.ViewModel;
using MarmotVoipClient.UI.ViewModel.Settings;
using Prism.Events;

namespace MarmotVoipClient.UI.Startup
{
	public class Bootstrapper
	{
		public IContainer Bootstrap()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

			builder.RegisterInstance(new DataAccessLayer(Requests.CONNECTION_STRING)).AsSelf();
			builder.RegisterType<ContactsDAO>().AsSelf().SingleInstance();
			builder.RegisterType<ContactDisplayItemDAO>().AsSelf().SingleInstance();
			builder.RegisterType<MessagesDAO>().AsSelf().SingleInstance();

			// Register Data Services
			builder.RegisterType<ContactDataService>().As<IContactDataService>();
			builder.RegisterType<ContactLookupDataService>().As<IContactLookupDataService>();

			// Register repositories
			builder.RegisterType<AccountRepository>().As<IAccountRepository>();

			// Register ViewModels
			builder.RegisterType<MainViewModel>().AsSelf();
			builder.RegisterType<ContactNavigationViewModel>().As<IContactNavigationViewModel>();
			builder.RegisterType<MessageDialogViewModel>().As<IMessageDialogViewModel>();

			builder.RegisterType<AccountSettingsViewModel>().AsSelf().SingleInstance();
			builder.RegisterType<SettingsViewModel>().AsSelf().SingleInstance(); ;

			// RegisterWindows
			builder.RegisterType<AccountSettingsUC>().AsSelf();
			builder.RegisterType<SettingsView>().AsSelf();
			builder.RegisterType<MainWindow>().AsSelf();

			return builder.Build();
		}
	}
}
