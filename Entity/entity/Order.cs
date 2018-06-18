using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.entity
{
  public class Order
    {
        private int id;
        private int quantity;
        private bool isPayed;
        private Product product;
        private double price;
        private DateTime date;
        public Order(int id, Product product, int quantity, double price, DateTime date)
        {
            this.id = id;
            this.product = product;
            this.quantity = quantity;
            this.isPayed = false;
            this.price = price;
            this.Date = date;
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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
    }
}
