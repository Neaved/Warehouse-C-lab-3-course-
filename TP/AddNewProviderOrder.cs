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
    public partial class AddNewProviderOrder : Form
    {
        public AddNewProviderOrder(string service)
        {
            InitializeComponent();
            Text = service;
            refreshClass();
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox5.Enabled = false;
            comboBox4.Items.Clear();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();

            foreach (Provider provider in ProviderManagerService.getInstance().ProviderList)
            {
                comboBox4.Items.Add(provider.Name);
            }
        }
        void refreshClass()
        {
            ClientManagerService clientManagerService = ClientManagerService.getInstance();
            HashSet<string> classs = clientManagerService.getClass();
            string[] cl = classs.ToArray<string>();
            comboBox1.Items.AddRange(cl);

        }
        void refreshCategory()
        {
            ClientManagerService clientManagerService = ClientManagerService.getInstance();
            HashSet<string> categories = clientManagerService.getCategories(comboBox1.Text);
            string[] cat = categories.ToArray<string>();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(cat);
        }

        void refreshType()
        {
            ClientManagerService clientManagerService = ClientManagerService.getInstance();
            HashSet<string> types = clientManagerService.getTypes(comboBox2.Text);
            string[] ty = types.ToArray<string>();
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(ty);
        }
        void refreshName()
        {
            ClientManagerService clientManagerService = ClientManagerService.getInstance();
            HashSet<string> names = clientManagerService.getNames(comboBox3.Text);
            string[] ty = names.ToArray<string>();
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(ty);
        }
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createProviderOrderbutton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("") || comboBox2.Text.Equals("") || comboBox3.Text.Equals("") || comboBox5.Text.Equals("") || textBox3.Text.Equals(""))
            {
                Form err = new DialogWithOne_Buttom("Заполните все поля", Text);
                err.ShowDialog();
            }
            else
            {
                try
                {
                    int number = int.Parse(textBox2.Text);
                    double price = double.Parse(textBox3.Text);
                    if ((number < 1) || (price < 1))
                    {
                        if (number < 1)
                        {
                            Form err = new DialogWithOne_Buttom("Количество не может быть \nотрицательным либо равным нулю", Text);
                            err.ShowDialog();
                        }

                        else
                        {
                            Form err = new DialogWithOne_Buttom("Цена не может быть \nотрицательной либо равной нулю", Text);
                            err.ShowDialog();
                        }
                    }
                    else
                    {
                        ProviderManagerService providerService = ProviderManagerService.getInstance();
                        Product product = new Product(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox5.Text);
                        providerService.addNewOrder(product, int.Parse(textBox2.Text), double.Parse(textBox3.Text),comboBox4.Text,DateTime.Parse(dateTimePicker1.Value.ToString()));
                        Form createOrder = new DialogWithOne_Buttom("Заказ оформлен", Text);
                        createOrder.ShowDialog();

                        Close();
                    }
                }
                catch (Exception)
                {

                    Form err = new DialogWithOne_Buttom("Количество или Цена состоит только из цифр", Text);
                    err.ShowDialog();

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(""))
            {
                refreshCategory();
                comboBox2.Enabled = true;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox2.Text.Equals(""))
            {
                refreshType();
                comboBox3.Enabled = true;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox3.Text.Equals(""))
            {
                refreshName();
                comboBox5.Enabled = true;
            }
        }


    }
}
