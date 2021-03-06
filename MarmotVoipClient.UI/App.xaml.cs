﻿using Autofac;
using LoggingAPI;
using MarmotVoipClient.UI.Startup;
using System;
using System.Windows;
using System.Windows.Threading;

namespace MarmotVoipClient.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static readonly IContainer _container = new Bootstrapper().Bootstrap();

		public static IContainer Container
		{
			get
			{
				return _container;
			}
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			try
			{
				var mainWindow = Container.Resolve<MainWindow>();
				mainWindow.Show();
			}
			catch (Exception ex)
			{
				Logger.Error(description: "MainWindow not created!", exception: ex, logLevel: Level.Fatal);
				MessageBox.Show("Application not created! See log file for more detailed information", "Startup Error");
				Current.Shutdown();
			}
		}

		private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			Logger.Error(description: "Unexpected Error occured", exception: e.Exception, logLevel: Level.Fatal);

			MessageBox.Show("Unexpected Error occured. See the log inforamtion.", "Unexpected error");

			e.Handled = true;
		}
	}
}
