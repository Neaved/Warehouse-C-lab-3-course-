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
    public partial class StoreKeeper : Form
    {
        private Order currentOrder;

        public StoreKeeper()
        {
            InitializeComponent();
            timerProvider.Interval = 1000;
            timerClient.Enabled = true;
            timerProvider.Enabled = true;
            timerError.Enabled = true;
            timerClient.Start();
            timerProvider.Start();
            timerError.Start();

            tabControl1.TabPages[3].Text = DateTime.Now.ToShortDateString();


            refreshClient();
            refreshProvider();
            refreshError();

        }

        private void refreshClient()
        {
          //  currentOrder = null;
            listBox4.Items.Clear();
            foreach (ClientOrder order in StoreKeeperService.getInstance.getClientOrders())
            {

                int N1 = 9, N2 = 21, N3 = 40;
                string Out;
                N1 -= order.getId().ToString().Length;
                Out = order.getId().ToString();
                Out = Space(Out, N1);

                N2 -= order.getCLient().ToString().Length;
                Out += order.getCLient();
                Out = Space(Out, N2);

                N3 -= order.Product.Name.Length;
                Out += order.Product.Name;
                Out = Space(Out, N3);

                listBox4.Items.Add(Out);

            }


        }

        private void refreshProvider()
        {
           // currentOrder = null;
            listBox6.Items.Clear();
            foreach (ProviderOrder order in StoreKeeperService.getInstance.getProviderOrders())
            {

                int N1 = 9, N2 = 21, N3 = 40;
                string Out;
                N1 -= order.getId().ToString().Length;
                Out = order.getId().ToString();
                Out = Space(Out, N1);

                N2 -= order.Provider.Name.Length;
                Out += order.Provider.Name;
                Out = Space(Out, N2);

                N3 -= order.Product.Name.Length;
                Out += order.Product.Name;
                Out = Space(Out, N3);


                listBox6.Items.Add(Out);

            }
        }

        private void refreshError()
        {
            //currentOrder = null;
            listBox8.Items.Clear();
            foreach (ClientOrder order in StoreKeeperService.getInstance.getErrorList())
            {

                int N1 = 9, N2 = 21, N3 = 40;
                string Out;
                N1 -= order.getId().ToString().Length;
                Out = order.getId().ToString();
                Out = Space(Out, N1);

                N2 -= order.getCLient().ToString().Length;
                Out += order.getCLient();
                Out = Space(Out, N2);

                N3 -= order.Product.Name.Length;
                Out += order.Product.Name;
                Out = Space(Out, N3);

                listBox8.Items.Add(Out);

            }
        }

        public string Space(string Out, int N)
        {
            for (int i = 0; i < N; i++)
                Out += " ";

            return Out + "| ";
        }

        private void timerClient_Tick(object sender, EventArgs e)
        {
            int count0 = listBox4.Items.Count; //чтобы тестить ставь ==

            refreshClient(); //может сделать задержку?
            if ((count0 != listBox4.Items.Count) && (-count0 + listBox4.Items.Count > 0))
            {
                string msg = "Проверте список Заказов! \nДобавлено " + (listBox4.Items.Count - count0).ToString() + " новых заказов";
                count0 = listBox4.Items.Count;
                Form info = new DialogWithOne_Buttom(msg, Text);
                info.Show();
            }
        }

        private void timerProvider_Tick(object sender, EventArgs e)
        {

            int count0 = listBox6.Items.Count; //чтобы тестить ставь ==
            refreshProvider();
            if ((count0 != listBox6.Items.Count) && (-count0 + listBox6.Items.Count > 0))
            {
                string msg = "Проверте список Доставок! \nДобавлено " + (listBox6.Items.Count - count0).ToString() + " новых заказов";
                Form info = new DialogWithOne_Buttom(msg, Text);
                info.Show();
            }
        }

        private void timerError_Tick(object sender, EventArgs e)
        {
            int count0 = listBox8.Items.Count; //чтобы тестить ставь ==
            refreshError();
            if ((count0 != listBox8.Items.Count) && (-count0 + listBox8.Items.Count > 0))
            {
                string msg = "Проверте список Ошибок! \nДобавлено " + (listBox8.Items.Count - count0).ToString() + " новых заказов";
                Form info = new DialogWithOne_Buttom(msg, Text);
                info.Show();
            }
        }

        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                Form confirmPay = new BookmakerInfClientOrder((ClientOrder)currentOrder, Text, 2);
                confirmPay.ShowDialog();
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox4.GetItemText(listBox4.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ClientOrder order in StoreKeeperService.getInstance.getClientOrders())
                {

                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                    {
                        currentOrder = order;
                        break;
                    }


                }
            }
        }

        private void listBox6_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                Form confirmPay = new BookmakerInfProviderOrder((ProviderOrder)currentOrder, Text, 2);
                confirmPay.ShowDialog();
            }

        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox6.GetItemText(listBox6.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ProviderOrder order in StoreKeeperService.getInstance.getProviderOrders())
                {
                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                    {
                        currentOrder = order;
                        break;
                    }
                }
            }
        }

        private void listBox8_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                Form confirmPay = new BookmakerInfClientOrder((ClientOrder)currentOrder, Text, 2);
                confirmPay.ShowDialog();
            }
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox8.GetItemText(listBox4.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ClientOrder order in StoreKeeperService.getInstance.getErrorList())
                {

                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                    {
                        currentOrder = order;
                        break;
                    }


                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = e.TabPageIndex == 3;
        }
    }
}
