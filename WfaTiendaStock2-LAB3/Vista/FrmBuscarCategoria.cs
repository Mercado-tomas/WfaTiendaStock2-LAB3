using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfaTiendaStock2_LAB3;

namespace WfaTiendaStock2_LAB3.Interfaces
{
    public partial class FrmBuscarCategoria : Form
    {
        public FrmBuscarCategoria()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Obtener el nodo seleccionado (nombre de la categoría)
            string categoriaSeleccionada = e.Node.Text;

            // Verificar si el nodo seleccionado es una categoría válida
            if (categoriaSeleccionada == "Computadoras" || categoriaSeleccionada == "Accesorios" || categoriaSeleccionada == "Periféricos")
            {
                // Obtener los productos de la categoría seleccionada
                CargarProductosPorCategoria(categoriaSeleccionada);
            }
        }

        private void CargarProductosPorCategoria(string categoria)
        {
            // Crear una instancia de la base de datos para obtener los productos
            DbProductos dbProductos = new DbProductos();

            // Obtener todos los productos de la base de datos
            DataTable dtProductos = dbProductos.VerProductos();

            // Crear un DataView para filtrar los productos según la categoría seleccionada
            DataView dvFiltrado = new DataView(dtProductos);

            // Aplicar el filtro según la categoría seleccionada
            switch (categoria)
            {
                case "Computadoras":
                    dvFiltrado.RowFilter = "IdCategoria = 1";
                    break;
                case "Accesorios":
                    dvFiltrado.RowFilter = "IdCategoria = 2";
                    break;
                case "Periféricos":
                    dvFiltrado.RowFilter = "IdCategoria = 3";
                    break;
                default:
                    MessageBox.Show("Categoría no reconocida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Verificar si el filtro contiene productos
            if (dvFiltrado.Count > 0)
            {
                // Asignar el DataView filtrado al DataGridView
                dgvProductos.DataSource = dvFiltrado;
            }
            else
            {
                // Mostrar un mensaje si no hay productos para la categoría seleccionada
                dgvProductos.DataSource = null; // Limpiar la grilla si no hay productos
                MessageBox.Show($"No hay productos para la categoría {categoria}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmBuscarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos.Columns.Clear(); // Limpiar columnas previas

            dgvProductos.Columns.Add("NombreProducto", "Nombre del Producto");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Categoria", "Categoría");

            dgvProductos.AutoGenerateColumns = true; // Desactiva la generación automática de columnas
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

