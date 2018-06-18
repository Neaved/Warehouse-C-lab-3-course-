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
    public partial class ClientManager : Form
    {

        private ClientOrder currentOrder;
        public ClientManager()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            label2.Text = DateTime.Now.ToShortDateString();
            viewFindTextBox();
            
            refresh();
        }

        private void viewFindTextBox()
        {
            textBox1.Text = "Поиск";
            textBox1.ForeColor = Color.Gray;
        }
        public void refresh()
        {
            timer1.Start();
            currentOrder = null;
            listBox1.Items.Clear();
            foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                listBox1.Items.Add(order.ToString());
            }
        }

        private void refreshFind()
        {
            listBox1.Items.Clear();
            foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                listBox1.Items.Add(order.ToString());
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            Form addNew = new AddNewOrder(Text);
            addNew.ShowDialog();
            refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewFindTextBox();
            string orderString = listBox1.GetItemText(listBox1.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
                {
                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))//чувак, я тут переписал селект берем по id  а не по клиенту
                    {
                        currentOrder = order;
                        break;
                    }
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                Form editOrder = new EditOrder(currentOrder, Text);
                editOrder.ShowDialog();
                refresh();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string outPut = ClientManagerService.getInstance().showFindOrder(textBox1.Text);

                if (textBox1.Text.Equals(""))
                {
                    refreshFind();
                   
                }
                else if (outPut != null)
                {
                    timer1.Stop();
                    listBox1.Items.Clear();
                    string[] order = outPut.Split('/');
                    for (int i = 0; i < order.Length - 1; i++)
                        listBox1.Items.Add(order[i]);
                }
                else
                {
                    Form err = new DialogWithOne_Buttom("Проверте запрос на поиск", Text);
                    err.ShowDialog();
                }
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            refresh();
            viewFindTextBox();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
