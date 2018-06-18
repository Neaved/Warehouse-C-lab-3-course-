using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.by.rfe.store.Entity
{
 public class Provider
    {
        private string name;
        private string address;
        private string phoneNumber;

        public Provider(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public override string ToString()
        {
            int N1 = 15, N2 = 40, N3 = 13;
            string Out;

            N1 -= Name.Length;
            Out = Name;
            Out = Space(Out, N1, true);

            N2 -= Address.Length;
            Out += Address;
            Out = Space(Out, N2, true);

            N3 -= phoneNumber.ToString().Length;
            Out += phoneNumber.ToString();
            Out = Space(Out, N3, false);
           
            return Out;
        }
        public string Space(string Out, int N, bool flag)
        {
            for (int i = 0; i < N; i++)
                Out += " ";

            if (flag)
                return Out + "| ";
            else return Out;
        }
    }
}
