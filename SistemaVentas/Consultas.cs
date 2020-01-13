using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL;

namespace SistemaVentas {
    public partial class Consultas : FormBase {
        public Consultas() {
            InitializeComponent();
        }

        //Consulta a BD
        public DataSet mostrarInfoDG(string tabla) {//recibe la tabla
            DataSet dataSet;
            string cmd = string.Format("SELECT * FROM " + tabla);//Selecciona los datos de la tabla
            dataSet = Biblioteca.Herramientas(cmd);

            return dataSet;
        }

        private void button2_Click(object sender, EventArgs e) {

            if (dataGridView1.Rows.Count == 0) {
                return;
            } else {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
