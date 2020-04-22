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
    public partial class FrmClipboard : Form
    {
        #region Singleton Form
        private static FrmClipboard inst;

        public static FrmClipboard GetForm(string Text)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new FrmClipboard();
            }
            inst.Text = Text;
            return inst;
        }
        #endregion

        public string Text
        {
            get
            {
                return txtClipboard.Text;
            }
            set
            {
                txtClipboard.Text = value;
            }
        }
        public FrmClipboard ()
        {
            InitializeComponent();

            // Place th form bottom right
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height - 80);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
