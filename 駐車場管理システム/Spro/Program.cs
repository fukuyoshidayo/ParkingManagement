using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Spro
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            EmbeddedAssembly.Load("Spro.EPPlus.dll", "EPPlus.dll");
            EmbeddedAssembly.Load("Spro.System.Data.SqlLocalDb.dll", "System.Data.SqlLocalDb.dll");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParkingManageMenu());
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

    }
}
