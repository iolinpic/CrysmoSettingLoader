using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrysmoSettingLoader.Interface;
using CrysmoSettingLoader.Static;
using CrysmoSettingLoader.ViewModels;
using System.Globalization;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace CrysmoSettingLoader.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl, ISwitchable
    {
        private DashboardViewModel dashboardViewModel;
        public DashboardView()
        {
            InitializeComponent();
            /*if (!Switcher.state.Auth)
            {
                CurrentUserModel mod = HttpService.getCurrentUser();
                Switcher.Authentificate(mod);
                //Task.Run(() => HttpService.wsConnect());
                //var res = Task.Run(async () => await HttpService.wsRead());
            }*/
            dashboardViewModel = new DashboardViewModel();
            DataContext = dashboardViewModel;
            //loadEventFieldData();

            //this.DataContext = mod;
        }

        
/*        private void loadEventFieldData()
        {
            //EventValuesViewModel.GetFields(HttpService.GetEventFields());
            EventValuesViewModel.GetFields(Storage.getInstance().EventFields);
            EventValuesViewModel.GetEvent(HttpService.GetEvent());
            //load field settings and default values
        }*/

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        public void BeforeSwitch() { 
        }
    }

    /*public class FieldItemTypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringDataTemplate { get; set; }
        public DataTemplate LogicDataTemplate { get; set; }
        public DataTemplate ImageDataTemplate { get; set; }
        

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fieldItem = item as FieldItem;

            if (fieldItem != null)
            {
                switch (fieldItem.Field.Type)
                {
                    case "text":
                        return StringDataTemplate;
                    case "logic":
                        return LogicDataTemplate;
                    case "image":
                        return ImageDataTemplate;
                    
                }
            }
            return base.SelectTemplate(item, container);
        }
    }

    public class FieldToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = value as Field;
            var tmpString = "просмотр_";
            tmpString += data.Source;
            tmpString += "_";
            tmpString += data.Name;
            tmpString += "_";
            tmpString += data.Id;
            if (Switcher.UserCan(tmpString)) {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

      
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }*/
}
