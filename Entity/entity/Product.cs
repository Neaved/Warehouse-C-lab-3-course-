using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.entity
{
    public class Product
    {
        private string classofProduct;
        private string category;
        private string type;
        private string name;

        public Product(string classofpr, string category, string type, string name)
        {
            this.classofProduct = classofpr;
            this.category = category;
            this.type = type;
            this.name = name;

        }

        public string ClassofProduct
        {
            get
            {
                return classofProduct;
            }

            set
            {
                classofProduct = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }



        public override int GetHashCode()
        {
            return classofProduct.GetHashCode() * category.GetHashCode() * type.GetHashCode() * name.GetHashCode() * 19;

        }
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Product product = (Product)obj;
            if (classofProduct == null)
                return (null == product.ClassofProduct);
            if (!classofProduct.Equals(product.ClassofProduct)) return false;
            if (category == null)
                return (product.Category == null);
            if (!category.Equals(product.Category)) return false;
            if (type == null)
                return (null == product.Type);
            if (!Type.Equals(product.Type)) return false;
            if (name == null)
                return (null == product.Name);
            return name.Equals(product.Name);

        }

        public override string ToString()
        {
            int N1 = 21, N2 = 22;
            string Out;

            N1 -= Type.Length;
            Out = Type;
            Out = Space(Out, N1);

            N2 -= Name.Length;
            Out += Name;
            Out = Space(Out, N2);



            return Out;
        }

        private string Space(string Out, int N)
        {
            for (int i = 0; i < N; i++)
                Out += " ";

            return Out + "| ";

        }
    }
}
