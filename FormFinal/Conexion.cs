using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FormFinal
{
    public class Conexion
    {
        private string ConnectionString = "Data Source=LAPTOP-79F2RK9S\\SQLEXPRESS; Initial Catalog=MiPrueba; Integrated Security=True;";
        //User=sa; Password=123

        public bool ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Datos> Get()
        {
            List<Datos> datos = new List<Datos>();
            string query = " EXECUTE sp_consultar_productos ";

            using (SqlConnection conn=new SqlConnection (ConnectionString))
            {
                SqlCommand command = new SqlCommand(query,conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Datos odatos = new Datos();
                        odatos.Id = reader.GetInt32(0);
                        odatos.num_producto = reader.GetInt32(1);
                        odatos.pedido = reader.GetInt32(2);
                        odatos.Nombre = reader.GetString(3);
                        datos.Add(odatos);
                    }
                    reader.Close();
                    conn.Close();

                    return datos;
                }
                catch(Exception ex)
                {
                    throw new Exception("Error en la bd " + ex.Message);
                }

            }
        }

        //Agregar

        public void Agregar(int num,int pedido, string nombre) 
        {
            
            string query = " insert into productos (num_producto,pedido,nombre) values(@num,@pedido,@nombre) ";
            

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@num",num);
                command.Parameters.AddWithValue("@pedido",pedido);
                command.Parameters.AddWithValue("@nombre",nombre);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                 
                    conn.Close();
                   
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la bd " + ex.Message);
                }

            }

        }

        //Editar
        public void Editar(int num, int pedido, string nombre, int id)
        {

            string query = " Update productos set num_producto=@num,pedido=@pedido,nombre=@nombre where id=@id";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@num", num);
                command.Parameters.AddWithValue("@pedido", pedido);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la bd " + ex.Message);
                }

            }

        }

        //Eliminar
        public void Eliminar(int id)
        {

            string query = " delete from productos  where id=@id";


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la bd " + ex.Message);
                }

            }

        }

        //seleccionar un dato
        public Datos Get(int Id)
        {
             Datos datos = new Datos();
            string query = " EXECUTE sp_consultar_productos_id '" + Id + "'";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                  
                    Datos odatos = new Datos();
                    odatos.Id = reader.GetInt32(0);
                    odatos.num_producto = reader.GetInt32(1);
                    odatos.pedido = reader.GetInt32(2);
                    odatos.Nombre = reader.GetString(3);
                                          
                    reader.Close();
                    conn.Close();

                    return odatos;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la bd " + ex.Message);
                }

            }
        }


    }


    public class Datos
    {
        public int Id { get; set; }
        public int num_producto { get; set; }
        public int pedido { get; set; }
        public string Nombre { get; set; }

    }
}
