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
        // Conexión a la base de datos con el servidor y la base de datos especificada
        private SqlConnection con = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security=true");

        // Método para agregar un nuevo cliente a la base de datos
        public void AddClient(Client client)
        {
            try
            {
                con.Open(); // Abre la conexión a la base de datos
                string query = "INSERT INTO Clients (cltName, cltLastName, cltAddress, cltPhoneNum) VALUES (@Name, @LastName, @Address, @PhoneNumber)";

                // Define un comando SQL con parámetros para evitar inyección SQL
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", client.CltName);
                    cmd.Parameters.AddWithValue("@LastName", client.CltLastName);
                    cmd.Parameters.AddWithValue("@Address", client.CltAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", client.CltPhoneNum);

                    cmd.ExecuteNonQuery(); // Ejecuta el comando para insertar el cliente en la base de datos
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
                string query = "DELETE FROM Clients WHERE cltId = @ID"; // Comando SQL para eliminar
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", clientId); // Asigna el ID al parámetro
                    cmd.ExecuteNonQuery(); // Ejecuta la eliminación
                }
            }
            catch (Exception ex)
            {
                // Captura y muestra cualquier error que ocurra al intentar eliminar el cliente
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
            }
            finally
            {
                con.Close(); // Cierra la conexión
            }
        }


        // Método para actualizar un cliente en la base de datos
        public void UpdateClient(int clientId, Client client)
        {
            try
            {
                con.Open(); // Abre la conexión
                string query = "UPDATE Clients SET cltName = @Name, cltLastName = @LastName, cltAddress = @Address, cltPhoneNum = @Phone WHERE cltId = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", client.CltName);
                    cmd.Parameters.AddWithValue("@LastName", client.CltLastName);
                    cmd.Parameters.AddWithValue("@Address", client.CltAddress);
                    cmd.Parameters.AddWithValue("@Phone", client.CltPhoneNum);
                    cmd.Parameters.AddWithValue("@ID", clientId);

                    cmd.ExecuteNonQuery(); // Ejecuta la actualización
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
            DataTable dt = new DataTable(); // Crea un DataTable para almacenar los datos
            try
            {
                con.Open(); // Abre la conexión
                string query = "SELECT * FROM Clients"; // Consulta SQL para seleccionar todos los clientes
                SqlDataAdapter adaptador = new SqlDataAdapter(query, con); // Crea un adaptador para llenar el DataTable
                adaptador.Fill(dt); // Llena el DataTable con los resultados de la consulta

                // Itera por cada fila y elimina espacios en blanco adicionales en columnas de tipo string
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row[i] is string)
                        {
                            row[i] = row[i].ToString().Trim(); // Aplica Trim a cada columna string 
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
            return dt; // Retorna el DataTable con los datos de los clientes
        }

    }
}
