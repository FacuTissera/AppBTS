using AppBTS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBTS.Entidades
{
    class Usuario
    {
        private int id_usuario;

        public int Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public int Id_perfil { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public bool Borrado { get; set; }

    }
}
