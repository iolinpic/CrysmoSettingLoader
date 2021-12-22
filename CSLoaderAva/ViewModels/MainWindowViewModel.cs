using CSLoaderAva.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CSLoaderAva.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;
        public ObservableCollection<MenuItem> MenuItems { get; }

        public MainWindowViewModel()
        {
            Content = new LoginViewModel();
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Login", ClassName = "CSLoaderAva.ViewModels.LoginViewModel" }
            };
        }

        public ViewModelBase Content
        {
            get { return content; }
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
    }
}