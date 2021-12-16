using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrysmoSettingLoader.Models
{
    /// <summary>
    /// Base model class
    /// </summary>
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}