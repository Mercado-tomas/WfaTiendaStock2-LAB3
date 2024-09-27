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
    public partial class FrmApp : Form
    {
        public FrmApp()
        {
            InitializeComponent();
        }

        private void btnPruebaDb_Click(object sender, EventArgs e)
        {
          
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

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            int? codigo = null;
            if (!string.IsNullOrEmpty(txtCodigo.Text)) {
                if (int.TryParse(txtCodigo.Text, out int cod)) {
                    codigo = cod;
                }
            } 
            //}
            //else {
            //    MessageBox.Show("El codigo ingresado es invalido!","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);

            //     }
            //codigo = string.IsNullOrEmpty(txtCodigo.Text) ? null : int.Parse(txtCodigo.Text);
            string nombre = string.IsNullOrEmpty(txtNombre.Text) ? null : txtNombre.Text;
            //string categoria = string.IsNullOrEmpty(txtCategoria.Text) ? null : txtCategoria.Text;

            // instanciamos la tabla y conectamos
            DbProductos dbProductos = new DbProductos();
            DataTable dtProductos = dbProductos.BuscarProductos(codigo,nombre);
            if (dtProductos.Rows.Count > 0)
            {
                dgvProductos.DataSource = dtProductos;
            }
            else {
                MessageBox.Show("No se encontraron los productos que intenta filtrar","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DbProductos dbProductos = new DbProductos();
            

            dbProductos.ReporteProductos();
            MessageBox.Show("Reporte guardado exitosamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
