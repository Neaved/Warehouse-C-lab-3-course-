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
using Service.by.rfe.service.exception;

namespace TP
{
    public partial class MakeProviderOrder : Form
    {
       private ProviderOrder currentProviderOrder;
        public MakeProviderOrder(ProviderOrder currentProviderOrder, string servise)
        {
            InitializeComponent();
            this.currentProviderOrder = currentProviderOrder;
            textBox1.Text = currentProviderOrder.getId().ToString();
            textBox2.Text = currentProviderOrder.getQuantity().ToString();
            Text = servise;
            refresh();

        }

        public void refresh()
        {
            comboBox1.Items.Clear();

            foreach(Provider provider in ProviderManagerService.getInstance().ProviderList)
            {
                comboBox1.Items.Add(provider.Name);
            }
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || comboBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                Form err = new DialogWithOne_Buttom("Заполните все поля", Text);
                err.ShowDialog();
            }
            else
            {
                try
                {

                    int number = int.Parse(textBox1.Text);
                    if (number < 1)
                    {
                        Form err = new DialogWithOne_Buttom("Номер заказа не может быть\n отрицательным либо равным нулю", Text);
                        err.ShowDialog();
                    }
                    else
                    {
                        ProviderManagerService providerService = ProviderManagerService.getInstance();
                        providerService.makeOrder(int.Parse(textBox1.Text.Trim()), comboBox1.Text, int.Parse(textBox2.Text.Trim()), int.Parse(textBox3.Text.Trim()),DateTime.Parse(dateTimePicker1.Value.ToString()));

                        Form confirm = new DialogWithOne_Buttom("Захаз оформлен", Text);
                        confirm.ShowDialog();

                        Close();
                        Refresh();
                    }
                }
                catch (ServiceException)
                {
                    Form err = new DialogWithOne_Buttom("Кол-во заказанных товаров меньше требуемого", Text);
                    err.ShowDialog();
                }
                catch (Exception)
                {
                    Form err = new DialogWithOne_Buttom("Номер заказа состоит только из цифр", Text);
                    err.ShowDialog();
                }
            }
            
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
