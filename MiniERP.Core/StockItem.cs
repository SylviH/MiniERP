using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP.Core
{
    //Denne klasse er lavet abstrakt, fordi andre skal kun arve fra denne klasse og man skal ikke kunne lave en instance af den.
    public abstract class StockItem
    {
        private int _stockItemId;

        public int StockItemId
        {
            get { return _stockItemId; }
            set {
                if (value <= 0)
                    value = 1;
             
                _stockItemId = value; }
        }

        public string Name { get; set; }
        public double Price { get; set; }


        public abstract void Save();

        public StockItem()
        {
            this.Name = "";
        }
    }

    public class Item : StockItem
    {
        public override void Save()
        {

           string json =  Newtonsoft.Json.JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(@"c:\temp\" + this.StockItemId + ".json", json);
        }

        public static Item Load(int id)
        {
            string json = System.IO.File.ReadAllText(@"c:\temp\" +id+ ".json");
            Item i = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(Item)) as Item;
            return i;
        }

        public override string ToString()
        {
            return "Item#" + this.StockItemId;
        }
    }
}
