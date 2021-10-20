using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos
{
    class BDHelper
    {
        //singleton
        private static BDHelper instancia;
        private SqlConnection conexion;
        private SqlCommand comando;
        private string cadenaConexion;

        private BDHelper()
        {
            conexion = new SqlConnection(); //va a permitir la conexion con la BD
            comando = new SqlCommand(); //va a permitir la manipulacion de la BD
            cadenaConexion = @"Data Source=DESKTOP-GBIGEVC\SQLEXPRESS;Initial Catalog=PAVI;Integrated Security=True";
        }

        public static BDHelper obtenerInstancia()
        {
            if (instancia == null)
                instancia = new BDHelper();
            return instancia;
        }

        public DataTable consultar(string consultaSQL)
        {
            DataTable tabla = new DataTable(); //estoy creando la BD
            conexion.ConnectionString = cadenaConexion; //estoy definiendo cual va a ser la cadena de conexion en conexion
            conexion.Open(); //abro la conexion
            comando.Connection = conexion; //defino la coneccion que voy a usar en el comando
            comando.CommandType = CommandType.Text; //defino el tipo de comando que voy a usar (en este caso texto)
            comando.CommandText = consultaSQL; //y que texto va a ser? la consultaSQL
            tabla.Load(comando.ExecuteReader());//uso un ExecuteReader ya que la consulta devuelve datos, no inserta ni actualiza

            conexion.Close();//cierro la conexion
            return tabla;
        }

        public void actualizar(string consultaSQL)
        {  
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();//lo unico que cambia con respecto al otro metodo es la ExecuteNonQuery
                                        //ya que este no es solo para consultar si no que lo voy a usar para insertar

            conexion.Close();
        }

    }
}
