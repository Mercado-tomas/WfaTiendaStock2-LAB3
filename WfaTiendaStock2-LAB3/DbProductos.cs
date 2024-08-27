using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Data;

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
                        string query = "UPDATE Productos SET Nombre = @nombre,Descripcion = @descripcion,Precio = @precio,Stock = @Stock";
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

    }    
   }
