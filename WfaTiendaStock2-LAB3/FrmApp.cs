using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaTiendaStock2_LAB3
{
    public partial class FrmApp : Form
    {
        public FrmApp()
        {
            InitializeComponent();
        }

        private void btnPruebaDb_Click(object sender, EventArgs e)
        {
            DbProductos dbProductos = new DbProductos();
            dbProductos.VerificarConexion();
        }

        private void FrmApp_Load(object sender, EventArgs e)
        {

        }

        private void btnVerProductos_Click(object sender, EventArgs e)
        {
            // conexion a base de datos
            DbProductos dbProductos = new DbProductos();
            // llama al objeto datatable y le asigna lo que obtiene del metodo VerProductos
            DataTable dtProductos = dbProductos.VerProductos();
            if (dtProductos.Rows.Count > 0)
            {
                // si el objeto dtProdcutos tiene datos, se asigna mediante DataSource como fuente de datos al dgv
                dgvProductos.DataSource = dtProductos;
            }
            else {
                MessageBox.Show("No hay productos para mostrar!","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


        }

        private void btnModifcar_Click(object sender, EventArgs e)
        {
            FrmModificar frmModificar = new FrmModificar();
            frmModificar.Show();
            
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            FrmEliminar frmEliminar = new FrmEliminar();
            frmEliminar.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregar frmAgregar = new FrmAgregar();
            frmAgregar.Show();
        }
    }
}
