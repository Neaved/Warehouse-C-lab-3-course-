using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.by.rfe.service;
using Entity.entity;

namespace TP
{
    public partial class DialogWithTwo_Buttom : Form
    {
        private Provider currentProvider;

        public DialogWithTwo_Buttom(Provider currentProvider, string message, string service)
        {
            InitializeComponent();
            this.currentProvider = currentProvider;
            label1.Text = message;
            Text = service;
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            
            ProviderManagerService provider = ProviderManagerService.getInstance();
            if (provider.deleteProvider(currentProvider))
            {
                Form confirm = new DialogWithOne_Buttom("Поставщик удален", Text);
                confirm.ShowDialog();
                Close();
            }

            else
            {
                Form reject = new DialogWithOne_Buttom("Поставщик не был удален, \n т.к. еще не все его заказы отработаны", Text);
                reject.ShowDialog();
                Close();
            }
       }
    }
}
