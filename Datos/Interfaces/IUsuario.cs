using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos.Interfaces
{
    interface IUsuario
    {
        //esto es que hace una clase (entidad)
        int validarUsuario(string nombre, string clave); //metodo abstracto
        DataTable RecuperarTodos();

    }
}
