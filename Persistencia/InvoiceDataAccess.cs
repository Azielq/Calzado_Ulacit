using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Calzado_Ulacit.Persistencia
{
    internal class InvoiceDataAccess
    {
        private readonly SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        // Método para agregar una factura y sus ítems
        public void AddInvoice(Invoice invoice, List<InvoiceItem> items)
        {
            try
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    // Insertar la factura
                    string insertInvoiceQuery = "INSERT INTO Invoice (cltId, invoiceDate, discount, totalAmount) VALUES (@cltId, @invoiceDate, @discount, @totalAmount); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(insertInvoiceQuery, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@cltId", invoice.ClientId);
                        cmd.Parameters.AddWithValue("@invoiceDate", invoice.InvoiceDate);
                        cmd.Parameters.AddWithValue("@discount", invoice.Discount);
                        cmd.Parameters.AddWithValue("@totalAmount", invoice.TotalAmount);

                        // Obtener el ID de la factura recién insertada
                        int invoiceId = Convert.ToInt32(cmd.ExecuteScalar());
                        invoice.InvoiceId = invoiceId;
                    }

                    // Insertar cada ítem de la factura
                    string insertItemQuery = "INSERT INTO InvoiceItems (invoiceId, shoeId, quantity, unitPrice, discount) VALUES (@invoiceId, @shoeId, @quantity, @unitPrice, @discount)";
                    foreach (var item in items)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertItemQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@invoiceId", invoice.InvoiceId);
                            cmd.Parameters.AddWithValue("@shoeId", item.ShoeId);
                            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@unitPrice", item.UnitPrice);
                            cmd.Parameters.AddWithValue("@discount", item.Discount);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar factura: " + ex.Message);
                throw; // Re-lanzar la excepción para manejarla en el nivel superior
            }
            finally
            {
                con.Close();
            }
        }
    }
}
