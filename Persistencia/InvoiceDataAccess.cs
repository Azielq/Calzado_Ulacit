using Calzado_Ulacit.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Calzado_Ulacit.Persistencia
{
    public class InvoiceDataAccess
    {
        // Conexión a la base de datos
        private readonly SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        // Método para agregar una factura y sus ítems
        public bool ClientExists(int clientId)
        {
            bool exists = false;
            string query = "SELECT COUNT(1) FROM Clients WHERE cltId = @cltId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@cltId", clientId);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                exists = count > 0;
                con.Close();
            }

            return exists;
        }

        // Método para obtener todos los clientes (si es necesario)
        public DataTable GetAllClients()
        {
            DataTable dt = new DataTable();
            string query = "SELECT cltId, ClientName FROM Clients"; // Ajusta los nombres de las columnas según tu base de datos

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        // Método para agregar una factura y sus ítems
        public void AddInvoice(Invoice invoice, List<InvoiceItem> items)
        {
            try
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    // Insertar la factura
                    string insertInvoiceQuery = "INSERT INTO Invoice (cltId, invoiceDate, discount, totalAmount, PaymentMethod) VALUES (@cltId, @invoiceDate, @discount, @totalAmount, @paymentMethod); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(insertInvoiceQuery, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@cltId", invoice.cltId);
                        cmd.Parameters.AddWithValue("@invoiceDate", invoice.InvoiceDate);
                        cmd.Parameters.AddWithValue("@discount", invoice.Discount);
                        cmd.Parameters.AddWithValue("@totalAmount", invoice.TotalAmount);
                        cmd.Parameters.AddWithValue("@paymentMethod", invoice.PaymentMethod); // Parámetro nuevo

                        // Obtener el ID de la factura recién insertada
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            invoice.InvoiceId = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("No se pudo obtener el ID de la factura.");
                        }
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
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public DataTable GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            i.invoiceId,
            i.cltId,
            c.CltName,
            i.invoiceDate,
            i.discount,
            i.totalAmount,
            i.PaymentMethod
        FROM 
            Invoice i
        JOIN 
            Clients c ON i.cltId = c.cltId
        WHERE 
            i.invoiceDate BETWEEN @StartDate AND @EndDate
        ORDER BY 
            i.invoiceDate";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener ventas por rango de fechas: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return dt;
        }


    }
}
