using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace WfaTiendaStock2_LAB3
{

    public class DbProductos
    {
        // conexion a base
        private string ruta;
        public DbProductos()
        {
            ruta = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\Db-TiendStock2.accdb";
        }

        // metodo para comprobar el acceso a la base
        public void VerificarConexion()
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    MessageBox.Show("Conexion Exitosa!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede conectar", "Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // metodo para ver todos los productos de la base
        public DataTable VerProductos()
        {
            // instanciacion de objeto de tipo datatable
            // datatable guarda la info en forma de tabla en memoria
            DataTable dtProductos = new DataTable();
            try
            {
                // conexion con base de datos
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    // query para devolver todos los datos
                    string query = "SELECT * FROM Productos";
                    // adaptador que ejecuta la query y conecta base de datos y el objeto datatable
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conexion))
                    {
                        // metodo para llenar el datatable con los datos obtenidos desde base de datos
                        adapter.Fill(dtProductos);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden obtener registros.", "Error" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtProductos;
        }

        // metodo para modificar productos
        public bool ModificarProducto(int codigo, string nombre, string descripcion, double precio, int stock)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string queryValidar = "SELECT COUNT(*) FROM Productos WHERE Codigo = @codigo";
                    using (OleDbCommand comandoValidar = new OleDbCommand(queryValidar, conexion))
                    {
                        comandoValidar.Parameters.AddWithValue("@codigo", codigo);
                        int contador = (int)comandoValidar.ExecuteScalar();
                        if (contador == 0)
                        {
                            return false;
                        }
                        // se actualizan los datos
                        string query = "UPDATE Productos SET Nombre = @nombre,Descripcion = @descripcion,Precio = @precio,Stock = @stock WHERE Codigo = @codigo";
                        using (OleDbCommand comando = new OleDbCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@nombre", nombre);
                            comando.Parameters.AddWithValue("@descripcion", descripcion);
                            comando.Parameters.AddWithValue("@precio", precio);
                            comando.Parameters.AddWithValue("@stock", stock);

                            int rowsAfectados = comando.ExecuteNonQuery();
                            return rowsAfectados > 0;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al modificar producto" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // metodo para eliminar productos
        public bool EliminarProducto(int codigo)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta))
                {
                    conexion.Open();
                    string queryValidar = "SELECT COUNT(*) FROM Productos WHERE Codigo = @codigo";
                    using (OleDbCommand comando = new OleDbCommand(queryValidar, conexion))
                    {
                        comando.Parameters.AddWithValue("@codigo", codigo);
                        int contador = (int)comando.ExecuteScalar();
                        if (contador == 0)
                        {
                            return false;
                        }
                    }
                    string query = "DELETE FROM Productos WHERE Codigo = @codigo";
                    using (OleDbCommand comando = new OleDbCommand(query,conexion)) {
                        comando.Parameters.AddWithValue("@codigo",codigo);
                        int rowsAfectados = comando.ExecuteNonQuery();
                        return rowsAfectados > 0;
                    }
                }

                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show("No se pudo borrar el producto." + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // metodo para agregar producto
        public bool AgregarProducto(string nombre, string descripcion, double precio, int stock)
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) {
                    conexion.Open();
                    string query = "INSERT INTO Productos(Nombre,Descripcion,Precio,Stock) VALUES (@nombre,@descripcion,@precio,@stock)";

                    using (OleDbCommand comando = new OleDbCommand(query,conexion)) {
                        comando.Parameters.AddWithValue("@nombre",nombre);
                        comando.Parameters.AddWithValue("@descripcion", descripcion);
                        comando.Parameters.AddWithValue("@precio", precio);
                        comando.Parameters.AddWithValue("@stock", stock);

                        int rowsAfectado = comando.ExecuteNonQuery(); 
                        return rowsAfectado > 0;
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show("Error al ingresar nuevo producto." + e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        // metodo para buscar un producto
        public DataTable BuscarProductos(int? codigo = null,string nombre = null,string categoria = null) { 
            DataTable dtProductos = new DataTable();
            try {
                using (OleDbConnection conexion = new OleDbConnection(ruta)) {
                    conexion.Open();
                    // el 1=1 ayuda a la adicion del where
                    string query = "SELECT * FROM Productos WHERE 1=1";
                    // validamos los ingresos
                    if (codigo.HasValue) {
                        query += " AND Codigo = @codigo";
                        
                    }
                    if (!string.IsNullOrEmpty(nombre)) {
                        query += " AND Nombre = @nombre";
                    }
                    if (!string.IsNullOrEmpty(categoria)) {
                        query += " AND Categoria = @categoria";
                    }
                    // armamos la query y conectamos con base de datos mediante command
                    using (OleDbCommand comando = new OleDbCommand(query,conexion)) {
                        if (codigo.HasValue) {
                            comando.Parameters.AddWithValue("@codigo",codigo.Value);
                        }
                        if (!string.IsNullOrEmpty(nombre)) {
                            comando.Parameters.AddWithValue("@nombre","%" + nombre + "%");
                        }
                        if (!string.IsNullOrEmpty(categoria)) {
                            comando.Parameters.AddWithValue("@categoria","%"+categoria+"%");
                        }

                        // adaptamos el codigo obtenido para poder mostrarlo en dgv
                        using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando)) {
                            adaptador.Fill(dtProductos);
                        }
                    }
                }
            }catch (Exception e)
            {
                MessageBox.Show("No se puede buscar el producto" + e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return dtProductos;



        }

        // metodo para generar el report
        public void GenerarReporte(string rutaArchivo)
        {
            try {
                // usamos el metodo para visualizar los productos y devolverlos
                DataTable dtProductos = VerProductos();
                using (StreamWriter sw = new StreamWriter(rutaArchivo))
                {
                    sw.WriteLine("Reporte de Productos");
                    sw.WriteLine("====================");
                    sw.WriteLine("Código\tNombre\tDescripción\tPrecio\tCategoría\tStock");

                    foreach (DataRow row in dtProductos.Rows)
                    {
                        sw.WriteLine($"{row["Codigo"]}\t{row["Nombre"]}\t{row["Descripcion"]}\t{row["Precio"]}\t{row["Categoria"]}\t{row["Stock"]}");
                    }
                    MessageBox.Show("Reporte generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception e)
            {
                MessageBox.Show("Problema al cargar el reporte." + e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }    
   }
