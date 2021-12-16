using CrysmoSettingLoader.Models;
using System.Windows.Controls;

namespace CrysmoSettingLoader.Static
{
    /// <summary>
    /// Class used for coodinating window navigation (switch of user components)
    /// </summary>
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static AppState state
        {
            get
            {
                return Storage.getInstance().State;
            }
        }

        public static LocalSettings LocalSettings
        {
            get
            {
                return Storage.getInstance().LocalSettings;
            }
        }

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }

        public static void Authentificate(CurrentUserModel user)
        {
            state.Auth = true;
            state.User.UpdateUser(user);
            //state.getSettings();
            pageSwitcher.ShowMenu();
        }

        public static void Authentificate()
        {
            state.Auth = true;
            HttpService.setToken(Storage.getInstance().LocalSettings.Token);
            pageSwitcher.ShowMenu();
        }

        public static void addNotification(string message)
        {
            pageSwitcher.createNotification(message);
        }
    }
}