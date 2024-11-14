using Calzado_Ulacit.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Persistencia
{
    internal class ClientDataAccess
    {
        private SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        public void AddClient(Client client)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO Clients (cltName, cltLastName, cltAddress, cltPhoneNum) VALUES (@Name, @LastName, @Address, @PhoneNumber)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", client.CltName);
                    cmd.Parameters.AddWithValue("@LastName", client.CltLastName);
                    cmd.Parameters.AddWithValue("@Address", client.CltAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", client.CltPhoneNum);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al insertar cliente: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Método para eliminar el cliente por ID
        public void DeleteClientById(int clientId)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM Clients WHERE cltId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", clientId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        // Método para actualizar un cliente en la base de datos
        public void UpdateClient(int clientId, Client client)
        {
            try
            {
                con.Open();
                string query = "UPDATE Clients SET cltName = @Name, cltLastName = @LastName, cltAddress = @Address, cltPhoneNum = @Phone WHERE cltId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", client.CltName);
                    cmd.Parameters.AddWithValue("@LastName", client.CltLastName);
                    cmd.Parameters.AddWithValue("@Address", client.CltAddress);
                    cmd.Parameters.AddWithValue("@Phone", client.CltPhoneNum);
                    cmd.Parameters.AddWithValue("@ID", clientId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar cliente: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Método para llenar el DataGrid con los datos de la base de datos
        public DataTable fillDataGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                string query = "SELECT * FROM Clients";
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
