using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoBugs.Clases;

namespace ProyectoBugs.Formularios
{
    public partial class frmUsuarios : Form
    {
        bool nuevo = false;
        Datos oBD = new Datos();
        Usuario oUsuario = new Usuario();
       
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.habilitar(false);
           
            DataTable tabla = new DataTable();
            tabla = oBD.consultarTabla("perfiles");
            cboPerfil.DataSource = tabla;
            cboPerfil.DisplayMember = tabla.Columns[1].ColumnName;
            cboPerfil.ValueMember = tabla.Columns[0].ColumnName;
            cboPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPerfil.SelectedIndex = -1;

            cargarGrilla(grdUsuarios,oUsuario.recuperarUsuarios());

        }
        private void cargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["id_usuario"],
                                tabla.Rows[i]["usuario"],
                                tabla.Rows[i]["email"]);
            }
        }
        private void habilitar(bool x)
        {
            //txtId.Enabled = x;     por el id es autoincremental en la BD
            txtNombre.Enabled = x;
            txtPassword.Enabled = x;
            txtEmail.Enabled = x;
            cboPerfil.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
            grdUsuarios.Enabled = !x;
        }
        private void limpiar()
        {
            txtId.Text = "";
            txtNombre.Clear();
            txtPassword.Text = string.Empty;
            txtEmail.Clear();
            cboPerfil.SelectedIndex = -1;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.habilitar(true);
            this.limpiar();
            this.txtNombre.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //if (nuevo)
            //    // Insert
            //    else
            //    //update

            this.habilitar(false);
            this.nuevo = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.nuevo = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos((int)grdUsuarios.CurrentRow.Cells[0].Value);
        }
        private void actualizarCampos(int id)
        {
            DataTable tabla = new DataTable();
            tabla = oUsuario.recuperarUsuarioPorId(id);
            txtId.Text = tabla.Rows[0]["id_usuario"].ToString();
            txtNombre.Text = tabla.Rows[0]["usuario"].ToString();
            txtPassword.Text = tabla.Rows[0]["password"].ToString();
            txtEmail.Text = tabla.Rows[0]["email"].ToString();
            cboPerfil.SelectedValue = tabla.Rows[0]["id_perfil"];
        }
       
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de eliminar el usuario "+txtNombre.Text,
                                "ELIMINANDO",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                //Delete
            }
        }


    }
}
