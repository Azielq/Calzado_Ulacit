using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    internal class Invoice
    {
        

        //Atributos
        public int InvoiceId { get; set; }
        public int ClientId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }


        public Invoice(int invoiceId, int clientId, DateTime invoiceDate, decimal discount, decimal totalAmount)
        {
            InvoiceId = invoiceId;
            ClientId = clientId;
            InvoiceDate = invoiceDate;
            Discount = discount;
            TotalAmount = totalAmount;
        }
    }
}
