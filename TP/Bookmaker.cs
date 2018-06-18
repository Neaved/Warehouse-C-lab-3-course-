using Entity.entity;
using Service.by.rfe.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP
{
    public partial class Bookmaker : Form
    {
        private Order currentOrder;
        public Bookmaker()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Start();
            label2.Text = DateTime.Now.ToShortDateString();
            refresh();
        }

        void refresh()
        {
            currentOrder = null;

            listBox2.Items.Clear();
            foreach (ClientOrder order in BookmakerService.getInstance.getClientOrders())
            {
                
                    int N1 = 9, N2 = 16, N3 = 25, N4 = 25;
                    string Out;
                    N1 -= order.getId().ToString().Length;
                    Out = order.getId().ToString();
                    Out = Space(Out, N1);

                    N2 -= "По клиентам".Length;
                    Out += "По клиентам";
                    Out = Space(Out, N2);

                    N3 -= order.getCLient().ToString().Length;
                    Out += order.getCLient();
                    Out = Space(Out, N3);

                    N4 -= order.Product.Name.Length;
                    Out += order.Product.Name;
                    Out = Space(Out, N4);

                    listBox2.Items.Add(Out);
            }

            foreach (ProviderOrder order in BookmakerService.getInstance.getProviderOrders())
            {
                
                    int N1 = 9, N2 = 16, N3 = 25, N4 = 25;
                    string Out;
                    N1 -= order.getId().ToString().Length;
                    Out = order.getId().ToString();
                    Out = Space(Out, N1);

                    N2 -= "По поставщикам".Length;
                    Out += "По поставщикам";

                    Out = Space(Out, N2);

                    N3 -= order.Provider.Name.Length;
                    Out += order.Provider.Name;
                    Out = Space(Out, N3);

                    N4 -= order.Product.Name.Length;
                    Out += order.Product.Name;
                    Out = Space(Out, N4);

                  
                    listBox2.Items.Add(Out);
            }
        }

        public string Space(string Out, int N)
        {
            for (int i = 0; i < N; i++)
                Out += " ";

            return Out + "| ";
        }


        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                if (currentOrder.GetType().IsAssignableFrom(new ClientOrder().GetType()))
                {
                    Form confirmPay = new BookmakerInfClientOrder((ClientOrder)currentOrder, Text, 1);
                    confirmPay.ShowDialog();
                }
               else if (currentOrder.GetType().IsAssignableFrom(new ProviderOrder().GetType()))
                {
                    Form confirmPay = new BookmakerInfProviderOrder((ProviderOrder)currentOrder, Text, 1);
                    confirmPay.ShowDialog();
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox2.GetItemText(listBox2.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ProviderOrder order in BookmakerService.getInstance.getProviderOrders())
                {
                    if (orderString.Split('|')[1].Trim().Equals("По поставщикам"))
                    {
                        if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                        {
                            currentOrder = order;
                            break;
                        }

                    }
                }
                foreach (ClientOrder order in BookmakerService.getInstance.getClientOrders())
                {
                    if (orderString.Split('|')[1].Trim().Equals("По клиентам"))
                    {
                        if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                        {
                            currentOrder = order;
                            break;
                        }

                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        
    }
}
