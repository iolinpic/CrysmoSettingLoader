namespace CrysmoSettingLoader.Interface
{
    /// <summary>
    ///  Interface to be used in window layout switch as default functions to be run before and after switch
    /// </summary>
    internal interface ISwitchable
    {
        void UtilizeState(object state);

        void BeforeSwitch();
    }
}