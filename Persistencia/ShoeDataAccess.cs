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
        private SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        // Método para agregar un zapato a la base de datos
        public void AddShoe(Shoe shoe)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Shoe (shoeName, shoeColor, shoeSize, type, price) VALUES (@Name, @Color, @ShoeSize, @Type, @Price)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", shoe.ShoeName);
                    cmd.Parameters.AddWithValue("@Color", shoe.ShoeColor);
                    cmd.Parameters.AddWithValue("@ShoeSize", shoe.ShoeSize);
                    cmd.Parameters.AddWithValue("@Type", shoe.Type);
                    cmd.Parameters.AddWithValue("@Price", shoe.Price);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar zapato: " + ex.Message);
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
                con.Open();
                string query = "DELETE FROM Shoe WHERE shoeId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", shoeId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar zapato: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Método para actualizar un zapato en la base de datos
        public void UpdateShoe(int shoeId, Shoe shoe)
        {
            try
            {
                con.Open();
                string query = "UPDATE Shoe SET shoeName = @Name, shoeColor = @Color, type = @Type, price = @Price WHERE shoeId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", shoe.ShoeName);
                    cmd.Parameters.AddWithValue("@Color", shoe.ShoeColor);
                    cmd.Parameters.AddWithValue("@Type", shoe.Type);
                    cmd.Parameters.AddWithValue("@Price", shoe.Price);
                    cmd.Parameters.AddWithValue("@ID", shoeId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar zapato: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Método para llenar el DataGrid con los datos de la tabla Shoes
        public DataTable fillDataGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                string query = "SELECT * FROM Shoe";
                SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
                adaptador.Fill(dt);

                // Recorrer las filas y aplicar Trim a las columnas de tipo string
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is string)
                        {
                            row[i] = row[i].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al llenar DataGrid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}
