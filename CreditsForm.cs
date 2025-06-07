using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMic
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();

            label1.Text = "Name: " + Config.PRODUCT_NAME;
            label2.Text = "Version: " + Config.PRODUCT_VERSION;
            label3.Text = "Developer: " + Config.PRODUCT_DEVELOPER;

            linkLabel1.Text = Config.PRODUCT_GITHUB;
            linkLabel1.Links.Add(0, Config.PRODUCT_GITHUB.Length, Config.PRODUCT_GITHUB);
        }
    }
}
