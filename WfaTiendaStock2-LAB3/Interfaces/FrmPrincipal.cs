using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaTiendaStock2_LAB3.Interfaces
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregar Ventana = new FrmAgregar();
            Ventana.ShowDialog();
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificar Ventana = new FrmModificar();
            Ventana.ShowDialog();

        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEliminar Ventana = new FrmEliminar();
            Ventana.ShowDialog();
        }

        private void buscarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmApp Ventana = new FrmApp();
            Ventana.ShowDialog();

        }

        private void btnPruebaDb_Click(object sender, EventArgs e)
        {
            DbProductos dbProductos = new DbProductos();
            dbProductos.VerificarConexion();
        }

        private void buscarPorCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarCategoria Ventana = new FrmBuscarCategoria();
            Ventana.ShowDialog();
        }
    }
}
