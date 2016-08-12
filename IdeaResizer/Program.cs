using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IdeaResizer
{

    public static class SafeNativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    }

    public static class Program
    {

        // Pinvoke declaration for ShowWindow
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_RESTORE = 9;
        private const uint SWP_SHOWWINDOW = 0x0040;

        [STAThread]
        static void Main()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if(process.ProcessName.Contains("idea"))
                    {
                        var handle = process.MainWindowHandle;
                        SafeNativeMethods.SetWindowPos(handle, (IntPtr) 0, 0, 0, 640*3/2, 480*3/2, SWP_SHOWWINDOW);
                        SafeNativeMethods.ShowWindow(handle, SW_RESTORE);
                        SafeNativeMethods.ShowWindow(handle, SW_SHOWMAXIMIZED);
                    }
                }
            }
        }
    }
}
