using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace WfaTiendaStock2_LAB3.Clases
{
    internal class DbCategoria
    {
        private String CadenaConexión = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\BaseDatos\\Db-TiendStock2.accdb";
        private String tabla = "Categoría";

        private OleDbConnection Conexion = new OleDbConnection();
        private OleDbCommand Comando = new OleDbCommand();
        private OleDbDataAdapter adaptador;

        public void AgregarCategoria(ComboBox combo)
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
