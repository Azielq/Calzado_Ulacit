using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ShoeId { get; set; }
        public string ShoeName { get; set; } 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        // Constructor por defecto
        public InvoiceItem()
        {
        }

        // Constructor opcional con parámetros (actualizado para incluir ShoeName)
        public InvoiceItem(int invoiceId, int shoeId, string shoeName, int quantity, decimal unitPrice, decimal discount)
        {
            InvoiceId = invoiceId;
            ShoeId = shoeId;
            ShoeName = shoeName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }
    }
}
