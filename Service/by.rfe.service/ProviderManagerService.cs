using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Entity.entity;
using Queue.queue;
using Service.by.rfe.service.exception;

namespace Service.by.rfe.service
{
    public class ProviderManagerService
    {
        private static ProviderManagerService instance = new ProviderManagerService();
        private static List<Provider> providerList = new List<Provider>();
        static ProviderManagerService()
        {
            foreach (var providertxt in File.ReadAllLines("ProviderList.txt", Encoding.Default))
            {
                string[] providerAtributes = providertxt.Split('/');
                providerList.Add(new Provider(providerAtributes[0], providerAtributes[1], providerAtributes[2]));
            }
        }

        public void exportToExcel(string[] text)
        {
            Application  ExcelApp = new Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 25;
            ExcelApp.Cells[1,1] = "Класс";
            ExcelApp.Cells[1,2] = "Категория";
            ExcelApp.Cells[1,3] = "Тип";
            ExcelApp.Cells[1,4] = "Наименование";
            ExcelApp.Cells[1,5] = "Кол-во";

            foreach(Product product in Store.getInstance().Products.Keys)
            {
                for(int i = 0; i < text.Length - 1; i++)
                if (text[i].Trim().Equals(product.Name))
                {
                    ExcelApp.Cells[i+2, 1] = product.ClassofProduct;
                    ExcelApp.Cells[i+2, 2] = product.Category;
                    ExcelApp.Cells[i+2, 3] = product.Type;
                    ExcelApp.Cells[i+2, 4] = product.Name;
                    ExcelApp.Cells[i+2, 5] = getProductCount(product);
                }

            }
            ExcelApp.Visible = true;


        }

        public void exportToTxt(string file, string[] text)
        {
            string Out = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i != text.Length - 1)
                    Out += text[i].Trim() + '/';
                else
                    Out += text[i].Trim();
            }

            using (StreamWriter write = new StreamWriter(file, true, Encoding.Default))
            {
                write.WriteLine(Out);
            }
        }

        public void clearTxt(string file)
        {
            StreamWriter write = new StreamWriter(file, false, Encoding.Default);
            write.Close();
        }

        public List<Provider> ProviderList
        {
            get
            {
                return providerList;
            }
        }

        public static ProviderManagerService getInstance()
        {
            return instance;
        }

        public List<ProviderOrder> getProviderOrders()
        {
            ProviderOrderList list = ProviderOrderList.getInstance();
            return list.Orders;
        }

        public void makeOrder(int id, string name, int quantity, double price, DateTime data)
        {
            Provider provider = findProviderByName(name);
            ProviderOrderList providerOrderList = ProviderOrderList.getInstance();
            List<ProviderOrder> orders = providerOrderList.Orders;
            foreach (ProviderOrder or in orders)
            {
                if (or.getId().Equals(id))
                {

                    if (or.getQuantity() <= quantity)
                        or.setQuantity(quantity);
                    else
                    {
                        throw new ServiceException();
                    }
                    or.Provider = provider;
                    or.Price = price;
                    or.Date = data;

                }
            }
        }

        public bool deleteProvider(Provider provider)
        {
            foreach (ProviderOrder order in ProviderOrderList.getInstance().Orders)
            {
                if (order.Provider == provider)
                    return false;
            }
            ProviderList.Remove(provider);
            return true;
        }

        public void addProvider(string name, string adress, string phoneNumber)
        {
            Provider provider = new Provider(name, adress, phoneNumber);
            providerList.Add(provider);
        }

        public void addNewOrder(Product product, int quantity, double price, string providerName, DateTime data)
        {
            Provider provider = findProviderByName(providerName);
            ProviderOrder order = new ProviderOrder();
            order.setId(ProviderOrderList.getInstance().generateId());
            order.Product = product;
            order.setQuantity(quantity);
            order.Price = price;
            order.Provider = provider;
            order.Date = data;
            ProviderOrderList.getInstance().addProviderOrder(order);
        }
        private Provider findProviderByName(string name)
        {
            Provider provider = null;
            foreach (Provider prov in ProviderList)
            {
                if (prov.Name.Equals(name))
                    provider = prov;
            }
            return provider;
        }
        public void removeProviderOrder(ProviderOrder order)
        {
            ProviderOrderList.getInstance().Orders.Remove(order);
        }
        public Dictionary<Product, int> getProducts()
        {
            return Store.getInstance().Products;
        }
        public void deleteProduct(Product product)
        {
            Store.getInstance().Products.Remove(product);
        }
        public void addNewProduct(Product product)
        {
            foreach (Product pr in Store.getInstance().Products.Keys)
            {
                if (pr.Equals(product))
                {
                    throw new ServiceException("Такой товар уже \n существует");
                }
            }
            Store.getInstance().Products.Add(product, 0);
        }
        public int getProductCount(Product product)
        {
            int count = 0;
            Store.getInstance().Products.TryGetValue(product, out count);
            return count;
        }
        public void changeProduct(Product product, Product change, int count, string name)
        {
           
            foreach (Product pr in Store.getInstance().Products.Keys)
            {
                Store.getInstance().Products.Remove(product);
                Store.getInstance().Products.Add(change, count);
                return;
            }
        }
    }
}
