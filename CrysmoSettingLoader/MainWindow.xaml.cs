using CrysmoSettingLoader.Interface;
using CrysmoSettingLoader.Static;
using CrysmoSettingLoader.ViewModels;
using CrysmoSettingLoader.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CrysmoSettingLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            HttpService.UpdateBase(Storage.getInstance().LocalSettings.Server);
            Switcher.pageSwitcher = this;
            viewModel = new MainViewModel();
            DataContext = viewModel;
            if (Storage.getInstance().LocalSettings.Saved && Storage.getInstance().LocalSettings.Token != "")
            {
                //var utask = Task.Run( async () =>  await HttpService.getCurrentUser());
                Switcher.Authentificate();
                Switcher.Switch(new DashboardView());
            }
            else
            {
                Switcher.Switch(new LoginVeiw());
            }
        }

        public void Navigate(UserControl nextPage)
        {
            var page = App.Content as ISwitchable;
            if (page != null)
            {
                page.BeforeSwitch();
            }
            App.Content = nextPage;
            MainMenuHost.IsLeftDrawerOpen = false;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            var page = App.Content as ISwitchable;
            if (page != null)
            {
                page.BeforeSwitch();
            }

            App.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;
            MainMenuHost.IsLeftDrawerOpen = false;
            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! " + nextPage.Name.ToString());
        }

        public void ShowMenu()
        {
            viewModel.GenerateMenuByPermissions();
        }

        public void createNotification(string notification)
        {
            viewModel.MessageQueue.Enqueue(notification, true);
        }
    }
}