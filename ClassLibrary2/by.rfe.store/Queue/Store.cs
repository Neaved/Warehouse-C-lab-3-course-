using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.by.rfe.store.Entity;


namespace ClassLibrary.by.rfe.store.Queue
{
   public class Store //это склад, здесь таблицы(словари)(Dictionary) продуктов
    {
        private Dictionary<Product, int> products = new Dictionary<Product, int>();
        private static  Store instance = new Store(); // создаем экземпляр этого же класса 
                                                // что бы в последствии получить доступ к полю products
        private Store()
        {
            //делаем приватный конструктор, что бы нигде кроме этого класса нельзя было создать объект Store
            products.Add(new Product("Промышленные", "бытовая техника", "холодильники", "samsung"), 18);
            products.Add(new Product("Промышленные", "бытовая техника", "холодильники", "lg"), 2);
            products.Add(new Product("Промышленные", "бытовая техника", "телевизоры", "sony"), 10);
            products.Add(new Product("Промышленные", "бытовая техника", "телевизоры", "horizont"), 15);
            products.Add(new Product("Промышленные", "спорт товары", "лыжи", "телеханы"), 23);
            products.Add(new Product("Продуктовые", "молочные", "йогурты", "ёмми"), 7);
            products.Add(new Product("Продуктовые", "кондитерские", "шоколад", "аленка"), 90);
            products.Add(new Product("Продуктовые", "кондитерские", "конфеты", "столичные"), 8);
            
        }                           
        public Dictionary<Product, int> Products
        {
            get
            {
                return products;
            }

        }
            
        public void addProduct(Product pr, int quantuty)
        {
            int count = 0;
            products.TryGetValue(pr, out count);
            products.Remove(pr);
            products.Add(pr, quantuty + count);
        }
        public static Store getInstance()
        {
            return instance;//т.к. поле instance - private, для обращения к нему нужен паблик метод. 
                            //т.е. мы сначала вызываем метод getInstance (сделали его статическим то бы можно было
                            //вызывать этот метод не на объекте, а чере имя класса (Store.getInstance();) - 
                            // и тогда мы получим объект класса Store. т.е. Store store = Store.getInstance();
                            // и потом уже можем через объект store можем обращаться к ост. методам:
                            // store.addProduct(product, quantity);
                            //в остальных классах по аналогии
        }

    }
}
