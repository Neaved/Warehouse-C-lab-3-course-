using Entity.entity;
using Queue.queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.by.rfe.service
{
   public class BookmakerService
    {
        private static BookmakerService instance = new BookmakerService();

        private BookmakerService() { }

        public static BookmakerService getInstance
        {
            get
            {
                return instance;
            }
        }
        public List<ClientOrder> getClientOrders()
        {
            List<ClientOrder> orders = new List<ClientOrder>();
            foreach(ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                if (order.getIsFull() && !order.getPayed())
                {
                    orders.Add(order);
                }
              
            }
            return orders;
        }
        public List<ProviderOrder> getProviderOrders()
        {
            List<ProviderOrder> orders = new List<ProviderOrder>();
            foreach (ProviderOrder order in ProviderOrderList.getInstance().Orders)
            {
                if (order.Provider!= null && !order.getPayed())
                {
                    orders.Add(order);
                }

            }
            return orders;
        }

       public void pay(Order order)
        {
            order.setPayed(true);
        }
    }
}
