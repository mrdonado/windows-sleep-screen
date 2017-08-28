using System;
using System.Threading;
using System.Runtime.InteropServices;


namespace sleep_screen
{

    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
           IntPtr hWnd,
           UInt32 Msg,
           IntPtr wParam,
           IntPtr lParam
        );

        public enum SpecialHandles
        {
            HWND_DESKTOP = 0x0,
            HWND_BROADCAST = 0xFFFF
        }

        static void turnOffScreen()
        {
            SendMessage(
                (IntPtr)SpecialHandles.HWND_BROADCAST,
                0x0112,         // WM_SYSCOMMAND
                (IntPtr)0xf170, // SC_MONITORPOWER
                (IntPtr)0x0002  // POWER_OFF
             );
        }

        static void Main(string[] args)
        {
            // Workaround: to prevent the screen from turning on again 
            // (some versions of windows, some screen types), the message
            // will be sent 5 times within 5 seconds
            turnOffScreen();
            Thread.Sleep(1000);
            turnOffScreen();
            Thread.Sleep(1000);
            turnOffScreen();
            Thread.Sleep(1000);
            turnOffScreen();
            Thread.Sleep(1000);
            turnOffScreen();
        }
    }
}
