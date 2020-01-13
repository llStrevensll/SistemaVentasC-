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
    public partial class MantenimientoProductos : Mantenimiento {
        public MantenimientoProductos() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        //Guardar Producto en la BD
        public override Boolean Guardar() {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false) {
                try {
                    //EXEC-> Llamar al procedimiento almacenado
                    string insertar = string.Format("EXEC ActualizarProductos '{0}', '{1}', '{2}'", textId_Producto.Text.Trim(), textDescripcion.Text.Trim(), textPrecio.Text.Trim());
                    Biblioteca.Herramientas(insertar);
                    MessageBox.Show("Producto guardado correctamente");
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
                string eliminar = string.Format("EXEC EliminarProductos '{0}'", textId_Producto.Text.Trim());
                Biblioteca.Herramientas(eliminar);
                MessageBox.Show("El producto se ha eliminado correctamente");

            } catch (Exception error) {
                MessageBox.Show("Ha ocurrido un error: " + error);
            }

        }

        private void button3_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void textId_Producto_TextChanged(object sender, EventArgs e) {
            //Eliminar los errores
            errorProvider1.Clear();
        }

        private void textDescripcion_TextChanged(object sender, EventArgs e) {

        }

        //Boton Nuevo Registro
        private void button4_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textId_Producto.Text.Trim()) == false && string.IsNullOrEmpty(textDescripcion.Text.Trim()) == false && string.IsNullOrEmpty(textPrecio.Text.Trim()) == false) {
                textId_Producto.Text = "";
                textDescripcion.Text = "";
                textPrecio.Text = "";
            }
        }

        //Boton Consultar Clientes
        private void button1_Click(object sender, EventArgs e) {
            ConsultarProducto consultarProducto = new ConsultarProducto();
            consultarProducto.Show();
        }
    }
}
