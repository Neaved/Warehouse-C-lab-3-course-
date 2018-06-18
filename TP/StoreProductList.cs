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
    public partial class StoreProductList : Form
    {
        //будем в списке отображать объект класса Product?
        private Product currentProduct;
        public StoreProductList(string service)
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
            Text = service;
            refresh();
        }
        void refresh()
        {
            listBox2.Items.Clear();
            Dictionary<Product, int> products = ProviderManagerService.getInstance().getProducts();
            foreach (Product pr in products.Keys)
            {
                int count = 0;
                products.TryGetValue(pr, out count);
                listBox2.Items.Add(pr + count.ToString());
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            Form add = new ProductInf(Text,1);
            add.ShowDialog();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderString = listBox2.GetItemText(listBox2.SelectedItem);

            if (!orderString.Equals(""))
            {
              //  поиск по скаду через Сервис Поставщика выбранного товара
                foreach (Product product in ProviderManagerService.getInstance().getProducts().Keys)
                {
                    if (orderString.Split('|')[1].Trim().Equals(product.Name))
                    {
                        currentProduct = product;
                        break;
                    }
                }
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (currentProduct != null)
            {
                Form edit = new ProductInf(currentProduct, Text, 2);
                edit.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] product = new string[listBox2.Items.Count];

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                string[] str = listBox2.Items[i].ToString().Split('|');
                product[i] = str[1].Trim();

            }

            ProviderManagerService.getInstance().exportToExcel(product);


            Form confirm = new DialogWithOne_Buttom("Список Товаров \nконвертирован в Excel", Text);
            confirm.ShowDialog();

        }
    }
}
