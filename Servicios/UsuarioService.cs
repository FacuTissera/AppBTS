using AppBTS.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBTS.Datos.Daos;

namespace AppBTS.Servicios
{
    class UsuarioService
    {
        private IUsuario dao;

        public UsuarioService()
        {
            dao = new UsuariosDao();
        }
        public int encontrarUsuario(string nombre, string clave)
        {
            return dao.validarUsuario(nombre, clave);
        }

        public DataTable encontrarTodos()
        {
            return dao.RecuperarTodos();
        }
    }

}
