﻿using Autofac;
using LoggingAPI;
using MarmotVoipClient.DataAccess;
using MarmotVoipClient.UI.Startup;
using System;
using System.Windows;

namespace MarmotVoipClient.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var bootrstrapper = new Bootstrapper();
			var container = bootrstrapper.Bootstrap();

			try
			{
				var mainWindow = container.Resolve<MainWindow>();
			}
			catch (Exception ex)
			{
				Logger.Error(description: "MainWindow not created!", exception: ex, logLevel: Level.Fatal);
				MessageBox.Show("Application not created! See log file for more information", "Startup Error");
				Application.Current.Shutdown();
			}
			MainWindow.Show();
		}

		private void Application_DispatcherUnhandledException(object sender,
			System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			Logger.Error(description: "Unexpected Error occured", exception: e.Exception, logLevel: Level.Fatal);

			MessageBox.Show("Unexpected Error occured. See the log inforamtion.", "Unexpected error");

			e.Handled = true;
		}
	}
}
