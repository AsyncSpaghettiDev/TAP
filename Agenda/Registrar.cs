using System;
using Conexion;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Agenda {
    public partial class Registrar : UserControl {
        readonly ToolTip error = new ToolTip();
        readonly ControlCollection contenedor;
        readonly PictureBox addBtn;
        readonly BaseDatos @base;
        public Registrar( ControlCollection contenedor, PictureBox addBtn ) {
            this.Location = new Point(0, 170);
            InitializeComponent();
            this.@base = new BaseDatos(@"JONATHAN\JONATHANSERVER", "Agenda");
            this.contenedor = contenedor;
            this.addBtn = addBtn;
        }

        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            if (!string.IsNullOrWhiteSpace(this.bunifuTextBox1.Text) && !string.IsNullOrWhiteSpace(this.bunifuTextBox2.Text))
                registrarUsuario();
            else
                MessageBox.Show("¡Ingresa datos en todos los campos!");
        }
        private void bunifuTextBox2_Validating( object sender, CancelEventArgs e ) {
            ToolTip advertencia = new ToolTip() {
                ToolTipTitle = "Contraseña Inválida"
            };
            if (string.IsNullOrWhiteSpace(this.bunifuTextBox2.Text)) {
                advertencia.Show("Ingresa una contraseña", sender as IWin32Window, 2000);
                e.Cancel = true;
            }
            else if (!validarPass()) {
                advertencia.Show("Tu contraseña debe contener al menos una letra minúscula, una letra mayúscula, un dígito y un caractér especial(!,#,$,%,&,/,¡,*)", sender as IWin32Window, 5000);
                e.Cancel = true;
            }
        }
        private void label3_Click( object sender, EventArgs e ) {
            this.contenedor.Clear();
            this.contenedor.Add(new Login(this.contenedor, this.addBtn));
        }
        private bool validarPass( ) {
            bool digit = false, special = false, caps = false;
            char[] pass = this.bunifuTextBox2.Text.ToCharArray();
            foreach (char c in pass) {
                if (Char.IsDigit(c))
                    digit = true;
                if (char.IsUpper(c))
                    caps = true;
                if (c == '!' || c == '#' || c == '$' || c == '%' || c == '&' || c == '/' || c == '¡' || c == '*')
                    special = true;
            }
            return digit && special && caps;
        }

        private void registrarUsuario( ) {
            this.error.ToolTipTitle = "¡Error!";
            string[] data = new string[] {
                $"('{this.bunifuTextBox1.Text}')",
                $"('{Seguridad.Encriptar(this.bunifuTextBox2.Text)}')"
            };
            if (this.@base.Alta("Usuarios", data)) {
                this.bunifuTextBox1.Clear();
                this.bunifuTextBox2.Clear();
                this.contenedor.Clear();
                this.contenedor.Add(new Login(this.contenedor, this.addBtn));
                Dispose();
                MessageBox.Show("Registro guardado correctamente");
            }
            else
                this.error.Show("Usuario ya en uso, seleccione otro", this.bunifuTextBox1, 5000);
        }
    }
}