using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrysmoSettingLoader.ViewModels
{
    /// <summary>
    /// View model base class, implements interface INotifyPropertyChanged
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}