using Entity.entity;
using Queue.queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.by.rfe.service
{
    public class CourierService
    {
        private static CourierService instance = new CourierService();

        private CourierService() { }
        public static CourierService getInstance
        {
            get
            {
                return instance;
            }
        }

        public List<ClientOrder> getClientOrders()
        {
            List<ClientOrder> orders = new List<ClientOrder>();
            foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                if (order.IsReady && !order.IsOnWay &&!order.InErrorList)
                    orders.Add(order);
            }
            return orders;
        }
        public void takeOrder(ClientOrder order)
        {
            order.IsOnWay = true;
        }
        public List<ClientOrder> getCourierList()
        {
            List<ClientOrder> orders = new List<ClientOrder>();
            foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                if (order.IsOnWay && !order.IsDelivered &&!order.IsDenied)
                    orders.Add(order);
            }
            return orders;
        }
        public void giveOrder(ClientOrder order)
        {
            order.IsDelivered = true; 
        }
        public void addInErrorList(ClientOrder order)
        {
            order.InErrorList = true;
        }
        public void deniedOrder(ClientOrder order)
        {
            order.IsDenied = true;
            int count = 0;
            Store.getInstance().Products.TryGetValue(order.Product, out count);
            Store.getInstance().addProduct(order.Product, count + order.getQuantity());
        }

    }
}
