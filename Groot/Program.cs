﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 其中專題;

namespace Groot
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Index());
            //Application.Run(new FrmMakeResume());
            //Application.Run(new FrmMakeJobRequire());
            //Application.Run(new Shop());
        }
    }
}
