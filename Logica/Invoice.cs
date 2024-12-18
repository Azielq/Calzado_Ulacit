using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int cltId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } // Nueva propiedad

        // Constructor por defecto
        public Invoice()
        {
        }

        // Constructor opcional con parámetros
        public Invoice(int clientId, DateTime invoiceDate, decimal discount, decimal totalAmount, string paymentMethod)
        {
            cltId = clientId;
            InvoiceDate = invoiceDate;
            Discount = discount;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod; // Asignación de la nueva propiedad
        }
    }
}
