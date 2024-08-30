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
    public partial class FrmAgregar : Form
    {
        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmApp frmApp = new FrmApp();
            frmApp.Show();
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            VerProductos();
        }

        public void VerProductos()
        {
            DbProductos dbProductos = new DbProductos();
            DataTable dtProductos = dbProductos.VerProductos();
            if (dtProductos.Rows.Count > 0)
            {
                dgvProductos.DataSource = dtProductos;
            }
            else
            {
                MessageBox.Show("No hay productos para mostrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar que se hayan ingresado todos los campos
            if (string.IsNullOrEmpty(txtNombreProducto.Text) || string.IsNullOrEmpty(txtDescripcion.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombreProducto.Text;
            string descripcion = txtDescripcion.Text;
            double precio;
            int stock;

            if (!double.TryParse(txtPrecio.Text, out precio)) {
                MessageBox.Show("Precio ingresado invalido!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtStock.Text, out stock)) {
                MessageBox.Show("Nro de stock ingresado invalido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DbProductos dbProductos = new DbProductos();
            bool carga = dbProductos.AgregarProducto(nombre,descripcion,precio,stock);
            if (carga)
            {
                MessageBox.Show("Producto agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerProductos(); 
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
    }
}
