using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    internal class InvoiceItem
    {
        

        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ShoeId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }


        public InvoiceItem(int invoiceItemId, int invoiceId, int shoeId, int quantity, decimal unitPrice, decimal discount)
        {
            InvoiceItemId = invoiceItemId;
            InvoiceId = invoiceId;
            ShoeId = shoeId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }

    }
}
