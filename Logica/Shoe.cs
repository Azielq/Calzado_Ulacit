using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    public class Shoe
    {
        public string ShoeName { get; set; }
        public string ShoeColor { get; set; }
        public int ShoeSize { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public Shoe(string shoeName, string shoeColor, int shoeSize, string type, float price, int stock)
        {
            ShoeName = shoeName;
            ShoeColor = shoeColor;
            ShoeSize = shoeSize;
            Type = type;
            Price = price;
            Stock = stock;
        }
    }
}
