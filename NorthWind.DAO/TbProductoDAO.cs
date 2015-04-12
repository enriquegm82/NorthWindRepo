using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAO
{   
    public class TbProductoDAO
    {
        public static List<TbProductoBE> SelectAll()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["NorthWind"].ToString();            
            string sql = "SELECT CodProducto,Descripcion,Precio FROM TbProducto";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    List<TbProductoBE> Productos = new List<TbProductoBE>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TbProductoBE objTbProducto = new TbProductoBE();
                            objTbProducto.CodProducto = Convert.ToString(reader.GetDecimal(0));
                            objTbProducto.Descripcion = reader.GetString(1);
                            objTbProducto.Precio = Convert.ToString(reader.GetDecimal(2));
                            Productos.Add(objTbProducto);
                        }
                    }
                    connection.Close();
                    return Productos;
                }
            }
        }
    }
    }

