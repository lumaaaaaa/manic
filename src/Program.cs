using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace osu_manic
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        static public Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                         (int)(pixel & 0x0000FF00) >> 8,
                         (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(GetConsoleWindow(), 3);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(@"  _                       _      
 | |                     (_)     
 | |_ __ ___   __ _ _ __  _  ___ 
 | | '_ ` _ \ / _` | '_ \| |/ __|
 |_| | | | | | (_| | | | | | (__ 
 (_)_| |_| |_|\__,_|_| |_|_|\___|
 ________________________________                                
                                 
 [i] This build (1.0) has no GUI due to performance issues.
 [i] It is recommended to use this program offline; it will most likely result in a ban if your behavior is suspect (eg. rising 300k places in the leaderboard).
 [i] Launch osu! and open a 4K mania map. The program will detect notes and play them automatically.
 [i] Not working? Make sure you are using the 'osu!manic' skin. It can be found at ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"https://misato.pw/");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(@" or alternatively at ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"https://github.com/lumaaaaa/osu-manic");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(@".
 [i] Be sure to check out ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"https://misato.pw/");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(@" for more open-source software. Thank you.
");
            startThreads();
            Console.Read();
        }
        static void startThreads()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(dK), 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(fK), 2);
            ThreadPool.QueueUserWorkItem(new WaitCallback(jK), 3);
            ThreadPool.QueueUserWorkItem(new WaitCallback(kK), 4);
            /*ThreadPool.QueueUserWorkItem(new WaitCallback(k1), 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(k2), 2);
            ThreadPool.QueueUserWorkItem(new WaitCallback(k3), 3);
            ThreadPool.QueueUserWorkItem(new WaitCallback(k4), 4);
            ThreadPool.QueueUserWorkItem(new WaitCallback(k5), 5);
            ThreadPool.QueueUserWorkItem(new WaitCallback(k6), 6);
            ThreadPool.QueueUserWorkItem(new WaitCallback(k7), 7);*/
        }
        static private void dK(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(822, 845);
                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.Magenta;
                    //Console.WriteLine("[i] Tapping 'd'");
                    keybd_event(0x44, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.B == 255)
                {
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                        //Console.ForegroundColor = ConsoleColor.Magenta;
                        //Console.WriteLine("[i] Letting go of 'd'");
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x44, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        //Console.ForegroundColor = ConsoleColor.Magenta;
                        //Console.WriteLine("[i] Pressing and holding 'd'");
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void fK(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(922, 845);
                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    //Console.WriteLine("[i] Tapping 'f'");
                    keybd_event(0x46, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.B == 255)
                {
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                        //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        //Console.WriteLine("[i] Letting go of 'f'");
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x46, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        //Console.WriteLine("[i] Pressing and holding 'f'");
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void jK(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(1022, 845);
                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    //Console.WriteLine("[i] Tapping 'j'");
                    keybd_event(0x4A, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.B == 255)
                {
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                        //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        //Console.WriteLine("[i] Letting go of 'j'");
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x4A, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        //Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        //Console.WriteLine("[i] Pressing and holding 'j'");
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void kK(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(1122, 845);
                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.Magenta;
                    //Console.WriteLine("[i] Tapping 'k'");
                    keybd_event(0x4B, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.B == 255)
                {
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                        //Console.ForegroundColor = ConsoleColor.Magenta;
                        //Console.WriteLine("[i] Letting go of 'k'");
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x4B, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        //Console.ForegroundColor = ConsoleColor.Magenta;
                        //Console.WriteLine("[i] Pressing and holding 'k'");
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        // THE 7KEY WORKERS ARE BELOW! ---------------------------------------------------------------------------------------------
        static private void k1(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(800, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x53, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x53, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x53, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x53, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x53, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x53, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void k2(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(875, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x44, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x44, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x44, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void k3(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(965, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x46, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x46, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x46, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void k4(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(1035, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x20, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x20, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x20, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x20, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x20, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x20, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void k5(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(1125, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x4A, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x4A, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x4A, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void k6(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(1200, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x4B, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x4B, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x4B, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
        static private void k7(object state)
        {
            Color pixelColor;
            bool dLaneHold = false;
            bool lastwas255 = false;
            while (true)
            {
                pixelColor = GetPixelColor(1280, 830);

                if (pixelColor.G == 255 && pixelColor.B == 0)
                {
                    
                    keybd_event(0x4C, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    Thread.Sleep(1);
                    keybd_event(0x4C, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                else if (pixelColor.R == 255 || pixelColor.G == 224)
                {
                    
                    if (lastwas255)
                    {

                    }
                    else if (dLaneHold)
                    {
                        dLaneHold = false;
                        keybd_event(0x4C, 0, KEYEVENTF_KEYUP, 0);
                        
                    }
                    else
                    {
                        dLaneHold = true;
                        keybd_event(0x4C, 0, KEYEVENTF_EXTENDEDKEY, 0);
                        Thread.Sleep(50);
                    }
                    lastwas255 = true;
                }
                else if (pixelColor.R == 1)
                {
                    keybd_event(0x4C, 0, KEYEVENTF_KEYUP, 0);
                    dLaneHold = false;
                    lastwas255 = false;
                }
                else if (pixelColor.G > 100 && pixelColor.B > 100)
                {
                    Debug.WriteLine("Holding D!");
                    lastwas255 = false;
                    dLaneHold = true;
                }
                else
                {
                    keybd_event(0x4C, 0, KEYEVENTF_KEYUP, 0);
                    lastwas255 = false;
                    dLaneHold = false;
                }
                Thread.Sleep(0);
            }
        }
    }
}
