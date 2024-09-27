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
using WfaTiendaStock2_LAB3.Clases;

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
            this.Close();
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            VerProductos();

            Int32 ctg = 0;
            ctg = Convert.ToInt32(cmbCategoria.SelectedValue);
            DbCategoria ObjCategoria = new DbCategoria();

            ObjCategoria.AgregarCategoria(cmbCategoria);
        }

        public void VerProductos()
        {
            DbProductos dbProductos = new DbProductos();
            DataTable dtProductos = dbProductos.VerProductos();
            if (dtProductos.Rows.Count > 0)
            {
                dgvProductos.DataSource = dtProductos;
                // Limpiar puntos anteriores en el gráfico
                chart1.Series.Clear();

                // Crear una nueva serie para el gráfico
                var series = new Series("Productos");
                series.ChartType = SeriesChartType.Bar; // Tipo de gráfico de barras

                // Llenar el gráfico con datos
                foreach (DataRow row in dtProductos.Rows)
                {
                    string nombreProducto = row["Nombre"].ToString(); // Cambia "Nombre" según tu columna
                    decimal precio = Convert.ToDecimal(row["Precio"]); // Cambia "Precio" según tu columna
                    int stock = Convert.ToInt32(row["Stock"]); // Cambia "Stock" según tu columna

                    // Agregar puntos al gráfico, usando el nombre del producto como etiqueta
                    series.Points.AddXY(nombreProducto, stock); // Puedes usar precio o stock como valor
                }

                // Agregar la serie al chart
                chart1.Series.Add(series);
                chart1.ChartAreas[0].AxisX.Title = "Productos";
                chart1.ChartAreas[0].AxisY.Title = "Stock";
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

            if (!double.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio ingresado invalido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Nro de stock ingresado invalido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DbProductos emp = new DbProductos();
            //emp.IdSocio = Convert.ToInt32( .Text);
            emp.Descripcion = txtDescripcion.Text;
            emp.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            emp.Nombre = txtNombreProducto.Text;
            emp.Stock = Convert.ToInt32(txtStock.Text);
            emp.Precio = Convert.ToDouble(txtPrecio.Text);

            
            emp.AgregarProducto();
            VerProductos();

            MessageBox.Show("Producto cargado exitosamente");
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

        }

            private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
            {

            }
        }
    }

