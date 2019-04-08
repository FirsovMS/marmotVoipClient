using MahApps.Metro.Controls;
using MarmotVoipClient.UI.ViewModel;
using System.Windows;

namespace MarmotVoipClient.UI.View
{
	/// <summary>
	/// Interaction logic for SettingsView.xaml
	/// </summary>
	public partial class SettingsView : MetroWindow
	{
		private readonly SettingsViewModel _settingsViewModel;

		public SettingsView(SettingsViewModel settingsViewModel)
		{
			InitializeComponent();

			_settingsViewModel = settingsViewModel;

			DataContext = _settingsViewModel;
		}

		public new DialogResult ShowDialog()
		{
			var result = base.ShowDialog();
			if (result == false)
			{
				return ViewModel.DialogResult.No;
			}
			return _settingsViewModel.Result;
		}
	}
}
