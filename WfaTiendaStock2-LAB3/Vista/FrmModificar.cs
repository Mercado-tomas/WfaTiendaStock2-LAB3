using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WfaTiendaStock2_LAB3
{
    public partial class FrmModificar : Form
    {
        public FrmModificar()
        {
            InitializeComponent();
        }
        // carga de formulario
        private void FrmModificar_Load(object sender, EventArgs e)
        {
            VerProductos();
        }

        // metodo para mostrar los datos apenas se abra
        public void VerProductos() { 
            DbProductos dbProductos = new DbProductos();
            DataTable dtProductos = dbProductos.VerProductos();
            if (dtProductos.Rows.Count > 0) {
                dgvProductos.DataSource = dtProductos;
                // Limpiar puntos anteriores en el gráfico
                chart1.Series.Clear();

                // Crear una nueva serie para el gráfico
                var series = new Series("Productos");
                series.ChartType = SeriesChartType.Bar; // Tipo de gráfico de barras

                // Llenar el gráfico con datos
                foreach (DataRow row in dtProductos.Rows)
                {
                    string nombreProducto = row["Nombre"].ToString(); 
                    decimal precio = Convert.ToDecimal(row["Precio"]); 
                    int stock = Convert.ToInt32(row["Stock"]); 

                    // Agregar puntos al gráfico, usando el nombre del producto como etiqueta
                    series.Points.AddXY(nombreProducto, stock); 
                }

                // Agregar la serie al chart
                chart1.Series.Add(series);
                chart1.ChartAreas[0].AxisX.Title = "Productos";
                chart1.ChartAreas[0].AxisY.Title = "Stock";
            }
            else {
                MessageBox.Show("No hay productos para mostrar","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) ||
                string.IsNullOrEmpty(txtNombreProducto.Text) ||
                string.IsNullOrEmpty(txtDescripcion.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int codigo = int.Parse(txtCodigo.Text);
            string nombre = txtNombreProducto.Text;
            string descripcion = txtDescripcion.Text;
            double precio = double.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);

            DbProductos dbProductos = new DbProductos();
            bool cargaNuevosDatos = dbProductos.ModificarProducto(codigo,nombre,descripcion,precio,stock);

            if (cargaNuevosDatos)
            {
                MessageBox.Show("El producto se modifico con exito","Exito!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                VerProductos();
            }
            else {
                MessageBox.Show("El codigo del producto no existe.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
