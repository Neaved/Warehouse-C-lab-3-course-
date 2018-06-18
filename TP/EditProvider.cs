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
using Queue.queue;
using Service.by.rfe.service;

namespace TP
{
    public partial class EditProvider : Form
    {
        private Provider currentProvider;
        public EditProvider()
        {
            InitializeComponent();
        }
        public EditProvider(Provider currentProvider, string service)
        {
            InitializeComponent();
            this.currentProvider = currentProvider;
            textBox1.Text = currentProvider.Name;
            textBox2.Text = currentProvider.Address;
            textBox3.Text = currentProvider.PhoneNumber;
            Text = service;

        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("") || textBox3.Equals(""))
            {
                Form err = new DialogWithOne_Buttom("Заполните все поля", Text);
                err.ShowDialog();
            }
            else
            {
                if (textBox3.TextLength == 13)
                {
                    currentProvider.Address = textBox2.Text;
                    currentProvider.PhoneNumber = textBox3.Text;
                    Form createProvider = new DialogWithOne_Buttom("Поставщик изменен", Text);
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

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {   
            Form deleteProvider = new DialogWithTwo_Buttom(currentProvider, "Вы действительно \nхотите удалить поставщика? ", Text);
            deleteProvider.ShowDialog();
            Close();
        }
    }
}

