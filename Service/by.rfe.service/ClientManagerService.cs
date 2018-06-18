using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.by.rfe.service.exception;
using Entity.entity;
using Queue.queue;

namespace Service.by.rfe.service
{
    public class ClientManagerService
    {
        private static ClientManagerService instance = new ClientManagerService();

        private ClientManagerService()
        {

        }

        public static ClientManagerService getInstance()
        {
            return instance;
        }

        public List<ClientOrder> getClientOrders()
        {
            return ClientOrderList.getInstance().Orders;
        }

        public void addClientOrder(int id, string classofProd, string category, string type, string name, int quantity, string clientName, string clientAddress, double price, DateTime date)
        {
            Product product = new Product(classofProd, category, type, name);
            Store store = Store.getInstance();
            int count = 0;
            if (!store.Products.TryGetValue(product, out count))
            {
                throw new ServiceException("Не найдено такого проудкта");
            }
            if (count > quantity)
            {
                count = count - quantity;
                store.Products.Remove(product);
                store.Products.Add(product, count);
                ClientOrderList clientorderList = ClientOrderList.getInstance();
                clientorderList.addClientOrder(new ClientOrder(id, product, quantity, clientName, clientAddress, true, 0, price, date));
                return;
            }
            if (count < quantity)
            {
                count = quantity - count;
                store.Products.Remove(product);
                store.Products.Add(product, 0);
                ClientOrderList clientorderList = ClientOrderList.getInstance();
                ClientOrder clientOrder = new ClientOrder(id, product, quantity, clientName, clientAddress, false, count, price, date);
                clientorderList.addClientOrder(clientOrder);
                ProviderOrderList providerOrderList = ProviderOrderList.getInstance();
                ProviderOrder providerOrder = new ProviderOrder(providerOrderList.generateId(), product, count, 0, date);
                providerOrder.ClientOrder = clientOrder;
                providerOrderList.addProviderOrder(providerOrder);
                return;
            }

            if (count == quantity)
            {
                count = quantity - count;
                store.Products.Remove(product);
                store.Products.Add(product, 0);
                ClientOrderList clientorderList = ClientOrderList.getInstance();
                clientorderList.addClientOrder(new ClientOrder(id, product, quantity, clientName, clientAddress, true, 0, price, date));
                return;
            }
        }

        public HashSet<string> getClass()
        {
            Store store = Store.getInstance();
            HashSet<string> classs = new HashSet<string>();

            foreach (Product product in store.Products.Keys)
            {
                classs.Add(product.ClassofProduct.Trim());
            }

            return classs;
        }
        public HashSet<string> getCategories(string classofprod)
        {
            Store store = Store.getInstance();
            HashSet<string> categories = new HashSet<string>();

            foreach (Product product in store.Products.Keys)
            {
                if (product.ClassofProduct == classofprod)
                    categories.Add(product.Category.Trim());
            }

            return categories;
        }

        public HashSet<string> getTypes(string category)
        {
            Store store = Store.getInstance();
            HashSet<string> types = new HashSet<string>();

            foreach (Product product in store.Products.Keys)
            {
                if (product.Category == category)
                    types.Add(product.Type.Trim());
            }

            return types;
        }
        public HashSet<string> getNames(string type)
        {
            Store store = Store.getInstance();
            HashSet<string> names = new HashSet<string>();

            foreach (Product product in store.Products.Keys)
            {
                if (product.Type == type)
                    names.Add(product.Name.Trim());
            }

            return names;
        }

        public bool isExistId(int id)
        {
            ClientOrderList orders = ClientOrderList.getInstance();
            foreach (ClientOrder order in orders.Orders)
            {
                if (order.getId() == id)
                {
                    return true;
                }
            }
            return false;
        }
        public void editOrder(int id, string address)
        {
            ClientOrderList clientOrderlist = ClientOrderList.getInstance();
            ClientOrder editedOrder = null;
            foreach (ClientOrder order in clientOrderlist.Orders)
            {
                if (order.getId() == id)
                    editedOrder = order;
            }
            if (editedOrder != null)
            {
                editedOrder.setAddress(address);
            }

        }

        public void deleteOrder(ClientOrder clientOrder)
        {
            if (clientOrder.getStatus().Equals("Доставлено") || clientOrder.getStatus().Equals("Заказ отклонен"))
            {
                ClientOrderList.getInstance().Orders.Remove(clientOrder);
                return;
            }
            if (clientOrder.getIsFull())
            {
                int count = 0;
                Store.getInstance().Products.TryGetValue(clientOrder.Product, out count);
                Store.getInstance().Products.Remove(clientOrder.Product);
                Store.getInstance().Products.Add(clientOrder.Product, count + clientOrder.getQuantity());
            }
            else
            {
                int count = 0;
                Store.getInstance().Products.TryGetValue(clientOrder.Product, out count);
                Store.getInstance().Products.Remove(clientOrder.Product);
                Store.getInstance().Products.Add(clientOrder.Product, count + clientOrder.getQuantity() - clientOrder.getCountToEnd());
            }
            ClientOrderList.getInstance().Orders.Remove(clientOrder);

        }


        public string getIdClienOrder()
        {
            int maxId = 0;
            foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                if (order.getId() > maxId)
                {
                    maxId = order.getId();
                }
            }
            maxId++;
            return maxId.ToString();
        }

        public string showFindOrder(string client)
        {
            string Out = null;
            foreach (ClientOrder order in ClientOrderList.getInstance().Orders)
            {
                if (order.getCLient() == client)
                {
                    Out += order.ToString() + '/';
                }
            }
            if (Out != null)
                return Out;
            else return null;
        }

        public int getProductQuantity(Product product)
        {
            int a = 0;
            Store.getInstance().Products.TryGetValue(product, out a);
            return a;
        }

        public bool isDeliver(ClientOrder clientOrder)
        {
            if (clientOrder.getStatus().Equals("Доставлено"))
            {
                return true;
            }
            else return false;

        }

    }
}
