using System;
using System.Windows.Forms;

namespace TallerCarroceria {
    public partial class Login : UserControl {
        public Form2 control;
        public Login() {
            InitializeComponent();
        }

        private void pictureBox1_Click( object sender, EventArgs e ) {
            if (string.IsNullOrEmpty(this.bunifuTextBox1.Text) || string.IsNullOrEmpty(this.bunifuTextBox2.Text))
                MessageBox.Show("Llena los campos...");
            else if (this.bunifuTextBox1.Text == "admin" && this.bunifuTextBox2.Text == "admin") {
                this.bunifuTextBox1.Clear();
                this.bunifuTextBox2.Clear();
                this.control.PantallaActual = ActiveScreen.Home;
                new Form1(this.control).Show();
                this.control.Hide();
            }
            else
                MessageBox.Show("Credenciales Inválidas");
        }
    }
}
