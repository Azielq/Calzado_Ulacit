﻿using Calzado_Ulacit.Logica;
using System;
using System.Collections.Generic;
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
    }
}