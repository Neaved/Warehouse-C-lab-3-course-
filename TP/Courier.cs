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
    public partial class Courier : Form
    {
        private ClientOrder currentOrder;

        public Courier()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Start();
            
            tabControl1.TabPages[2].Text = DateTime.Now.ToShortDateString();

            refresh();
            refreshCourierList();
            
        }

        private void refresh()
        {
            //currentOrder = null;
            listBox2.Items.Clear();
            foreach (ClientOrder order in CourierService.getInstance.getClientOrders())
            {

                int N1 = 9, N2 = 14, N3 = 25, N4 = 25;
                string Out;
                N1 -= order.getId().ToString().Length;
                Out = order.getId().ToString();
                Out = Space(Out, N1);

                N2 -= order.getCLient().ToString().Length;
                Out += order.getCLient();
                Out = Space(Out, N2);

                N3 -= order.getAddress().Length;
                Out += order.getAddress();
                Out = Space(Out, N3);

                N4 -= order.Product.Name.Length;
                Out += order.Product.Name;
                Out = Space(Out, N4);

                listBox2.Items.Add(Out);

            }
        }

        private void refreshCourierList()
        {
            listBox4.Items.Clear();
            foreach (ClientOrder order in CourierService.getInstance.getCourierList())
            {

                int N1 = 9, N2 = 22, N3 = 40;
                string Out;
                N1 -= order.getId().ToString().Length;
                Out = order.getId().ToString();
                Out = Space(Out, N1);

                N2 -= order.getCLient().ToString().Length;
                Out += order.getCLient();
                Out = Space(Out, N2);

                N3 -= order.getAddress().Length;
                Out += order.getAddress();
                Out = Space(Out, N3);

                listBox4.Items.Add(Out);

            }
        }

        public string Space(string Out, int N)
        {
            for (int i = 0; i < N; i++)
                Out += " ";

            return Out + "| ";
        }

        //private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    TabPage tp = tabControl1.TabPages[e.Index];

        //    StringFormat sf = new StringFormat();
        //    sf.Alignment = StringAlignment.Center;  //optional

        //    // This is the rectangle to draw "over" the tabpage title
        //    RectangleF headerRect = new RectangleF(e.Bounds.X - 5, e.Bounds.Y + 2, e.Bounds.Width + 10, e.Bounds.Height + 4);

        //    // This is the default colour to use for the non-selected tabs
        //    SolidBrush sb = new SolidBrush(Color.WhiteSmoke);

        //    // This changes the colour if we're trying to draw the selected tabpage
        //    // if (tabControl1.SelectedIndex == e.Index)
        //    //   sb.Color = Color.Aqua;

        //    // Colour the header of the current tabpage based on what we did above
        //    g.FillRectangle(sb, e.Bounds);

        //    //Remember to redraw the text - I'm always using black for title text
        //    g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.Black), headerRect, sf);
        //}

        private void timer_Tick(object sender, EventArgs e)
        {
            refresh();
            refreshCourierList();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                Form confirmPay = new BookmakerInfClientOrder(currentOrder, Text, 3);
                confirmPay.ShowDialog();
               // currentOrder = null;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox2.GetItemText(listBox2.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ClientOrder order in CourierService.getInstance.getClientOrders())
                {

                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                    {
                        currentOrder = order;
                        break;
                    }


                }
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox2.GetItemText(listBox2.SelectedItem);

            if (!orderString.Equals(""))
            {
                foreach (ClientOrder order in CourierService.getInstance.getClientOrders())
                {

                    if (orderString.Split('|')[0].Trim().Equals(order.getId().ToString()))
                    {
                        currentOrder = order;
                        break;
                    }


                }
            }
        }

        private void listBox4_DoubleClick(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                Form confirmPay = new BookmakerInfClientOrder(currentOrder, Text, 4);
                confirmPay.ShowDialog();
               // currentOrder = null;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = e.TabPageIndex == 2;
        }
    }
}
