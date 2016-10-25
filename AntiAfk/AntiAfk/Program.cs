using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace AntiAfk
{
    class Program
    {
        const UInt32 WM_KEYDOWN = 0x0100;
        const UInt32 WM_KEYUP = 0x101;
        const UInt32 VK_CONTROL = 0x11;
        const UInt32 VK_LEFT = 0x25;
        const UInt32 VK_UP = 0x26;
        const UInt32 VK_RIGHT = 0x27;
        const UInt32 VK_DOWN = 0x28;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        static void Main(string[] args)
        {
            Console.WriteLine("classictibia anti-afk..");
            Random rnd = new Random();
            while (true)
            {
                Process[] processes = Process.GetProcessesByName("classictibia");
                foreach (Process proc in processes)
                {
                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)VK_CONTROL, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)VK_LEFT, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)VK_LEFT, 0);
                    Thread.Sleep(rnd.Next(100, 300));

                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)VK_UP, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)VK_UP, 0);
                    Thread.Sleep(rnd.Next(100, 300));

                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)VK_UP, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)VK_UP, 0);
                    Thread.Sleep(rnd.Next(100, 300));

                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)VK_DOWN, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)VK_DOWN, 0);
                    Thread.Sleep(rnd.Next(100, 300));

                    PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)VK_UP, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)VK_UP, 0);
                    PostMessage(proc.MainWindowHandle, WM_KEYUP, (int)VK_CONTROL, 0);
                    Thread.Sleep(rnd.Next(1500, 3000));
                }
                Thread.Sleep(rnd.Next(5, 12) * 60 * 1000);
            }
        }
    }
}
