﻿using System;
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
    public partial class Usuario : FormBase {
        public Usuario() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void Usuario_FormClosed(object sender, FormClosedEventArgs e) {
            //Cerrar aplicación
            Application.Exit();
        }

        private void Usuario_Load(object sender, EventArgs e) {
            string consulta = "SELECT * FROM Usuarios WHERE id_usuario=" + Login.codigo;
            DataSet Data = Biblioteca.Herramientas(consulta);//guarda en cache la consulta        

            //Obtener campos 
            lNombre.Text = Data.Tables[0].Rows[0]["username"].ToString();
            lUsuario.Text = Data.Tables[0].Rows[0]["account"].ToString();
            lCodigo.Text = Data.Tables[0].Rows[0]["id_usuario"].ToString();

            //Imagen
            //Obntener imagen
            string imagen = Data.Tables[0].Rows[0]["imagen"].ToString();
            Console.WriteLine("asasas: "+ imagen);
            pictureBox1.Image = Image.FromFile(imagen);//visualizar la imagen en el picturebox
        }

        private void button1_Click(object sender, EventArgs e) {
            //Principal
            ContenedorPrincipal con_principal = new ContenedorPrincipal();
            this.Hide();
            con_principal.Show();
        }
    }
}
