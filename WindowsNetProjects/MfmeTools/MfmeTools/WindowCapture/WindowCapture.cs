﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MfmeTools.WindowCapture.NativeMethods;

namespace MfmeTools.WindowCapture
{
    class WindowCapture
    {
        //private readonly string[] _ignoreProcesses = { "applicationframehost", "shellexperiencehost", "systemsettings", "winstore.app", "searchui" };

        public static bool SplashscreenWindowFound
        {
            get
            {
                return SplashscreenWindowHandle != IntPtr.Zero;
            }
        }

        public static bool MainFormWindowFound
        {
            get
            {
                return MainFormWindowHandle != IntPtr.Zero;
            }
        }

        public static bool PropertiesWindowFound
        {
            get
            {
                return PropertiesWindowHandle != IntPtr.Zero;
            }
        }

        public static IntPtr SplashscreenWindowHandle = IntPtr.Zero;
        public static IntPtr MainFormWindowHandle = IntPtr.Zero;
        public static IntPtr PropertiesWindowHandle = IntPtr.Zero;

        public static RECT MainFormWindowRect = new RECT();
        public static RECT PropertiesWindowRect = new RECT();

        public static void Reset()
        {
            SplashscreenWindowHandle = IntPtr.Zero;
            MainFormWindowHandle = IntPtr.Zero;
        }

        public static void FindSplashscreenWindow(uint targetProcessId)
        {
            const bool kDebugOutput = false;

            NativeMethods.EnumWindows((hWnd, lParam) =>
            {
                if(SplashscreenWindowFound)
                {
                    return true;
                }

                NativeMethods.GetWindowThreadProcessId(hWnd, out var processId);

                if(processId != targetProcessId)
                {
                    return true;
                }


                if (!NativeMethods.IsWindowVisible(hWnd))
                {
                    return true;
                }

                if (string.IsNullOrWhiteSpace(GetWindowText(hWnd)))
                {
                    return true;
                }

                var process = Process.GetProcessById((int)processId);

                if (kDebugOutput)
                {
                    OutputLog.Log("Found Window");
                    OutputLog.Log($"Process name: {process.ProcessName}");
                    OutputLog.Log($"Window title: {GetWindowText(hWnd)}");
                }

                SplashscreenWindowHandle = hWnd;

                return true;
            }, IntPtr.Zero);
        }

        public static void FindMainformWindow(uint targetProcessId)
        {
            const bool kDebugOutput = false;

            NativeMethods.EnumWindows((hWnd, lParam) =>
            {
                if (MainFormWindowFound)
                {
                    return true;
                }

                NativeMethods.GetWindowThreadProcessId(hWnd, out var processId);

                if (processId != targetProcessId)
                {
                    return true;
                }


                if (!NativeMethods.IsWindowVisible(hWnd))
                {
                    return true;
                }

                if (string.IsNullOrWhiteSpace(GetWindowText(hWnd)))
                {
                    return true;
                }

                if (hWnd == SplashscreenWindowHandle)
                {
                    return true;
                }

                var process = Process.GetProcessById((int)processId);

                if (kDebugOutput)
                {
                    OutputLog.Log("Found Window");
                    OutputLog.Log($"Process name: {process.ProcessName}");
                    OutputLog.Log($"Window title: {GetWindowText(hWnd)}");
                }

                MainFormWindowHandle = hWnd;

                return true;
            }, IntPtr.Zero);
        }

        public static void FindPropertiesWindow(uint targetProcessId)
        {
            const bool kDebugOutput = false;

            NativeMethods.EnumWindows((hWnd, lParam) =>
            {
                if (PropertiesWindowFound)
                {
                    return true;
                }

                NativeMethods.GetWindowThreadProcessId(hWnd, out var processId);

                if (processId != targetProcessId)
                {
                    return true;
                }

                if (!NativeMethods.IsWindowVisible(hWnd))
                {
                    return true;
                }

                if (string.IsNullOrWhiteSpace(GetWindowText(hWnd)))
                {
                    return true;
                }

                if (hWnd == SplashscreenWindowHandle || hWnd == MainFormWindowHandle)
                {
                    return true;
                }

                var process = Process.GetProcessById((int)processId);

                if (kDebugOutput)
                {
                    OutputLog.Log("Found Window");
                    OutputLog.Log($"Process name: {process.ProcessName}");
                    OutputLog.Log($"Window title: {GetWindowText(hWnd)}");
                }

                PropertiesWindowHandle = hWnd;

                return true;
            }, IntPtr.Zero);
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            var title = new StringBuilder(1024);
            NativeMethods.GetWindowText(hWnd, title, title.Capacity);

            return title.ToString();
        }

        public static RECT GetWindowRect(object wrapper, IntPtr hWnd)
        {
            NativeMethods.GetWindowRect(new HandleRef(wrapper, hWnd), out RECT rect);
            return rect;
        }
    }
}
