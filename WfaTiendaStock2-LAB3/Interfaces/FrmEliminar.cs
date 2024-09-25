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
    public partial class FrmEliminar : Form
    {
        public FrmEliminar()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEliminar_Load(object sender, EventArgs e)
        {
            VerProductos();
        }

        // metodo para ver los productos
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text)) {
                MessageBox.Show("Ingresar el codigo del producto","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            int codigo;
            if (!int.TryParse(txtIdProducto.Text, out codigo)) {
                MessageBox.Show("El codigo ingresado es invalido!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            DbProductos dbProductos = new DbProductos();
            bool eliminado = dbProductos.EliminarProducto(codigo);
            if (eliminado)
            {
                MessageBox.Show("Producto eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerProductos(); // Recargar los productos en el DataGridView si es necesario
            }
            else
            {
                MessageBox.Show("El código del producto no existe o no se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
