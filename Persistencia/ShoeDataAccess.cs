using Calzado_Ulacit.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calzado_Ulacit.Persistencia
{
   public class ShoeDataAccess
    {
        // Conexión a la base de datos
        private SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        // Método para agregar un zapato a la base de datos
        public void AddShoe(Shoe shoe)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Shoe (shoeName, shoeColor, shoeSize, type, price, Stock) VALUES (@Name, @Color, @ShoeSize, @Type, @Price, @Stock)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", shoe.ShoeName);
                    cmd.Parameters.AddWithValue("@Color", shoe.ShoeColor);
                    cmd.Parameters.AddWithValue("@ShoeSize", shoe.ShoeSize);
                    cmd.Parameters.AddWithValue("@Type", shoe.Type);
                    cmd.Parameters.AddWithValue("@Price", shoe.Price);
                    cmd.Parameters.AddWithValue("@Stock", shoe.Stock);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el zapato: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Método para eliminar un zapato por ID
        public void DeleteShoeById(int shoeId)
        {
            try
            {
                con.Open(); // Abre la conexión a la base de datos
                string query = "DELETE FROM Shoe WHERE shoeId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", shoeId); // Define el parámetro ID
                    cmd.ExecuteNonQuery(); // Ejecuta la consulta de eliminación
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar zapato: " + ex.Message); // Muestra mensaje de error en caso de excepción
            }
            finally
            {
                con.Close(); // Cierra la conexión
            }
        }

        // Método para actualizar un zapato en la base de datos
        public void UpdateShoe(int shoeId, Shoe shoe)
        {
            try
            {
                con.Open(); // Abre la conexión a la base de datos
                string query = "UPDATE Shoe SET shoeName = @Name, shoeColor = @Color, shoeSize = @shoeSize, type = @Type, price = @Price, Stock = @Stock WHERE shoeId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", shoe.ShoeName);
                    cmd.Parameters.AddWithValue("@Color", shoe.ShoeColor);
                    cmd.Parameters.AddWithValue("@shoeSize", shoe.ShoeSize); // Agregar parámetro para shoeSize
                    cmd.Parameters.AddWithValue("@Type", shoe.Type);
                    cmd.Parameters.AddWithValue("@Price", shoe.Price);
                    cmd.Parameters.AddWithValue("@Stock", shoe.Stock);
                    cmd.Parameters.AddWithValue("@ID", shoeId);

                    cmd.ExecuteNonQuery(); // Ejecuta la consulta de actualización
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar zapato: " + ex.Message); // Muestra mensaje de error en caso de excepción
            }
            finally
            {
                con.Close(); // Cierra la conexión
            }
        }

        // Método para llenar el DataGrid con los datos de la tabla Shoes
        public DataTable fillDataGrid()
        {
            DataTable dt = new DataTable(); // Crea un nuevo DataTable para almacenar los datos
            try
            {
                con.Open(); // Abre la conexión a la base de datos
                string query = "SELECT * FROM Shoe"; // Define la consulta de selección
                SqlDataAdapter adaptador = new SqlDataAdapter(query, con); // Usa un adaptador para llenar el DataTable
                adaptador.Fill(dt);

                // Recorrer las filas y aplicar Trim a las columnas de tipo string para eliminar espacios en blanco
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is string)
                        {
                            row[i] = row[i].ToString().Trim(); // Elimina espacios en blanco al inicio y al final
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al llenar DataGrid: " + ex.Message);  // Muestra mensaje de error en caso de excepción
            }
            finally
            {
                con.Close(); // Cierra la conexión
            }
            return dt; // Devuelve el DataTable con los datos de la tabla Shoe
        }

        public DataTable GetAllShoes()
        {
            DataTable dt = new DataTable(); // Crea un nuevo DataTable para almacenar los datos
            try
            {
                con.Open(); // Abre la conexión a la base de datos
                string query = "SELECT shoeId, shoeName, price, Stock FROM Shoe"; // Define la consulta de selección
                SqlDataAdapter adaptador = new SqlDataAdapter(query, con); // Usa un adaptador para llenar el DataTable
                adaptador.Fill(dt);

                // Recorrer las filas y aplicar Trim a las columnas de tipo string para eliminar espacios en blanco
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is string)
                        {
                            row[i] = row[i].ToString().Trim(); // Elimina espacios en blanco al inicio y al final
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al llenar DataGrid: " + ex.Message);  // Muestra mensaje de error en caso de excepción
            }
            finally
            {
                con.Close(); // Cierra la conexión
            }
            return dt; // Devuelve el DataTable con los datos de la tabla Shoe
        }

        // Método para obtener el nombre del zapato por ID
        public string GetShoeNameById(int shoeId)
        {
            string shoeName = "Desconocido";
            try
            {
                con.Open();
                string query = "SELECT shoeName FROM Shoe WHERE shoeId = @ShoeId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ShoeId", shoeId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        shoeName = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el nombre del zapato: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return shoeName;
        }

        public int GetStockById(int shoeId)
        {
            int stock = 0;
            try
            {
                con.Open();
                string query = "SELECT Stock FROM Shoe WHERE shoeId = @ShoeId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ShoeId", shoeId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        stock = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el stock del zapato: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return stock;
        }

        public void ReduceShoeStock(int shoeId, int quantitySold)
        {
            try
            {
                con.Open();
                string query = "UPDATE Shoe SET Stock = Stock - @QuantitySold WHERE shoeId = @ShoeId AND Stock >= @QuantitySold";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);
                    cmd.Parameters.AddWithValue("@ShoeId", shoeId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No hay suficiente stock para este zapato o el zapato no existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reducir el stock del zapato: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public bool HasReferencesInInvoiceItems(int shoeId)
        {
            bool hasReferences = false;
            try
            {
                con.Open(); // Abre la conexión a la base de datos
                string query = "SELECT COUNT(*) FROM InvoiceItems WHERE shoeId = @ShoeId"; // Consulta para contar referencias
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ShoeId", shoeId); // Define el parámetro shoeId
                    int count = (int)cmd.ExecuteScalar(); // Ejecuta la consulta y obtiene el resultado
                    hasReferences = count > 0; // Si el conteo es mayor a 0, existen referencias
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar referencias en InvoiceItems: " + ex.Message); // Muestra mensaje de error en caso de excepción
            }
            finally
            {
                con.Close(); // Cierra la conexión
            }
            return hasReferences; // Devuelve true si hay referencias, false en caso contrario
        }



    }


}
