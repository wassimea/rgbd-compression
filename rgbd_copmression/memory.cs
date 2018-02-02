using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace rgbd_copmression
{
    class memory
    {
        public class MemoryManagement
        {
            [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet =
            CharSet.Ansi, SetLastError = true)]

            private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int
            maximumWorkingSetSize);

            public static void FlushMemory()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
            }
        }
    }
}