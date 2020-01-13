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
    public partial class Facturacion : Procesos {
        public Facturacion() {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e) {

        }

        private void Facturacion_Load(object sender, EventArgs e) {
            //traer el nombre del usuario->vendedor
            string vendedor = "SELECT * FROM Usuarios WHERE id_usuario = " + Login.codigo;
            //Console.WriteLine("vendedoreeeeeeeeeeeeeee: " + vendedor);

            DataSet dataSet;
            dataSet = Biblioteca.Herramientas(vendedor);
            //Console.WriteLine("vendedoreeeeeeeeeeeeeee: " +  dataSet.Tables[0].Rows[0]["username"].ToString().Trim());

            lbVendedor.Text = dataSet.Tables[0].Rows[0]["username"].ToString().Trim();

        }

        //Buscar
        private void BtBuscar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(TxtCodigoCliente.Text.Trim()) == false) {
                    string cmd = string.Format("SELECT nombre_cliente FROM Clientes WHERE id_cliente = '{0}'", TxtCodigoCliente.Text.Trim());
                    DataSet dataset = Biblioteca.Herramientas(cmd);

                    TxtCliente.Text = dataset.Tables[0].Rows[0]["nombre_cliente"].ToString().Trim();

                    TxtCodigoProducto.Focus();//Focus


                }
            } catch (Exception error) {
                MessageBox.Show("Ha ocurrido un error" + error.Message);
            }
            
        }

        private void label8_Click_1(object sender, EventArgs e) {

        }

        private void TxtCodigoProducto_TextChanged(object sender, EventArgs e) {

        }

        private void label12_Click(object sender, EventArgs e) {

        }
        //Contador y Total
        public static int contadorFila = 0;
        public static double total;

        //Boton Colocar
        private void BtColocar_Click(object sender, EventArgs e) {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false) {
                bool existe = false;
                int numeroFila = 0;

                if (contadorFila == 0) {//Primera Fila adiciona
                    //Adicionar los campos al datagridview
                    dataGridView1.Rows.Add(TxtCodigoProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);

                    //Adicionar el importe (precio*cantidad)
                    double importe = Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[3].Value);
                    dataGridView1.Rows[contadorFila].Cells[4].Value = importe;

                    contadorFila++;
                }else {
                    foreach (DataGridViewRow fila in dataGridView1.Rows) {
                        //desplazar abajo
                        if (fila.Cells[0].Value.ToString() == TxtCodigoProducto.Text) {
                            existe = true;//ahora ya existe la fila
                            numeroFila = fila.Index;
                        }
                        
                    }
                    if (existe == true) {//Si ya existe la fila, solo opera cantidad y modifica importe
                        dataGridView1.Rows[numeroFila].Cells[3].Value = (Convert.ToDouble(TxtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value)).ToString();//Suma 2 double -> convierte a string
                        double importe = Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value);

                        dataGridView1.Rows[numeroFila].Cells[4].Value = importe;

                    } else {//Sino adiciona la nueva fila abajo de las existentes

                        //Adicionar los campos al datagridview
                        dataGridView1.Rows.Add(TxtCodigoProducto.Text, TxtDescripcion.Text, TxtPrecio.Text, TxtCantidad.Text);
                        //Adicionar el importe (precio*cantidad)
                        double importe = Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[contadorFila].Cells[3].Value);
                        dataGridView1.Rows[contadorFila].Cells[4].Value = importe;

                        contadorFila++;
                    }
                }

                total = 0;

                foreach (DataGridViewRow fila in dataGridView1.Rows) {
                    //Sumar celda 4(importe)
                    total += Convert.ToDouble(fila.Cells[4].Value);

                    
                }
                Console.WriteLine("lbtotal: " + total);
                lbTotal.Text = "USD$ " + total.ToString();


            }

        }

        //Boton Eliminar
        private void BtEliminar_Click(object sender, EventArgs e) {
            if (contadorFila > 0) {
                total = total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));//Indice de la fila actual, valor
                lbTotal.Text = "USD$ " + total.ToString();

                //Eliminar
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                contadorFila--;//reducir contador
            }
        }

        //Boton Clientes
        private void BtClientes_Click(object sender, EventArgs e) {

            ConsultarCliente consultarCliente = new ConsultarCliente();
            consultarCliente.ShowDialog();

            if (consultarCliente.DialogResult == DialogResult.OK) {//DialogResult s de la clase padre Consultas

                TxtCodigoCliente.Text = consultarCliente.dataGridView1.Rows[consultarCliente.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtCliente.Text = consultarCliente.dataGridView1.Rows[consultarCliente.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

                TxtCodigoProducto.Focus();
            }
        }

        //Boton Productos
        private void BtProductos_Click(object sender, EventArgs e) {

            ConsultarProducto consultarProducto = new ConsultarProducto();
            consultarProducto.ShowDialog();

            if (consultarProducto.DialogResult == DialogResult.OK) {

                TxtCodigoProducto.Text = consultarProducto.dataGridView1.Rows[consultarProducto.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtDescripcion.Text = consultarProducto.dataGridView1.Rows[consultarProducto.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                TxtPrecio.Text = consultarProducto.dataGridView1.Rows[consultarProducto.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();

                TxtCantidad.Focus();
            }
        }

        //BotonNuevo
        private void BtNuevo_Click(object sender, EventArgs e) {
            Nuevo();
        }

        public override void Nuevo() {
            TxtCodigoCliente.Text = "";
            TxtCliente.Text = "";
            TxtCodigoProducto.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
            lbTotal.Text = "USD$ 0";
            dataGridView1.Rows.Clear();
            contadorFila = 0;
            total = 0;

            TxtCodigoCliente.Focus();
        }

        //Boton Facturar
        private void BtFacturar_Click(object sender, EventArgs e) {

            if (contadorFila != 0) {//tiene contenido
                try {
                    //Procedimiento ActualizarFacturas
                    string cmd = string.Format("Exec ActualizarFacturas '{0}'", TxtCodigoCliente.Text.Trim());

                    DataSet dataSet = Biblioteca.Herramientas(cmd);

                    string numeroFactura = dataSet.Tables[0].Rows[0]["numeroFactura"].ToString().Trim();

                    foreach (DataGridViewRow fila in dataGridView1.Rows) {//Actualizar Detalles
                        cmd = string.Format("Exec ActualizarDetalles '{0}','{1}','{2}','{3}'", numeroFactura, fila.Cells[0].Value.ToString(), fila.Cells[2].Value.ToString(), fila.Cells[3].Value.ToString() );
                        dataSet = Biblioteca.Herramientas(cmd);
                    }

                    //Datos Facturas
                    cmd = "Exec DatosFactura " + numeroFactura;
                    dataSet = Biblioteca.Herramientas(cmd);

                    Factura factura = new Factura();
                    factura.reportViewer1.LocalReport.DataSources[0].Value = dataSet.Tables[0];
                    factura.ShowDialog();

                    Nuevo();

                } catch (Exception error) {

                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }
    }
}
