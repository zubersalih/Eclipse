using System;
using System.Runtime.InteropServices;

namespace Eclipse
{
    class DllHelper
    {
        [DllImport("user32.dll")]
        public extern static Int16 GetKeyState(Int16 nVirtKey);


        [DllImport("user32")]
        public static extern int SetWindowLong(IntPtr hWnd, DllHelper.GWL nIndex, DllHelper.WS_EX dsNewLong);

        public enum GWL
        {
            ExStyle = -20,
        }

        public enum WS_EX
        {
            Transparent = 32,
            Layered = 524288,
        }

        public enum LWA
        {
            ColorKey = 1,
            Alpha = 2,
        }
    }
}
