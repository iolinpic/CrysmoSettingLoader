using CrysmoSettingLoader.Commands;
using CrysmoSettingLoader.Services;
using CrysmoSettingLoader.Static;
using CrysmoSettingLoader.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using CrysmoSettingLoader.Models;

namespace CrysmoSettingLoader.ViewModels
{
    /// <summary>
    /// View model for MainView, sets up all singleton classes and initialize settings
    /// </summary>
    class MainViewModel : ViewModel
    {
        private MainMenuItem selectedMenuItem;
        private RelayCommand switchScreenCommand;
        private RelayCommand logoutCommand;
        private string _windowTitle;
        public ObservableCollection<MainMenuItem> MenuItems { get; set; }
        private List<MainMenuItem> menuItems;
        private SnackbarMessageQueue messageQueue;

        public AppState state {
            get {
                return Storage.getInstance().State;
            }
        }

        public string WindowTitle {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                OnPropertyChanged(nameof(WindowTitle));
            }
        }

        public MainViewModel()
        {
            _windowTitle = "";
            MenuItems = new ObservableCollection<MainMenuItem>();
            menuItems = new List<MainMenuItem>{
                new MainMenuItem { Title = "Панель выгрузки", Address = "CrysmoSettingLoader.Views.DashboardView" },

            };
        }


        public bool isAuthentificate
        {
            get
            {
                return state.Auth;
            }
        }

        public SnackbarMessageQueue MessageQueue {
            get { return messageQueue ?? (messageQueue = new SnackbarMessageQueue()); }
            set { messageQueue = value;
                OnPropertyChanged(nameof(MessageQueue));
            }
        }

        public RelayCommand LogoutCommand
        {
            get { return logoutCommand ??= new RelayCommand(obj=> {

                WindowTitle = "";
                SelectedMenuItem = null;
                MenuItems.Clear();
                state.resetDefault();
                Storage.getInstance().LocalSettings.Token = "";
                Switcher.Switch(new LoginVeiw());
            }); }
        }

        public MainMenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                selectedMenuItem = value;
                OnPropertyChanged("SelectedMenuItem");
                SwitchScreenCommand.Execute(value);
            }
        }

        public RelayCommand SwitchScreenCommand
        {
            get
            {
                return switchScreenCommand ?? (switchScreenCommand = new RelayCommand(obj => {
                    if (selectedMenuItem != null)
                    {
                        Switcher.Switch((UserControl)Activator.CreateInstance(Type.GetType(selectedMenuItem.Address)));
                        WindowTitle = selectedMenuItem.Title;
                    }
                }));
            }
        }
        private void updateUser(CurrentUserModel mod) {
            state.User.UpdateUser(mod);
            UpdateMenuByPermissions();
        }

        

        public void GenerateMenuByPermissions()
        {
            foreach (MainMenuItem item in menuItems)
            {
                if (item.Permission == null)
                {
                    MenuItems.Add(item);
                }
            }
            SelectedMenuItem = menuItems[0];
        }

        private void UpdateMenuByPermissions()
        {
            foreach (MainMenuItem item in menuItems)
            {
                if (item.Permission == null)
                {
                    if (!MenuItems.Contains(item)) {
                        MenuItems.Add(item);
                    }

                }
                else
                {
                    if (MenuItems.Contains(item))
                    {
                        MenuItems.Remove(item);
                        if(SelectedMenuItem == item)
                        {
                            SelectedMenuItem = MenuItems[0];
                        }
                    }
                }
            }
        }
    }
}
