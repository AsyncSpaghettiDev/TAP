using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universidad {
    public partial class Form1 : Form {
        public Form1( ) {
            InitializeComponent();
        }

        private void pictureBox1_Click( object sender, EventArgs e ) {
            Application.Exit();
        }

        private void bunifuTileButton1_Click( object sender, EventArgs e ) {
            this.bunifuTransition2.HideSync(this.userControl21);
            this.bunifuTransition3.HideSync(this.userControl31);
            this.bunifuTransition1.ShowSync(this.userControl11);
        }

        private void bunifuTileButton2_Click( object sender, EventArgs e ) {
            this.bunifuTransition1.HideSync(this.userControl11);
            this.bunifuTransition3.HideSync(this.userControl31);
            this.bunifuTransition2.ShowSync(this.userControl21);
        }

        private void bunifuTileButton3_Click( object sender, EventArgs e ) {
            this.bunifuTransition1.HideSync(this.userControl11);
            this.bunifuTransition2.HideSync(this.userControl21);
            this.bunifuTransition3.ShowSync(this.userControl31);
        }

        private void Form1_Load( object sender, EventArgs e ) {
            this.bunifuTransition1.HideSync(this.userControl11);
            this.bunifuTransition2.HideSync(this.userControl21);
            this.bunifuTransition3.HideSync(this.userControl31);
        }
    }
}
