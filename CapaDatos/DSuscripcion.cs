using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSuscripcion
    {
        static string cadenaConexion = "Data Source=NICO\\SQLEXPRESS;Initial Catalog=DBRevistaMensual;User ID=sa;Password=nico123";
        public static int idSuscriptor(string nroDoc, string tipoDoc)
        {
            int idSuscriptor = 0;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor
                                       FROM Suscriptor                                     
                                       WHERE  NumeroDocumento = @NroDoc AND TipoDocumento = @TipoDoc";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@NroDoc", nroDoc);
                cmd.Parameters.AddWithValue("@TipoDoc", tipoDoc);
            
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSQL;
                conexion.Open();
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                         idSuscriptor = Convert.ToInt32(dr.GetInt32(0));
                        
                    }
                }

             
            }
            catch (Exception)
            {
                return idSuscriptor = 0;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return idSuscriptor;
        }
        public static bool insertarSuscripcion(int idSuscriptor)
        {
            bool resultado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                
                SqlCommand cmd = new SqlCommand();

                string consultaSQL = "INSERT INTO Suscripcion(IdSuscriptor, FechaAlta) VALUES (@IdSuscriptor, GETDATE())";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@IdSuscriptor", idSuscriptor);
               

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = consultaSQL;

                conexion.Open();

                cmd.Connection = conexion;

                cmd.ExecuteNonQuery();

                resultado = true;
            }
            catch (Exception ex)
            {
                return resultado = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
        public static bool buscarSuscriptorVigente(string nroDoc, string tipoDoc)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT sus.IdAsociacion,s.Nombre ,Apellido ,s.NumeroDocumento ,s.TipoDocumento ,s.Direccion ,s.Telefono ,s.Email ,s.NombreUsuario ,s.[Password]
                                       FROM Suscripcion sus JOIN Suscriptor s ON sus.IdAsociacion = s.IdSuscriptor 
                                       WHERE  s.NumeroDocumento = @NroDoc AND s.TipoDocumento = @TipoDoc";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@NroDoc", nroDoc);
                cmd.Parameters.AddWithValue("@TipoDoc", tipoDoc);
                
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSQL;
                conexion.Open();
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        suscriptor.IdSuscriptor = Convert.ToInt32(dr.GetInt32(0));
                        suscriptor.Nombre = dr.GetString(1);
                        suscriptor.Apellido = dr.GetString(2);
                        suscriptor.NumeroDocumento = dr.GetString(3);
                        suscriptor.TipoDocumento = dr.GetString(4);
                        suscriptor.Direccion = dr.GetString(5);
                        suscriptor.Telefono = dr.GetString(5);
                        suscriptor.Email = dr.GetString(7);
                        suscriptor.NombreUsuario = dr.GetString(8);
                        suscriptor.Password = dr.GetString(9);

                        return resultado = true;
                    }
                }
                
              
            }
            catch (Exception)
            {
                return resultado = false;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }
    }
}
