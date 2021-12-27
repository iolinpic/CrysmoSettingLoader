using CrysmoSettingLoader.Commands;
using CrysmoSettingLoader.Models;
using CrysmoSettingLoader.Static;
using CrysmoSettingLoader.Views;

namespace CrysmoSettingLoader.ViewModels
{
    /// <summary>
    /// View model for LoginView
    /// </summary>
    internal class LoginViewModel : ViewModel
    {
        private bool isLoggingIn;
        private string login;

        private string message;
        private RelayCommand loginCommand;

        public LoginViewModel()
        {
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

        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??= new RelayCommand(async (obj) =>
                {
                    var pbox = obj as System.Windows.Controls.PasswordBox;
                    if (Login != null && pbox.Password != null)
                    {
                        Message = "Выполняеться проверка";
                        IsLoggingIn = true;
                        var res = await HttpService.login(new LoginModel { email = Login, password = pbox.Password });
                        if (res != null)
                        {
                            Message = "Получаем данные авторизованного пользователя";
                            Switcher.Authentificate(res.user);
                            if (IsSaved)
                            {
                                Storage.getInstance().LocalSettings.Token = res.token;
                            }
                            Switcher.Switch(new DashboardView());
                        }
                        else
                        {
                            Switcher.addNotification("Введенные данные не верны");
                            IsLoggingIn = false;
                        }
                        Message = "";
                    }
                });
            }
        }
    }
}