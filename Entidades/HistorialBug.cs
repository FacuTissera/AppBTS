using AppBTS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Entidades
{
    class HistorialBug
    {
        public int IdBugHistorico { get; set; }
        public DateTime FechaHistorico { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdBug { get; set; }
        public int IdResponsable { get; set; }
        public int IdAsignado { get; set; }
        public int IdProducto { get; set; }
        public int IdPrioridad { get; set; }
        public int IdCriticidad { get; set; }
        public int IdEstado { get; set; }
        public bool Borrado { get; set; }

        public DataTable RecuperarHistorialBug(int idBug)
        {
            string consulta = "SELECT h.fecha_historico, u.usuario as responsable, e.nombre as estado, us.usuario as asignado"
                               + " FROM (((BugsHistorico h "
                               + " LEFT JOIN Usuarios u on u.id_usuario = h.id_usuario_responsable)"
                               + " JOIN Estados e on e.id_estado = h.id_estado)"
                               + " LEFT JOIN Usuarios us on h.id_usuario_asignado = us.id_usuario)"
                               + " WHERE h.id_bug ="+ idBug;


            //BDHelper oDatos = new BDHelper();
            return BDHelper.obtenerInstancia().consultar(consulta);
        }



    }
}
