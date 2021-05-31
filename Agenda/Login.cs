using System;
using Conexion;
using System.Drawing;
using System.Windows.Forms;

namespace Agenda {
    public partial class Login : UserControl {
        readonly ControlCollection contenedor;
        readonly PictureBox addBtn;
        readonly BaseDatos @base;
        public Login( ControlCollection contenedor, PictureBox addBtn ) {
            this.Location = new Point(0, 170);
            InitializeComponent();
            this.@base = new BaseDatos(@"JONATHAN\JONATHANSERVER", "Agenda");
            this.contenedor = contenedor;
            this.addBtn = addBtn;
        }
        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            if (!string.IsNullOrWhiteSpace(this.bunifuTextBox1.Text) && !string.IsNullOrWhiteSpace(this.bunifuTextBox2.Text)) {
                if (this.@base.Login("Usuarios", $"nombreUsuario='{this.bunifuTextBox1.Text}' AND contrasenaUsuario='{Seguridad.Encriptar(this.bunifuTextBox2.Text)}'")) {
                    MessageBox.Show("¡Bienvenido!");
                    this.contenedor.Clear();
                    this.contenedor.Add(new ListaContactos(this.bunifuTextBox1.Text, this.addBtn));
                    Dispose();
                }
                else
                    MessageBox.Show("Credenciales Inválidas");
                this.bunifuTextBox1.Clear();
                this.bunifuTextBox2.Clear();
            }
            else
                MessageBox.Show("¡Ingresa datos en todos los campos!");
        }

        private void label3_Click( object sender, EventArgs e ) {
            this.contenedor.Clear();
            this.contenedor.Add(new Registrar(this.contenedor, this.addBtn));
        }
    }
}
