using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WfaTiendaStock2_LAB3.Clases
{
    internal class DbCategoria
    {
        private String CadenaConexión = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\BaseDatos\\Db-TiendStock2.accdb";
        private String tabla = "Categoría";

        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter adaptador;

       public string BuscarCategoria(Int32 IdCategoria)
        {
            try
            {
                Conexion.ConnectionString = CadenaConexión;
                Conexion.Open();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = tabla;
                OleDbDataReader DR = Comando.ExecuteReader();

                String resultadoBarrio = "";

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {

                        if (DR.GetInt32(0) == IdCategoria)
                        { 
                            // le asigno el nombre de loa categoría a la variable
                            resultadoBarrio = DR.GetString(1);
                        }

                    }
                }

                Conexion.Close();

                return resultadoBarrio;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }
        public void AgregarCategoria(System.Windows.Forms.ComboBox combo)
        {
            try
            {
                Conexion.ConnectionString = CadenaConexión;
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.TableDirect;
                Comando.CommandText = tabla;

                adaptador = new OleDbDataAdapter(Comando);
                DataSet datos = new DataSet();
                adaptador.Fill(datos, tabla);

                combo.DataSource = datos.Tables[tabla];
                combo.DisplayMember = "Descripción";
                combo.ValueMember = "IdCategoria";
                Conexion.Close();

            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }
    }
}
