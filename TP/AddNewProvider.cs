using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity.entity;
using Service.by.rfe.service;

namespace TP
{
    public partial class AddNewProvider : Form
    {
        public AddNewProvider(string service)
        {
            InitializeComponent();
            Text = service;
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Equals(""))
            {
                Form err = new DialogWithOne_Buttom("Заполните все поля", Text);
                err.ShowDialog();
            }
            else
            {
                if (textBox3.TextLength == 13)
                {

                    ProviderManagerService service = ProviderManagerService.getInstance();
                    service.addProvider(textBox1.Text, textBox2.Text, textBox3.Text);
                    Form createProvider = new DialogWithOne_Buttom("Поставщик добавлен", Text);
                    createProvider.ShowDialog();

                    Close();

                }
                else
                {
                    Form err = new DialogWithOne_Buttom("Длина номера должна состоять из 12 цифр", Text);
                    err.ShowDialog();
                }
            }


        }
    }
}
