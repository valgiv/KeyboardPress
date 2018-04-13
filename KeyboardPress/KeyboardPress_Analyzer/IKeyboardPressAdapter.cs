
namespace KeyboardPress_Analyzer
{
    public interface IKeyboardPressAdapter
    {
        /// <summary>
        /// Catches keyboard presses events and saves data about it
        /// </summary>
        void StartHookWork();

        /// <summary>
        /// Stops catching keyboard presses
        /// </summary>
        void StopHookWork();

        ///// <summary>
        ///// Cleans saved data
        ///// </summary>
        //void CleanData();
        
    }
}
