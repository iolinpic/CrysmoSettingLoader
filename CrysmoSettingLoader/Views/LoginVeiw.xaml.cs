using CrysmoSettingLoader.Interface;
using CrysmoSettingLoader.ViewModels;
using System;
using System.Windows.Controls;

namespace CrysmoSettingLoader.Views
{
    /// <summary>
    /// Interaction logic for LoginVeiw.xaml
    /// </summary>
    public partial class LoginVeiw : UserControl, ISwitchable
    {
        private LoginViewModel viewModel;

        //private bool isLoggedIn;
        public LoginVeiw()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
            DataContext = viewModel;
        }

        void ISwitchable.UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        void ISwitchable.BeforeSwitch()
        {
        }
    }
}