using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen {
    public partial class Form1 : Form {
        Button click;
        public Form1( ) {
            InitializeComponent();
        }

        private void Form1_Load( object sender, EventArgs e ) {
            this.click = new Button() {
                Size = new Size(50, 50),
                Text = "Examen",
                Location = new Point(100, 100)
            };
            this.click.Click += mensaje;
            this.Controls.Add(this.click);
            this.Size = new Size(500, 500);
        }

        private void mensaje( object sender, EventArgs e ) => MessageBox.Show("auch, me picaste");

        private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
            MessageBox.Show("adios");
        }

        private void label1_Click( object sender, EventArgs e ) {
            Process.Start("www.google.com");
        }

        private void textBox1_KeyPress( object sender, KeyPressEventArgs e ) {
            if (e.KeyChar == ( char ) Keys.Space)
                MessageBox.Show("No tocar el espacio");
        }

        private void Form1_ResizeEnd( object sender, EventArgs e ) {
            MessageBox.Show("cambiaste mi tamaño");
        }
    }
}
