using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace LibreriaDLL
{
    public class Biblioteca{

        //Dataset-> guardar temporalmente datos
        public static DataSet Herramientas(string cmd) {
            //Conexion a la BD
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SistemaVentas;Integrated Security=True");
            conexion.Open();

            //Instancia del dataset
            DataSet dllDataset = new DataSet();
            SqlDataAdapter dllSqlDataAdapter = new SqlDataAdapter(cmd, conexion);

            //Almacenar los datos en dataSet
            dllSqlDataAdapter.Fill(dllDataset);

            conexion.Close();

            return dllDataset;

        }
    }
}
