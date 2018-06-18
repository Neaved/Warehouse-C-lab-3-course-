using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Form[] array = new Form[4];
           // array[0] = new ClientManager();
           array[0] = new ProviderManager();
            array[1] = new Bookmaker();
            array[2] = new StoreKeeper();
            array[3] = new Courier();
            //int k = 3;
            for (int i = 3; i >= 0; i--)
            {
               // Application.Run(array[i]);
             array[i].Show();
            }

          //  var a = new ProviderManager();
          //  a.Show();

             Application.Run(new ClientManager());

             

          //  Application.Run(new ProviderManager());
           // Application.Run(new Bookmaker());
           // Application.Run(new StoreKeeper());
           // Application.Run(new Courier());
            //  Application.Run(new StartUpForm());

        }
    }
}
