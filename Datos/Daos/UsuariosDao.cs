using AppBTS.Datos.Interfaces;
using AppBTS.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos.Daos
{
    class UsuariosDao : IUsuario
    {
        public DataTable RecuperarPorId(int id)
        {
            string consulta = "select * from usuarios where borrado = 0 AND id_usuario = " + id;
            return BDHelper.obtenerInstancia().consultar(consulta);
        }

        public DataTable RecuperarTodos()
        {
            string consulta = "select * from Usuarios where borrado = 0 ORDER BY 1";

            //BDHelper oDatos = new BDHelper();
            return BDHelper.obtenerInstancia().consultar(consulta);
        }

        public int validarUsuario(string nombre, string clave)
        {
            string consulta = "select * from Usuarios where usuario='" + nombre + "' and password= '" + clave + "'";

            DataTable tabla = BDHelper.obtenerInstancia().consultar(consulta);

            if (tabla.Rows.Count > 0)
            {
                return (int)tabla.Rows[0][0];
            }
            else
            {
                return 0;
            }
        }
        public void crear(Usuario oUsuario)
        {
            string consulta = "INSERT INTO Usuarios (usuario, password, email, id_perfil, estado, borrado) " +
                              " VALUES ('" +
                              oUsuario.Nombre + "','" +
                              oUsuario.Password + "','" +
                              oUsuario.Email + "','" +
                              oUsuario.Id_perfil + "','" +
                              oUsuario.Estado + "','" +
                              oUsuario.Borrado + "')";

            BDHelper.obtenerInstancia().actualizar(consulta);
        }
        
    }
}
