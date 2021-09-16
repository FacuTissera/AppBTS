using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBTS.Servicios;

namespace AppBTS.Presentacion
{
    public partial class frmUsuarios : Form
    {
        PerfilService oPerfil = new PerfilService();
        UsuarioService oUsuario = new UsuarioService();

        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombo(cboPerfil, oPerfil.traerTodos());
            CargarGrilla(grdUsuarios, oUsuario.encontrarTodos());

        }

        private void CargarCombo(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.SelectedIndex = -1;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["id_usuario"],
                                tabla.Rows[i]["usuario"],
                                tabla.Rows[i]["email"]);
                            
            };
        }
        private void habilitar(bool x)
        {
            
        }
        private void limpiar()
        {
           
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
         
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }
        private void grdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
           
        }
        private void actualizarCampos(int id)
        {
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
           
        }


    }
}
