using AppBTS.Datos.Interfaces;
using AppBTS.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Datos.Daos
{
    class BugDao : IBugDao
    {
        public bool insertarBugConHistorial(Bug oBug, HistorialBug oHistorialBug)
        {
            string consulta = "Insert into Bugs (titulo, descripcion, fecha_alta, id_producto, id_criticidad, id_prioridad, id_estado, id_usuario_responsable) "
                              + "VALUES ('" + oBug.Titulo + "','"
                                         + oBug.Descripcion + "','"
                                         + oBug.Fecha_alta + "','"
                                         + oBug.Id_producto + "','"
                                         + oBug.Id_criticidad + "','"
                                         + oBug.Id_prioridad + "','"
                                         + oBug.Id_estado + "','"
                                         + oBug.Id_usuario_responsable + ")";                 

            //string consultaHistorial = "Insert into BugsHistoricos()
            //                            + "VALUES ('" +oHistorialBug

            return true;
        }
    }
}
