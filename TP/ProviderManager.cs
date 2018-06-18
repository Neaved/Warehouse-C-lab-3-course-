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
using Queue.queue;

namespace TP
{
    public partial class ProviderManager : Form
    {
        private ProviderOrder currentProviderOrder;
        public ProviderManager()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Start();
            label1.Text = DateTime.Now.ToShortDateString();

            refresh();
        }
        public void refresh()
        {
            currentProviderOrder = null;
            listBox1.Items.Clear();
            ProviderManagerService service = ProviderManagerService.getInstance();
            foreach (ProviderOrder or in service.getProviderOrders())
                listBox1.Items.Add(or);
        }

        private void addNewbutton_Click(object sender, EventArgs e)
        {
            Form addNew = new AddNewProviderOrder(Text);
            addNew.ShowDialog();
        }

        private void listProviderbutton_Click(object sender, EventArgs e)
        {
            Form list = new ProviderList(Text);
            list.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox1.GetItemText(listBox1.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ProviderOrder order in ProviderOrderList.getInstance().Orders)
                {
                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                    {
                        currentProviderOrder = order;
                        break;
                    }
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (currentProviderOrder != null)
            {
                if (currentProviderOrder.Provider == null)
                {
                    Form add = new MakeProviderOrder(currentProviderOrder, Text);
                    add.ShowDialog();
                }
                else
                {
                    Form edit = new BookmakerInfProviderOrder(currentProviderOrder, Text, 3);
                    edit.ShowDialog();
                }
                refresh();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            Form store = new StoreProductList(Text);
            store.ShowDialog();
        }
    }
}
