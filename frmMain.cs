using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyFileTransfer.Utils;

namespace EasyFileTransfer
{
    public partial class frmMain : Form
    {


        #region fields
        FileTransfer _fileTransfer;
        string _selectedFile;
        #endregion


        #region Form event handlers
        public frmMain(string[] args, FileTransfer ft)
        { 
            InitializeComponent();

            // Place th form bottom right
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            //This object initiates from program.Main()
            _fileTransfer = ft;

           // WindowsContextMenu.Add("Send To Server");

            //Running from explorer context menu
            if (args.Length > 0)
            {
                _selectedFile = args[0];
                DoSend();
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowsContextMenu.Remove("Send To Server");
            _fileTransfer.Stop();
        }
        #endregion

        #region Send File
        private void DoSend()
        {
            if (string.IsNullOrEmpty(_selectedFile))
                return;

            try
            {
                _fileTransfer.Send(_selectedFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Msg No : 1   Could not connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Make form draggable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region Context menu
        private void sendToServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the open file dialog to select our data.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                _selectedFile = openFileDialog1.FileName;

            DoSend();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
        }
        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

       
    }
}
