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
            conf.Test.Add("sdf","sdfsdf");
            propertyGrid1.SelectedObject = conf;
        }
    }
}
