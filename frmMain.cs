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
        #region Constants
        const int _port = 2345;
        string _serverIP = "192.168.1.8";
        #endregion

        #region fields
        string _fName;
        Thread _listenThread;
        int _flag = 0;
        string _receivedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
        public delegate void ReceiveDelegate();
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        #endregion
        
        public frmMain()
        {
            _listenThread = new Thread(new ThreadStart(StartListening));
            _listenThread.Start();
            InitializeComponent();
        }

        #region Send File
        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            // Show the open file dialog to select our data.
            openFileDialog1.ShowDialog();

            //Get the file name and write it into our text box.
            txtFileName.Text = openFileDialog1.FileName;

            _fName = Path.GetFileName(openFileDialog1.FileName);

            if (txtFileName.Text != null) 
                btnSend.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] fileName = Encoding.UTF8.GetBytes(_fName); //file name
            byte[] fileData = File.ReadAllBytes(txtFileName.Text); //file
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); //lenght of file name

            byte[] m_clientData = new byte[4 + fileName.Length + fileData.Length];

            fileNameLen.CopyTo(m_clientData, 0);
            fileName.CopyTo(m_clientData, 4);
            fileData.CopyTo(m_clientData, 4 + fileName.Length);

            try
            {
                clientSock.Connect(_serverIP, _port); //target machine's ip address and the port number
                clientSock.Send(m_clientData);
                clientSock.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Msg No : 1   Could not connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

        #region Receive file
        private void StartListening()
        {
            //byte[] bytes = new Byte[1024];
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, _port);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(ipEnd);
                listener.Listen(32);
                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
            _flag = 0;
        }
        public void ReadCallback(IAsyncResult ar)
        {
            int fileNameLen = 1;
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                if (_flag == 0)
                {
                    fileNameLen = BitConverter.ToInt32(state.buffer, 0);
                    string fileName = Encoding.UTF8.GetString(state.buffer, 4, fileNameLen);
                    _receivedPath += fileName;
                    _flag++;
                }
                if (_flag >= 1)
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(_receivedPath, FileMode.Append));
                    if (_flag == 1)
                    {
                        writer.Write(state.buffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                        _flag++;
                    }
                    else
                        writer.Write(state.buffer, 0, bytesRead);
                    writer.Close();
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
            else
            {
                Invoke(new ReceiveDelegate(LabelWriter));
            }
        }
        public void LabelWriter()
        {
            lblInfo.Text = "Data has been received";
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _listenThread.Abort();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            _serverIP = txtIP.Text;
        }
    }
}
