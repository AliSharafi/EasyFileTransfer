using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyFileTransfer.Utils;

namespace EasyFileTransfer
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
            AppConfigs conf = new AppConfigs();

        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSavePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfigs conf = new AppConfigs();
            conf.ServerIP = txtServerIP.Text;
            conf.SavePath = txtSavePath.Text;
            conf.DomainUsername = txtDomainUsername.Text;
            AppConfigs.Save(conf);
            Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            AppConfigs conf = AppConfigs.Load();
            txtServerIP.Text = conf.ServerIP;
            txtSavePath.Text = conf.SavePath;
            txtDomainUsername.Text = conf.DomainUsername;
        }
    }
}
