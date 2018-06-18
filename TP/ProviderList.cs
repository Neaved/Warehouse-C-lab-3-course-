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
    public partial class ProviderList : Form
    {
        private Provider currentProvider;
        public ProviderList(string service)
        {
            InitializeComponent();
            Text = service;
            refresh();
        }
        public void refresh()
        {
            listBox1.Items.Clear();
            foreach (Provider provider in ProviderManagerService.getInstance().ProviderList)
            {
                listBox1.Items.Add(provider.ToString());
            }
        }
        private void cancelbutton_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string providerString = listBox1.GetItemText(listBox1.SelectedItem);

            if (!providerString.Equals(""))
            {
                foreach (Provider provider in ProviderManagerService.getInstance().ProviderList)
                {
                    if (providerString.Split('|')[0].Trim().Equals(provider.Name))
                    {
                       currentProvider = provider;
                        break;
                    }
                }
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (currentProvider != null)
            {
                Form editProvider = new EditProvider(currentProvider, Text);
                editProvider.ShowDialog();
                refresh();
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            Form addProvider = new AddNewProvider(Text);
            addProvider.ShowDialog();
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProviderManagerService.getInstance().clearTxt("ProviderList.txt");
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string[] provider = listBox1.Items[i].ToString().Split('|');
                ProviderManagerService.getInstance().exportToTxt("ProviderList.txt", provider);
            }
            Form confirm = new DialogWithOne_Buttom("Список Поставщиков Сохранен", Text);
            confirm.ShowDialog();
        }
    }
}
