using System;
using System.Collections.Generic;
using System.Text;

namespace ClouReaderDemo.Helper
{
    /// <summary>
    /// 计时器帮助类
    /// RFID_LX
    /// </summary>
    public class Helper_Timers
    {
        static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

        public Helper_Timers() { }

        public static void Start() { watch.Start(); }

        public static void Stop() { watch.Stop(); }

        public static void Reset() { watch.Reset(); }

        public static void Restart() { watch.Reset(); watch.Start(); }

        public static TimeSpan GetElapsed() { return watch.Elapsed; }

        public static String GetElapsedString() 
        {
            return watch.Elapsed.ToString();
        }

    }
}
