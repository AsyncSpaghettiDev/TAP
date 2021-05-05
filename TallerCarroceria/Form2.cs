using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace TallerCarroceria {
    public partial class Form2 : Form {
        private MenuStatus menu = MenuStatus.Deployed;
        UserControl active = null;
        public ActiveScreen PantallaActual {
            set {
                this.bunifuTransition3.HideSync(this.active);
                switch (value) {
                    case ActiveScreen.Home:
                        this.active = this.home1;
                        break;

                    case ActiveScreen.Clientes:
                        this.active = this.clientesVista1;
                        break;

                    case ActiveScreen.Vehiculos:
                        this.active = this.vehiculos1;
                        break;

                    case ActiveScreen.Login:
                        this.active = this.login1;
                        break;
                }
                this.bunifuTransition4.ShowSync(this.active);
                posicionar();
            }
        }
        private MenuStatus MenuLat {
            set {
                this.menu = value;
                if (value == MenuStatus.Undeployed) {
                    this.pictureBox3.Image = new ComponentResourceManager(typeof(Properties.Resources)).GetObject("deployed") as Image;
                    this.bunifuPanel4.Dock = DockStyle.None;
                    this.bunifuTransition1.HideSync(this.bunifuPanel2);
                    this.bunifuTransition2.ShowSync(this.bunifuPanel3);
                    this.bunifuPanel2.Dock = DockStyle.None;
                    this.bunifuPanel3.Dock = DockStyle.Left;
                    this.bunifuPanel4.Dock = DockStyle.Fill;
                }
                else {
                    this.pictureBox3.Image = new ComponentResourceManager(typeof(Properties.Resources)).GetObject("undeployed") as Image;
                    this.bunifuPanel4.Dock = DockStyle.None;
                    this.bunifuTransition2.HideSync(this.bunifuPanel3);
                    this.bunifuTransition1.ShowSync(this.bunifuPanel2);
                    this.bunifuPanel3.Dock = DockStyle.None;
                    this.bunifuPanel2.Dock = DockStyle.Left;
                    this.bunifuPanel4.Dock = DockStyle.Fill;
                }
                posicionar();
            }
            get => this.menu;
        }
        public Form2( ) {
            InitializeComponent();
            this.home1.Visible = false;
            this.clientesVista1.Visible = false;
            this.vehiculos1.Visible = false;
            this.login1.Visible = false;
            this.active = this.home1;
            this.login1.control = this;
        }
        private void posicionar( ) {
            this.active.Location = new Point(
                ( this.bunifuPanel4.Width - this.active.Width ) / 2,
                ( this.bunifuPanel4.Height - this.active.Height ) / 2);
        }
        private void pictureBox2_Click( object sender, EventArgs e ) {
            Application.Exit();
        }
        private void pictureBox3_Click( object sender, EventArgs e ) {
            if (this.MenuLat == MenuStatus.Deployed) 
                this.MenuLat = MenuStatus.Undeployed;
            else 
                this.MenuLat = MenuStatus.Deployed;
        }
        private void form2_Load( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Home;
            this.MenuLat = MenuStatus.Deployed;
        }
        private void mEnter( object sender, EventArgs e ) => ( sender as Control ).BackColor = Color.FromArgb(146, 13, 24);
        private void mExit( object sender, EventArgs e ) => ( sender as Control ).BackColor = Color.Transparent;
        private void bunifuTileButton1_Click( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Clientes;
        }
        private void bunifuTileButton2_Click( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Vehiculos;
        }
        private void pictureBox1_Click( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Home;
        }
        private void pictureBox4_Click( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Login;
        }
    }
}
