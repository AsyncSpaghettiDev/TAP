using System;
using System.Drawing;
using System.Windows.Forms;

namespace Agenda {
    public partial class Form1 : Form {
        public Form1( ) {
            InitializeComponent();
            this.pictureBox3.Hide();
        }
        private void pictureBox1_Click( object sender, EventArgs e ) => Application.Exit();

        private void pictureBox3_Click( object sender, EventArgs e ) {
            ( this.bunifuPanel2.Controls[ 0 ] as ListaContactos ).AgregarContacto();
        }
        private void pictureBox2_Click( object sender, EventArgs e ) {
            this.bunifuPanel2.Controls.Clear();
            this.pictureBox3.Hide();
            this.bunifuPanel2.Controls.Add(new Login(this.bunifuPanel2.Controls, this.pictureBox3));
        }
    }
}
