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
    public partial class Ventas : Consultas {
        public Ventas() {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = mostrarInfoDG("Facturas").Tables[0];
        }

        //Boton de Buscar
        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == false) {//sino null o vacio
                try {
                    DataSet dataset;
                    string buscar = "Select * from Facturas WHERE numeroFactura LIKE ('%" + textBox1.Text.Trim() + "%')";//alguna letra % %

                    dataset = Biblioteca.Herramientas(buscar);

                    dataGridView1.DataSource = dataset.Tables[0];

                } catch (Exception error) {

                    MessageBox.Show("No se puede conectar, Error: " + error.Message);
                }
            }
        }
    }
}
