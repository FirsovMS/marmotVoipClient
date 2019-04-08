using MarmotVoipClient.UI.ViewModel.Settings;
using System.Windows;
using System.Windows.Controls;

namespace MarmotVoipClient.UI.View.Settings
{
	/// <summary>
	/// Interaction logic for AccountSettingsUC.xaml
	/// </summary>
	public partial class AccountSettingsUC : UserControl
	{
		private readonly AccountSettingsViewModel _accountSettingsViewModel;

		public AccountSettingsUC(AccountSettingsViewModel accountSettingsViewModel)
		{
			_accountSettingsViewModel = accountSettingsViewModel;

			DataContext = _accountSettingsViewModel;

			Loaded += AccountSettingsUC_Loaded;
		}

		private void AccountSettingsUC_Loaded(object sender, RoutedEventArgs e)
		{
			_accountSettingsViewModel.Load();
		}
	}
}
