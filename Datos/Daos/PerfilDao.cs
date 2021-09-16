using AppBTS.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos.Daos
{
    class PerfilDao : IPerfil
    {
        public DataTable recuperarTodos()
        {
            string consulta = "select * from Perfiles where borrado = 0 ORDER BY 2";
            return BDHelper.obtenerInstancia().consultar(consulta);
        }
    }
}
