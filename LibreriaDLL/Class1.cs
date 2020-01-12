using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


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

        //Validar Formulario
        public static Boolean ValidarFormulario(Control objetoError, ErrorProvider errorProvider){

            //por defecto no hay errores
            Boolean siError = false;


            foreach (Control campo in objetoError.Controls) {//Revisar por cada campo si es de tipo error -coleccion del Forms
                if (campo is ErrorTxtBox) {//Si campo es ErrorTxtBox

                    ErrorTxtBox objeto = (ErrorTxtBox)campo; //Convertir a tipo ErrorTxtBox

                    if (objeto.Validar == true) {

                        //NUll o Vacio
                        if (string.IsNullOrEmpty(objeto.Text.Trim())) {//En los txtBox se usan cadenas  por ello usar string
                            errorProvider.SetError(objeto, "Los campos no pueden estar vacios");
                            siError = true;
                        } 
                    }
                    //Revisar que solo hayan numeros
                    if (objeto.ValidarNumeros == true) {
                        int contador = 0, encontrarLetras = 0;

                        foreach (char letra in objeto.Text.Trim()) {
                            if (char.IsLetter(objeto.Text.Trim(), contador)) {//Isletter: contador para revisar cada letra
                                encontrarLetras++;
                            }
                            contador++;
                        }
                        if (encontrarLetras != 0) {
                            siError = true;
                            errorProvider.SetError(objeto, "Solo se aceptan números");
                        }
                    }
                }
            }

            return siError;

        }
    }
}
