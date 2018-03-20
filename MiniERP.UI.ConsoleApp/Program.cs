using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MiniERP.Core.Item i = new Core.Item();
            i.StockItemId = 1;
            i.Name = "My Item";
            i.Price = 10;
            Console.WriteLine(i.ToString());
            i.Save();

            MiniERP.Core.Item i2 = MiniERP.Core.Item.Load(1);
            Console.WriteLine(i2);
            

        }
    }
}
