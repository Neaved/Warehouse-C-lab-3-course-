using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.entity;

namespace Queue.queue
{
    public class ClientOrderList 
    {
        private static ClientOrderList instance = new ClientOrderList();
        private List<ClientOrder> orders = new List<ClientOrder>();

        private ClientOrderList()
        {

            orders.Add(new ClientOrder(1,  
                new Product("Продовольственные товары", "Категория1", "Тип1", "Имя1"),
                5, "Клиент11", "Адрес1", true, 0, 18, DateTime.Parse("18.12.2016")));
            orders.Add(new ClientOrder(2, 
                new Product("Продовольственные товары", "Категория2", "Тип2", "Имя2"),
                10, "Клиент2", "Адрес2", true, 0, 20, DateTime.Parse("19.12.2016")));
            orders.Add(new ClientOrder(6, 
                new Product("Продовольственные товары", "Категория4", "Тип4", "Имя4"),
                7, "Клиент4", "Адрес4", true, 0, 12, DateTime.Parse("19.12.2016")));
            orders.Add(new ClientOrder(4,  
                new Product("Продовольственные товары", "Категория5", "Тип4", "Имя4"),
                70, "Клиент4", "Адрес3", true, 0, 12, DateTime.Parse("19.12.2016")));
            orders.Add(new ClientOrder(5, 
                new Product("Промышленные товары", "Категория5", "Тип5", "Имя5"),
                3, "Клиент6", "Адрес5", true, 0, 14, DateTime.Parse("19.12.2016")));
        }

        public List<ClientOrder> Orders
        {
            get
            {
                return orders;
            }

        }

        public void addClientOrder(ClientOrder order)
        {
            orders.Add(order);
        }

        public static ClientOrderList getInstance()
        {
            return instance;
        }
    }
}
