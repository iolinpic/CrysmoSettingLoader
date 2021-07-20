using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using CrysmoSettingLoader.Models;
using CrysmoSettingLoader.ViewModels;
using CrysmoSettingLoader.Views;
using CrysmoSettingLoader.Static;

namespace CrysmoSettingLoader.Static
{   
    /// <summary>
    /// Class used for coodinating window navigation (switch of user components)
    /// </summary>
    public static class Switcher
    {
        public static MainWindow pageSwitcher;
        public static AppState state { 
            get {
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

        public static void Switch(UserControl newPage) {
            pageSwitcher.Navigate(newPage);
        }
        public static void Switch(UserControl newPage, object state) {
            pageSwitcher.Navigate(newPage, state);
        }

        public static void Authentificate(CurrentUserModel user) {
            state.Auth = true;
            state.User.UpdateUser(user);
            //state.getSettings();
            pageSwitcher.ShowMenu();
        }
        public static void Authentificate()
        {
            state.Auth = true;
            //state.User.UpdateUser(user);
            //state.getSettings();
            pageSwitcher.ShowMenu();
        }
        /*public static void UpdateDeviceList()
        {
            var page = pageSwitcher.App.Content as DeviceView;
            if(page!= null)
            {
                var context = page.DataContext as DeviceViewModel;
               
                context.setDevices(HttpService.GetDevices());
                if (context.EditingDevice != null)
                {
                    var id = context.EditingDevice.Id;
                    foreach (var device in context.Devices)
                    {
                        if (device.Id == id)
                        {
                            context.SelectedDevice = device;
                            break;
                        }
                    }
                }
            }
        }*/

        /*public static bool UserCan(string permission)
        {
            foreach(var perm in state.User.permissions)
            {
                if(perm.name== permission)
                {
                    return true;
                }
            }
            return false;
        }*/

        public static void addNotification(string message) {
            pageSwitcher.createNotification(message);
        }
    }
    
}
