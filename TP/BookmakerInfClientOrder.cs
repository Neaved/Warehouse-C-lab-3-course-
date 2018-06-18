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

// флаг fromWho чтобы определить кто вызывает эту форму
// 1 - bookmaker
// 2 - storekeeper
// 3 - courier
// 4 - courierlist

namespace TP
{
    public partial class BookmakerInfClientOrder : Form
    {
        private ClientOrder currentOrder;
        private int fromWho;

        public BookmakerInfClientOrder(ClientOrder currentOrder, string service, int fromWho)
        {
            InitializeComponent();
            this.currentOrder = currentOrder;
            textBox1.Text = currentOrder.getId().ToString();
            textBox2.Text = currentOrder.Product.ClassofProduct;
            textBox3.Text = currentOrder.Product.Category;
            textBox4.Text = currentOrder.Product.Type;
            textBox5.Text = currentOrder.Product.Name;
            textBox6.Text = currentOrder.getQuantity().ToString();
            textBox7.Text = currentOrder.getCLient();
            textBox8.Text = currentOrder.getAddress();
            textBox9.Text = currentOrder.Price.ToString();
            dateTimePicker1.Text = currentOrder.Date.ToString();
            Text = service;
            this.fromWho = fromWho;
            if(fromWho == 1)
            {
                button1.Text = "Подтвердить";
            }
            if (fromWho == 2)
            {
                button1.Text = "Отправить Курьеру";
            }
            if(fromWho == 3)
            {
                button1.Text = "Добавить в Доставки";
                button3.Visible = true;
                button3.Text = "Пересобрать";
            }
            if(fromWho == 4)
            {
                button1.Text = "Доставлено";
                button3.Visible = true;
                button3.Text = "Отмена заказа";
            }
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            if (fromWho == 1)
            {
                BookmakerService.getInstance.pay(currentOrder);
                Form confirm = new DialogWithOne_Buttom("Оплата подтверждена", Text);
                confirm.ShowDialog();
            }
            if(fromWho == 2)
            {
                StoreKeeperService.getInstance.collectOrder(currentOrder);
                Form confirm = new DialogWithOne_Buttom("Заказ передан Курьеру", Text);
                confirm.ShowDialog();
            }
            if(fromWho == 3)
            {
                CourierService.getInstance.takeOrder(currentOrder);
                Form confirm = new DialogWithOne_Buttom("Заказ добавлен в Доставки", Text);
                confirm.ShowDialog();
            }
            if (fromWho == 4)
            {
                CourierService.getInstance.giveOrder(currentOrder);
                Form confirm = new DialogWithOne_Buttom("Доставлен", Text);
                confirm.ShowDialog();
            }
            Close();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addErrorbutton_Click(object sender, EventArgs e)
        {
            if (fromWho == 4)
            {
                CourierService.getInstance.deniedOrder(currentOrder);
                Form confirm = new DialogWithOne_Buttom("Заказ отклонен", Text);
                confirm.ShowDialog();
                Close();
            }
            if (fromWho == 3)
            {
                CourierService.getInstance.addInErrorList(currentOrder);
                Form confirm = new DialogWithOne_Buttom("Добавлен в список ошибочных", Text);
                confirm.ShowDialog();
                Close();
            }
        }
        
    }
}
