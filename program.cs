using EasyFileTransfer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyFileTransfer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // test if this is the first instance and register receiver, if so.
            if (SingletonController.IamFirst(new SingletonController.ReceiveDelegate(SecondRun)))
            {
                WindowsContextMenu.Add("Send To Server");
                Application.Run(new frmMain(args,new FileTransfer(true)));
                

            }
            else
            {
                // send command line args to running app, then terminate
                SingletonController.Send(args);
            }
            SingletonController.Cleanup();
        }

        private static void SecondRun(string[] args)
        {
            new FileTransfer(false).Send(args[0]);
        }
    }
}
