using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    internal class Invoice
    {
        private int clientID;
        private string saleDate;
        private int invID;
        private string shoeName;
        private float shoePrice;
        private int shoeAmount;
        private float totalSale;

        public Invoice(int clientID, string saleDate, int invID, string shoeName, float shoePrice, int shoeAmount, float totalSale)
        {
            this.clientID = clientID;
            this.saleDate = saleDate;
            this.invID = invID;
            this.shoeName = shoeName;
            this.shoePrice = shoePrice;
            this.shoeAmount = shoeAmount;
            this.totalSale = totalSale;
        }



        public int ClientID { get => clientID; set => clientID = value; }
        public string SaleDate { get => saleDate; set => saleDate = value; }
        public int InvID { get => invID; set => invID = value; }
        public string ShoeName { get => shoeName; set => shoeName = value; }
        public float ShoePrice { get => shoePrice; set => shoePrice = value; }
        public int ShoeAmount { get => shoeAmount; set => shoeAmount = value; }
        public float TotalSale { get => totalSale; set => totalSale = value; }
    }
}
