﻿using CrysmoSettingLoader.Commands;
using CrysmoSettingLoader.Models;
using CrysmoSettingLoader.Static;
using CrysmoSettingLoader.Views;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.ViewModels
{
    /// <summary>
    /// View model for LoginView
    /// </summary>
    class LoginViewModel : ViewModel
    {
        private bool isLoggingIn;
        private string login;
        
        private string message;
        private RelayCommand loginCommand;
        //private RelayCommand settingsCommand;
        
        public LoginViewModel() {
            isLoggingIn = false;
        }

        public bool IsSaved
        {
            get { return Storage.getInstance().LocalSettings.Saved; }
            set
            {
                Storage.getInstance().LocalSettings.Saved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }

        public bool IsLoggingIn
        {
            get { return isLoggingIn; }
            set
            {
                isLoggingIn = value;
                OnPropertyChanged(nameof(IsLoggingIn));
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public RelayCommand LoginCommand {
            get {
                return loginCommand ??= new RelayCommand(async (obj)=> {
                    var pbox = obj as System.Windows.Controls.PasswordBox;
                    if (Login != null && pbox.Password != null) {
                        Message = "Выполняеться проверка";
                        IsLoggingIn = true;
                        //var res = await HttpService.auth(Login, pbox.Password);
                        var res = await HttpService.login(new LoginModel { email = Login, password = pbox.Password });
                        if (res != null)
                        {
                            Message = "Получаем данные авторизованного пользователя";
                            Switcher.Authentificate(res.user);
                            if (IsSaved)
                            {
                                Storage.getInstance().LocalSettings.Token = res.token;
                            }
                            /*Message = "Получаем Настройки приложения";
                            //Switcher.state.getSettings(await HttpService.GetSettingsAsync());
                            Message = "Получаем данные карточек";
                            Storage.getInstance().EventFields = await HttpService.GetEventFieldsAsync();
                            Storage.getInstance().ParticipantFields = await HttpService.GetParticipantFieldsAsync();
                            Storage.getInstance().Zones = await HttpService.GetZonesAsync();*/
                            //HttpService.getCurrentUser()
                            Switcher.Switch(new DashboardView());
                        }
                        else {
                            Switcher.addNotification("Введенные данные не верны");
                            IsLoggingIn = false;
                        }
                        Message = "";
                    }
                });
            }
        }

        /*public RelayCommand SettingsCommand {
            get
            {
                return settingsCommand ??= new RelayCommand((obj)=> {
                    SettingsWindow settingsWindow = new SettingsWindow
                    {
                        Owner = Switcher.pageSwitcher
                    };
                    if (settingsWindow.ShowDialog() == true)
                    {
                        Switcher.LocalSettings.Server = settingsWindow.Server;
                        HttpService.UpdateBase(Storage.getInstance().LocalSettings.Server);
                    }
                });
            }
        }*/
    }
}