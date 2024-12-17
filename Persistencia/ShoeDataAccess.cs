using Calzado_Ulacit.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Persistencia
{
    internal class ShoeDataAccess
    {
        // Conexión a la base de datos
        private SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        // Método para agregar un zapato a la base de datos
        public void AddShoe(Shoe shoe)
        {
            try
            {
                con.Open();// Abre la conexión a la base de datos
                string query = "INSERT INTO Shoe (shoeName, shoeColor, shoeSize, type, price) VALUES (@Name, @Color, @ShoeSize, @Type, @Price)";

                // Usa un SqlCommand para ejecutar la consulta con parámetros
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", shoe.ShoeName);
                    cmd.Parameters.AddWithValue("@Color", shoe.ShoeColor);
                    cmd.Parameters.AddWithValue("@ShoeSize", shoe.ShoeSize);
                    cmd.Parameters.AddWithValue("@Type", shoe.Type);
                    cmd.Parameters.AddWithValue("@Price", shoe.Price);

                    cmd.ExecuteNonQuery(); // Ejecuta la consulta
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar zapato: " + ex.Message); // Muestra mensaje de error en caso de excepción
            }
            finally
            {
                con.Close(); // Cierra la conexión
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
                string query = "UPDATE Shoe SET shoeName = @Name, shoeColor = @Color, type = @Type, price = @Price WHERE shoeId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", shoe.ShoeName);
                    cmd.Parameters.AddWithValue("@Color", shoe.ShoeColor);
                    cmd.Parameters.AddWithValue("@Type", shoe.Type);
                    cmd.Parameters.AddWithValue("@Price", shoe.Price);
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
                string query = "SELECT shoeId, shoeName, price FROM Shoe"; // Define la consulta de selección
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

    }


}
