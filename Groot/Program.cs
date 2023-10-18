using System;
using System.Windows.Forms;

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
