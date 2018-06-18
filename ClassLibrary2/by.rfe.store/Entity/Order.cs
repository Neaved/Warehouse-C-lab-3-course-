using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.by.rfe.store.Entity
{
  public class Order
    {
        private int id;
        private int quantity;
        private bool isPayed;
        private Product product;
        private double price;
  
        public Order(int id, Product product, int quantity, double price)
        {
            this.id = id;
            this.product = product;
            this.quantity = quantity;
            this.isPayed = false;
            this.price = price;
        }
        public Order() { }
        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getQuantity()
        {
            return this.quantity;
        }
        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
        public bool getPayed()
        {
            return this.isPayed;
        }
        public void setPayed(bool payed)
        {
            this.isPayed = payed;
        }
        public Product Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
