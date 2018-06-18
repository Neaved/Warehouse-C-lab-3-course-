using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP
{
    public partial class DialogWithOne_Buttom : Form
    {
        public DialogWithOne_Buttom(string msg, string service)
        {
            InitializeComponent();
            messageText.Text = msg;
            Text = service;
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
