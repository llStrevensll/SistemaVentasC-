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
    public partial class Administrador : FormBase {
        public Administrador() {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void Administrador_FormClosing(object sender, FormClosingEventArgs e) {
            //Cerrar aplicación
            Application.Exit();
        }

        private void Administrador_Load(object sender, EventArgs e) {

            string consulta = "SELECT * FROM Usuarios WHERE id_usuario=" + Login.codigo;
            DataSet Data = Biblioteca.Herramientas(consulta);//guarda en cache la consulta        

            //Obtener campos 
            lAdmin.Text = Data.Tables[0].Rows[0]["username"].ToString();
            lAdminUser.Text = Data.Tables[0].Rows[0]["account"].ToString();
            lAdminCodigo.Text = Data.Tables[0].Rows[0]["id_usuario"].ToString();

            //Imagen
            //Ontener imagen
            string imagen = Data.Tables[0].Rows[0]["imagen"].ToString();
            pictureBox1.Image = Image.FromFile(imagen);//visualizar la imagen en el picturebox
        }

        private void lAdminUser_Click(object sender, EventArgs e) {

        }

        private void lAdminCodigo_Click(object sender, EventArgs e) {

        }

        private void lAdmin_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            //Principal
            ContenedorPrincipal con_principal = new ContenedorPrincipal();
            this.Hide();
            con_principal.Show();

        }
    }
}
