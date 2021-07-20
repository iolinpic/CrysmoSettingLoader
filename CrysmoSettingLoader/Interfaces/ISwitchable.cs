using System;
using System.Collections.Generic;
using System.Text;

namespace CrysmoSettingLoader.Interface
{
    /// <summary>
    ///  Interface to be used in window layout switch as default functions to be run before and after switch
    /// </summary>
    interface ISwitchable
    {
        void UtilizeState(object state);
        void BeforeSwitch();
    }
}
