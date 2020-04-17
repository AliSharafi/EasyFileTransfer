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

namespace EasyFileTransfer
{
    public partial class frmMain : Form
    {


        #region fields
        FileTransfer _fileTransfer;
        #endregion

        public frmMain(string[] args,FileTransfer ft)
        {
            InitializeComponent();

            _fileTransfer = ft;
            _fileTransfer.InfoLabel = lblInfo;

            if (args.Length > 0)
            {
                txtFileName.Text = args[0];
                DoSend();
            }
        }

        #region Form event handlers
        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            // Show the open file dialog to select our data.
            openFileDialog1.ShowDialog();

            //Get the file name and write it into our text box.
            txtFileName.Text = openFileDialog1.FileName;

            if (txtFileName.Text != null)
                btnSend.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            DoSend();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            _fileTransfer._serverIP = txtIP.Text;
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fileTransfer.Stop();
        }
        #endregion

        #region Send File
        private void DoSend()
        {
            lblInfo.Text = "sending";
            try
            {
                _fileTransfer.Send(txtFileName.Text);
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


    }
}
