using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hipodromo {
    public partial class Home : Form {
        public Home( ) {
            InitializeComponent();
        }

        private void button_Click( object sender, EventArgs e ) {
            new Form1(int.Parse(( sender as Control ).Tag.ToString())).Show();
            Dispose(false);
        }

        private void home_FormClosed( object sender, FormClosedEventArgs e ) {
            Application.Exit();
        }
    }
}
