using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CSLoaderAva.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}