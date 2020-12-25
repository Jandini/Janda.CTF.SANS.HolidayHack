using Janda.CTF.SANS.HolidayHack.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices;

namespace Janda.CTF.SANS.HolidayHack
{       
    class Program 
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        [CTF(Name = "SANS Holiday Hack, December 2020")]
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            CTF.Run(args, (services) => services
                .AddS3Scanner()
                .AddWebBrowserService()
                .AddDictionary());
        }
    }
}