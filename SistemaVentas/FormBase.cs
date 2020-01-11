using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentas {
    public partial class FormBase : Form {
        public FormBase() {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            //Mensaje de advertencia-pregunta
            if (MessageBox.Show("Desea Salir? ","Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                this.Close();
            }
        }

        //Metodos virtuales
        public virtual void Eliminar() {

        }
        public virtual void Nuevo() {

        }

        public virtual void Consultar() {

        }

        public virtual Boolean Guardar() {
            return false;
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e) {
            //Cerrar aplicación
            //Application.Exit();
        }
    }
}
