using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBTS.Entidades;
using AppBTS.Servicios;

namespace AppBTS.Presentacion
{
    public partial class frmUsuarios : Form
    {
        bool nuevo = false;
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
            this.habilitar(false);

        }

        private void habilitar(bool x)
        {
            //this.txtId.Enabled = False; porque es autoincremental en la BD
            this.txtNombre.Enabled = x;
            this.txtPassword.Enabled = x;
            this.txtEmail.Enabled = x;
            this.cboPerfil.Enabled = x;
            this.btnGrabar.Enabled = x;
            this.btnCancelar.Enabled = x;
            this.btnNuevo.Enabled = !x;
            this.btnEditar.Enabled = !x;
            this.btnBorrar.Enabled = !x;
            this.btnSalir.Enabled = !x;
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
        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtPassword.Text = "";
            this.txtEmail.Text = "";
            this.cboPerfil.SelectedIndex = -1;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.limpiar();
            this.txtNombre.Focus();
            this.nuevo = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (valido())
            {
                Usuario u = new Usuario();
                u.Nombre = txtNombre.Text;
                u.Password = txtPassword.Text;
                u.Email = txtEmail.Text;
                u.Id_perfil = (int)cboPerfil.SelectedValue;
                u.Estado = "N";
                u.Borrado = false;

                if (this.nuevo == true)
                {
                    u.Estado = "N";
                    u.Borrado = false;
                    oUsuario.insertarUsuario(u);
                }
                else
                {
                    u.Id_usuario = int.Parse(txtId.Text);//para modificar
                }
                this.habilitar(false);
                this.nuevo = false;
            }
        }

        private bool valido()
        {
            if (txtNombre.Text==string.Empty)
            {
                MessageBox.Show("Debe ingresar nombre de usuario...");
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar password...");
                txtPassword.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Debe ingresar un mail...");
                txtEmail.Focus();
                return false;
            }
            if (cboPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un perfil...");
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.habilitar(false);
            this.nuevo = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.txtNombre.Focus();
            this.nuevo = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void actualizarCampos(int id)
        {
            DataTable tabla = oUsuario.traerporId(id);
            txtId.Text = tabla.Rows[0]["id_usuario"].ToString();
            txtNombre.Text = tabla.Rows[0]["usuario"].ToString();
            txtPassword.Text = tabla.Rows[0]["password"].ToString();
            txtEmail.Text = tabla.Rows[0]["email"].ToString();
            txtId.Text = tabla.Rows[0]["id_usuario"].ToString();
            cboPerfil.SelectedValue = tabla.Rows[0]["id_perfil"];

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de eliminar el usuario" + txtNombre.Text,
                                    "ELIMINANDO",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {

            }
        }
         
        private void grdUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            this.actualizarCampos((int)grdUsuarios.CurrentRow.Cells[0].Value);
        }
    }  
}
