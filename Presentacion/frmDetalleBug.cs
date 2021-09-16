using AppBTS.Entidades;
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
    public partial class frmDetalleBug : Form
    {
        private int idBug;

        public int IdBug { get => idBug; set => idBug = value; }

        public frmDetalleBug()
        {
            InitializeComponent();
        }

        private void frmDetalleBug_Load(object sender, EventArgs e)
        {

            actualizarCampos();
           

        }

        private void actualizarCampos()
        {
            DataTable tabla = new DataTable();

            Bug oBugSeleccionado = new Bug();
            tabla = oBugSeleccionado.RecuperarUno(idBug);

            txt_nro_bug.Text = tabla.Rows[0]["id_bug"].ToString();
            txt_titulo.Text = tabla.Rows[0]["titulo"].ToString();
            txt_producto.Text = tabla.Rows[0]["producto"].ToString();
            txt_fec_alta.Text = tabla.Rows[0]["fecha_alta"].ToString();
            txt_descri.Text = tabla.Rows[0]["descripcion"].ToString();
            txt_prioridad.Text = tabla.Rows[0]["prioridad"].ToString();
            txt_criticidad.Text = tabla.Rows[0]["criticidad"].ToString();

            tabla.Clear();
            HistorialBug oHistorialBug = new HistorialBug();
            tabla = oHistorialBug.RecuperarHistorialBug(idBug);
            if (tabla.Rows.Count>0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dgv_historiales.Rows.Add(tabla.Rows[i]["fecha_historico"],
                                             tabla.Rows[i]["responsable"],
                                             tabla.Rows[i]["estado"],
                                             tabla.Rows[i]["asignado"]);
                                            
                }
            }
        }


        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
