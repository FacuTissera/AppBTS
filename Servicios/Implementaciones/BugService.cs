using AppBTS.Datos.Interfaces;
using AppBTS.Entidades;
using AppBTS.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Servicios.Implementaciones
{
    class BugService : IBugService
    {
        private IBugDao dao;

        public bool crearBugConHistorial(Bug oBugSeleccionado, HistorialBug oHistorialBug)
        {
            return dao.insertarBugConHistorial(oBugSeleccionado,  oHistorialBug);
        }
    }
}
