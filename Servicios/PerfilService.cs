using AppBTS.Datos.Daos;
using AppBTS.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Servicios
{
    class PerfilService
    {
        private IPerfil dao;
        public PerfilService()
        {
            dao = new PerfilDao();
        }
        public DataTable traerTodos()
        {
            return dao.recuperarTodos();
        }

    }
}
