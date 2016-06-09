using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {

        // Pinvoke declaration for ShowWindow
        private const int SW_SHOWMAXIMIZED = 3;

        private const uint SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter,int X,int Y,int cx,int cy,uint uFlags);

        static void Main(string[] args)
        {

        Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if(process.ProcessName.Contains("idea"))
                    {
                        //Console.WriteLine("Process: {0} \r\nID: {1} \r\nWindow title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                        var handle = process.MainWindowHandle;

                        //Rectangle monitor = Screen.AllScreens[1].WorkingArea;
                        //SetWindowPos(handle, 0, monitor.Left, monitor.Top, monitor.Width-200, monitor.Height, SWP_SHOWWINDOW);

                        SetWindowPos(handle, 0, 0, 0, 640*3/2, 480*3/2, SWP_SHOWWINDOW);

                        ShowWindow(handle, SW_SHOWMAXIMIZED);

                    }
                }
            }
        }
    }
}
