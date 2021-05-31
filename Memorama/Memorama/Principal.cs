using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama {
    public partial class Principal : Form {
        public Principal( ) {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e ) {
            new Memorama(1).Show();
            Dispose(false);
        }

        private void button2_Click( object sender, EventArgs e ) {
            new Memorama(2).Show();
            Dispose(false);
        }

        private void button3_Click( object sender, EventArgs e ) {
            new Memorama(3).Show();
            Dispose(false);
        }
        private void principal_FormClosing( object sender, FormClosingEventArgs e ) {
            Application.Exit();
        }
    }
}
