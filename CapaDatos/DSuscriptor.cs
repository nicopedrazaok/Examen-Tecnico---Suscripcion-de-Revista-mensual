using CapaDatos;
using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaEntidades
{
    public class DSuscriptor
    {       
        static string cadenaConexion = "Data Source=NICO\\SQLEXPRESS;Initial Catalog=DBRevistaMensual;User ID=sa;Password=nico123";
        public static bool insertarSuscripto(Suscriptor suscriptor)
        {
            bool resultado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            try
            {
                
                SqlCommand cmd = new SqlCommand();

                string consultaSQL = "INSERT INTO Suscriptor VALUES (@Nombre, @Apellido, @NumeroDocumento, @TipoDocumento, @Direccion, @Telefono, @Email, @NombreUsuario, @Password );";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Nombre", suscriptor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", suscriptor.Apellido);
                cmd.Parameters.AddWithValue("@NumeroDocumento", suscriptor.NumeroDocumento);
                cmd.Parameters.AddWithValue("@TipoDocumento", suscriptor.TipoDocumento);
                cmd.Parameters.AddWithValue("@Direccion", suscriptor.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", suscriptor.Telefono);
                cmd.Parameters.AddWithValue("@Email", suscriptor.Email);
                cmd.Parameters.AddWithValue("@NombreUsuario", suscriptor.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", suscriptor.Password);

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
       
        public static bool actualizarSuscripto(Suscriptor suscriptor,int id)
        {
            bool resultado = false;
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
               
                SqlCommand cmd = new SqlCommand();
                
                string consultaSQL = @"UPDATE Suscriptor 
                                      SET Nombre = @Nombre,Apellido=  @Apellido, NumeroDocumento = @NumeroDocumento,
                                      TipoDocumento= @TipoDocumento,Direccion = @Direccion, Telefono = @Telefono,Email = @Email,
                                      NombreUsuario = @NombreUsuario,Password = @Password 
                                      WHERE IdSuscriptor = @IdSuscriptor";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Nombre", suscriptor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", suscriptor.Apellido);
                cmd.Parameters.AddWithValue("@NumeroDocumento", suscriptor.NumeroDocumento);
                cmd.Parameters.AddWithValue("@TipoDocumento", suscriptor.TipoDocumento);
                cmd.Parameters.AddWithValue("@Direccion", suscriptor.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", suscriptor.Telefono);
                cmd.Parameters.AddWithValue("@Email", suscriptor.Email);
                cmd.Parameters.AddWithValue("@NombreUsuario", suscriptor.NombreUsuario);
                cmd.Parameters.AddWithValue("@Password", suscriptor.Password);
                cmd.Parameters.AddWithValue("@IdSuscriptor", id);

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
       
        public static Suscriptor buscarSuscriptor(string nroDoc,string tipoDoc)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                 string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento,Direccion,Telefono ,Email,NombreUsuario ,[Password]
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
                      
                    }
                }

                
            }
            catch (Exception)
            {
                return suscriptor = null;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return suscriptor;
        }
        public static Suscriptor buscarSuscriptorNoVigente(string nroDoc, string tipoDoc)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT sus.IdAsociacion,s.Nombre 'nombre',Apellido 'apellido',s.NumeroDocumento 'nroDoc',s.TipoDocumento 'tipoDoc',s.Direccion 'direccion',s.Telefono 'telefono',s.Email 'email',s.NombreUsuario 'user',s.[Password] 'pass'
                                       FROM Suscripcion sus JOIN Suscriptor s ON sus.IdAsociacion = s.IdSuscriptor 
                                       WHERE  s.NumeroDocumento = @NroDoc AND s.TipoDocumento = @TipoDoc AND FechaAlta IS NULL";
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

                    }
                }


            }
            catch (Exception)
            {
                return suscriptor = null;
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return suscriptor;
        }
        public static bool validarNroyTipoDoc(string nroDoc, string tipoDoc)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento,Direccion,Telefono ,Email,NombreUsuario ,[Password]
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
        public static bool validarNombreUsuario(string nombreUsuario)
        {

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            Suscriptor suscriptor = new Suscriptor();
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSQL = @"SELECT IdSuscriptor,Nombre ,Apellido ,NumeroDocumento ,TipoDocumento,Direccion,Telefono ,Email,NombreUsuario ,[Password]
                                       FROM Suscriptor                                     
                                       WHERE  NombreUsuario = @NombreUsuario";
                cmd.Parameters.Clear();


                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
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
