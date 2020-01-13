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
    public partial class MantenimientoClientes : Mantenimiento {
        public MantenimientoClientes() {
            InitializeComponent();
        }

        //Guardar Producto en la BD
        public override Boolean Guardar() {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false) {
                try {
                    //EXEC-> Llamar al procedimiento almacenado
                    string insertar = string.Format("EXEC ActualizarClientes '{0}', '{1}', '{2}'", textId_Cliente.Text.Trim(), textId_Nombre.Text.Trim(), textId_Apellido.Text.Trim());
                    Biblioteca.Herramientas(insertar);
                    MessageBox.Show("Cliente guardado correctamente");
                    return true;
                } catch (Exception error) {
                    MessageBox.Show("Ha ocurrudo un error" + error);
                    return false;
                }
            } else {
                return false;
            }
        }

        //Eliminar el producto en la BD
        public override void Eliminar() {
            //Console.WriteLine("Estoy en Eliminarrrrrrrrrarararra--------asdasdasd");

            try {
                //EXEC-> Llamar al procedimiento almacenado
                string eliminar = string.Format("EXEC EliminarCliente '{0}'", textId_Cliente.Text.Trim());
                Biblioteca.Herramientas(eliminar);
                MessageBox.Show("El Cliente se ha eliminado correctamente");

            } catch (Exception error) {
                MessageBox.Show("Ha ocurrido un error: " + error);
            }

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        //Boton Consultar
        private void button1_Click(object sender, EventArgs e) {
            ConsultarCliente consultarCliente = new ConsultarCliente();
            consultarCliente.Show();
        }

        private void textId_Cliente_TextChanged(object sender, EventArgs e) {
            //Eliminar los errores
            errorProvider1.Clear();
        }

        //Boton Nuevo Registro
        private void button4_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textId_Cliente.Text.Trim()) == false && string.IsNullOrEmpty(textId_Nombre.Text.Trim()) == false && string.IsNullOrEmpty(textId_Apellido.Text.Trim()) == false) {
                textId_Cliente.Text = "";
                textId_Nombre.Text = "";
                textId_Apellido.Text = "";
            }
        }
    }
}
