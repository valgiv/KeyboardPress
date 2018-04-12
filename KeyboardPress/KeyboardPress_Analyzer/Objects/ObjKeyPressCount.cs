

namespace KeyboardPress_Analyzer.Objects
{
    public class ObjKeyPressCount
    {
        public ObjKeyPressCount()
        {

        }

        public ObjKeyPressCount(int asciiKeyCode)
        {
            this.AsciiKeyCode = asciiKeyCode;
            PressHoldCount = 1;
            PressReleaseCount = 0;
        }

        public int AsciiKeyCode { get; set; }
        public uint PressHoldCount { get; set; }
        public uint PressReleaseCount { get; set; }

    }
    
}
