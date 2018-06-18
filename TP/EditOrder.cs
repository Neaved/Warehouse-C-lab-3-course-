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
    public partial class EditOrder : Form
    {
        private ClientOrder currentOrder;
        public EditOrder(ClientOrder currentOrder, string service)
        {
            InitializeComponent();
            this.currentOrder = currentOrder; 
            textBox3.Text = currentOrder.getId().ToString();
            comboBox1.Text = currentOrder.Product.ClassofProduct;
            comboBox2.Text = currentOrder.Product.Category;
            comboBox3.Text = currentOrder.Product.Type;
            textBox1.Text = currentOrder.Product.Name;
            textBox2.Text = currentOrder.getQuantity().ToString();
            textBox4.Text = currentOrder.getCLient();
            textBox5.Text = currentOrder.getAddress();
            dateTimePicker1.Text = currentOrder.Date.ToString();
            if (ClientManagerService.getInstance().isDeliver(currentOrder))
            {
                button1.Enabled = false;
                textBox5.Enabled = false;
            }
            Text = service;
        }
        private void editbutton_Click(object sender, EventArgs e)
        {
            ClientManagerService.getInstance().editOrder(int.Parse(textBox3.Text), textBox5.Text);
            Form editOrder = new DialogWithOne_Buttom("Заказ изменён", Text);
            editOrder.ShowDialog();

            Close();
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            ClientManagerService.getInstance().deleteOrder(currentOrder);
           

            Form deleteOrder = new DialogWithOne_Buttom("Заказ удален", Text);
            deleteOrder.ShowDialog();
            
            Close();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
