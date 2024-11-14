using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    internal class Shoe
    {
        private int shoeId;
        private string shoeName;
        private string shoeColor;
        private int shoeSize;
        private string type;
        private float price;

        public Shoe(int shoeId, string shoeName, string shoeolor, int shoeSize, string type, float price)
        {
            this.shoeId = shoeId;
            this.shoeName = shoeName;
            this.shoeColor = shoeolor;
            this.shoeSize = shoeSize;
            this.type = type;
            this.price = price;
        }





        public int ShoeId { get => shoeId; set => shoeId = value; }
        public string ShoeName { get => shoeName; set => shoeName = value; }
        public string ShoeColor { get => shoeColor; set => shoeColor = value; }
        public int ShoeSize { get => shoeSize; set => shoeSize = value; }
        public string Type { get => type; set => type = value; }
        public float Price { get => price; set => price = value; }
    }
}
