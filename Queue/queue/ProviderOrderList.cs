using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.entity;

namespace Queue.queue
{
   public class ProviderOrderList //хранилище заказов поставшиков
    {
        private static ProviderOrderList instance = new ProviderOrderList();
        private List<ProviderOrder> orders = new List<ProviderOrder>();

        private ProviderOrderList()
        {
            orders.Add(new ProviderOrder(2, 
                new Product("Класс1", "Категория1", "Тип1", "Продукт1"), 5, 124, DateTime.Parse("19.12.2016")));
            orders.Add(new ProviderOrder(5, 
               new Product("Класс2", "Категория4", "Тип4", "Продукт2"), 7,127, DateTime.Parse("19.12.2016")));

        }
        public int generateId()
        {
            List<int> list = new List<int>();
            foreach (ProviderOrder order in orders)
            {
                list.Add(order.getId());
            }
            if (list.Count == 0)
            {
                return 1;
            }
            else
            {
                return list.Max() + 1;
            }
        }
        public List<ProviderOrder> Orders
        {
            get
            {
                return orders;
            }

        }

        public void addProviderOrder(ProviderOrder order)
        {
            orders.Add(order);
        }

        public static ProviderOrderList getInstance()
        {
            return instance;
        }
    }
}
