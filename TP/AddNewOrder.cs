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
    public partial class AddNewOrder : Form
    {
        public AddNewOrder(string service)
        {
            InitializeComponent();
            refreshClass();
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            textBox5.Text = ClientManagerService.getInstance().getIdClienOrder();
            Text = service;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

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
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(ty);
        }


        private void createOrderbutton_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text.Equals("") || comboBox2.Text.Equals("") || comboBox3.Text.Equals("") || comboBox4.Text.Equals("") || textBox2.Text.Equals("")
                || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals(""))
            {
                Form err = new DialogWithOne_Buttom("Заполните все поля", Text);
                err.ShowDialog();
            }
            else
            {
                try
                {
                    double price = double.Parse(textBox6.Text);
                    int number = int.Parse(textBox3.Text);
                    if ((number < 1) || (price < 1))
                    {
                        if (number < 1)
                        {
                            Form err = new DialogWithOne_Buttom("Количество не может быть \nотрицательным либо равным нулю", Text);
                            err.ShowDialog();
                        }
                        if (price < 1)
                        {
                            Form err = new DialogWithOne_Buttom("Цена не может быть \nотрицательным либо равным нулю", Text);
                            err.ShowDialog();
                        }
                    }
                    else
                    {

                        ClientManagerService clientManagerService = ClientManagerService.getInstance();
                        if (clientManagerService.isExistId(int.Parse(textBox5.Text)))
                            new DialogWithOne_Buttom("Такой номер заказа уже существет", Text).ShowDialog();
                        else
                        {
                            clientManagerService.addClientOrder(int.Parse(textBox5.Text), comboBox1.Text,
                                comboBox2.Text, comboBox3.Text, comboBox4.Text,
                                int.Parse(textBox3.Text), textBox2.Text, textBox4.Text, double.Parse(textBox6.Text), DateTime.Parse(dateTimePicker1.Text));
                            Form createOrder = new DialogWithOne_Buttom("Заказ оформлен", Text);
                            createOrder.ShowDialog();
                            Close();

                        }


                    }
                }
                catch (Exception)
                {
                    Form err = new DialogWithOne_Buttom("Количество или Цена \nсостоит только из цифр", Text);
                    err.ShowDialog();
                }
            }
        }


        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
                comboBox4.Enabled = true;
                label10.Text = "На складе:";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox4.Text.Equals(""))
            {
                Product produc = new Product(comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text);

                label10.Text += (ClientManagerService.getInstance().getProductQuantity(produc)).ToString();

            }
        }
    }
}
