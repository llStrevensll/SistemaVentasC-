using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibreriaDLL;

namespace SistemaVentas {
    public partial class Login : FormBase {
        public Login() {
            InitializeComponent();
        }
        //Codigo del usuario
        public static String codigo = "";

        private void Form1_Load(object sender, EventArgs e) {

        }


        private void buttonIniciarSesion_Click(object sender, EventArgs e) {
            //Libreria ddl: Tiene la clase Biblioteca con la conexion a BD
            try {
                //Trim quita espacios en blanco
                string validar = string.Format("Select * FROM Usuarios WHERE account='{0}' AND password='{1}'",textBoxUsuario.Text.Trim(),textBoxPassword.Text.Trim());
                DataSet conectar = Biblioteca.Herramientas(validar);

                //Identificar cuenta y contrasena
                codigo = conectar.Tables[0].Rows[0]["id_usuario"].ToString().Trim();
                string cuenta = conectar.Tables[0].Rows[0]["account"].ToString().Trim();
                string contrasena = conectar.Tables[0].Rows[0]["password"].ToString().Trim();

                if (cuenta == textBoxUsuario.Text.Trim() && contrasena == textBoxPassword.Text.Trim()) {
                    //Verificar si es administrador
                    if (Convert.ToBoolean(conectar.Tables[0].Rows[0]["validar_admin"].ToString().Trim()) == true) {
                        
                        Administrador admin = new Administrador();
                        this.Hide();
                        admin.Show();
                    } else {
                        Usuario user = new Usuario();
                        this.Hide();
                        user.Show();
                    }
                } 
            } catch (Exception error) {
                MessageBox.Show("Usuario o contrseña invalidos" + error);
            }

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e) {
            //Cerrar aplicación
            Application.Exit();
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e) {
            
        }

        private void btnSalir_Click(object sender, EventArgs e) {

        }

        private void btnSalir_MouseHover(object sender, EventArgs e) {
            btnSalir.BackColor = Color.FromArgb(255, 23, 68);
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(255, 23, 68);
            btnSalir.ForeColor = Color.White;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e) {
            btnSalir.BackColor = Color.White;
            btnSalir.FlatAppearance.BorderColor = Color.White;
            btnSalir.ForeColor = Color.Black;
        }
    }
}
