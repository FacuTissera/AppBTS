using AppBTS.Entidades;
using AppBTS.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBTS.Presentacion
{
    public enum Modo
    {
        Create,
        Read,
        Update,
        Delete
    }
    public partial class frmBug : Form
    {
        private Modo accion;
        private Bug oBugSeleccionado;
        private HistorialBug oHistorialBug;
        private Prioridad oPrioridad = new Prioridad();
        private Producto oProducto = new Producto();
        private Criticidad oCriticidad = new Criticidad();
        private BugService oBugService;


        public frmBug(Modo accion, Bug bugSeleccionado)
        {
            InitializeComponent();
            this.accion = accion;
            this.oBugSeleccionado = bugSeleccionado;
        }

        private void frmBug_Load(object sender, EventArgs e)
        {
            if (accion.Equals(Modo.Create))
            {
                this.Text = "Nuevo Bug";
            }
            if (accion.Equals(Modo.Update))
            {
                this.Text = "Actualizar Bug";
                //cargarDatosDeBugSeleccionado
            }
           
            this.CargarCombo(cboPrioridad, oPrioridad.RecuperarTodos());
            this.CargarCombo(cboProducto, oProducto.RecuperarTodos());
            this.CargarCombo(cboCriticidad, oCriticidad.RecuperarTodos());
        }
        private void CargarCombo(ComboBox combo, DataTable tabla)
        {
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.SelectedIndex = -1;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch(accion)
            {
                case Modo.Create:
                    {
                        oBugSeleccionado = new Bug();
                        oBugSeleccionado.Titulo = txtTitulo.Text;
                        oBugSeleccionado.Descripcion = txtDescripcion.Text;
                        oBugSeleccionado.Id_criticidad = (int)cboCriticidad.SelectedValue;
                        oBugSeleccionado.Id_prioridad = (int)cboPrioridad.SelectedValue;
                        oBugSeleccionado.Id_producto = (int)cboProducto.SelectedValue;
                        oBugSeleccionado.Id_estado = 1;
                        oBugSeleccionado.Id_usuario_responsable = 2;//usuario perfil tester logueado
                        oBugSeleccionado.Fecha_alta = DateTime.Today;

                        oHistorialBug = new HistorialBug();
                        oHistorialBug.IdBugHistorico = 1;
                        oHistorialBug.FechaHistorico = DateTime.Today;
                        oHistorialBug.IdResponsable = 2; //usuario perfil tester logueado
                        oHistorialBug.IdEstado = 1;

                        if (oBugService.crearBugConHistorial(oBugSeleccionado, oHistorialBug))
                        {
                            MessageBox.Show("Bug con historial insertado!!");
                        }

                        break;
                    }
                case Modo.Update:
                    {
                        break;
                    }
            }
        }
    }
}
