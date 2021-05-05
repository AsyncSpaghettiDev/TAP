using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace TallerCarroceria {
    enum MenuStatus {
        Deployed,
        Undeployed
    }
    public enum ActiveScreen {
        Login,
        Home,
        Clientes,
        Vehiculos,
        Servicio,
        Trabajadores,
        Especialidades,
        Catalogo,
        Herramientas
    }
    public partial class Form1 : Form {
        private MenuStatus menu = MenuStatus.Deployed;
        UserControl active = null;
        private ActiveScreen PantallaActual {
            set {
                this.bunifuTransition3.HideSync(this.active);
                switch (value) {
                    case ActiveScreen.Home:
                        this.active = this.home1;
                        break;

                    case ActiveScreen.Clientes:
                        this.active = this.clientes1;
                        break;

                    case ActiveScreen.Servicio:
                        this.active = this.servicio1;
                        break;

                    case ActiveScreen.Trabajadores:
                        this.active = this.trabajadores1;
                        break;

                    case ActiveScreen.Especialidades:
                        this.active = this.especialidades1;
                        break;

                    case ActiveScreen.Catalogo:
                        this.active = this.catalogo1;
                        break;

                    case ActiveScreen.Herramientas:
                        this.active = this.herramientas1;
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
        readonly Form control;
        public Form1(Form control) {
            InitializeComponent();
            this.control = control;

            this.home1.Visible = false;
            this.clientes1.Visible = false;
            this.servicio1.Visible = false;
            this.catalogo1.Visible = false;
            this.herramientas1.Visible = false;
            this.trabajadores1.Visible = false;
            this.especialidades1.Visible = false;
            this.active = this.home1;
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
        private void form1_Load( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Home;
            this.MenuLat = MenuStatus.Deployed;
        }
        private void mEnter(object sender, EventArgs e) => ( sender as Control ).BackColor = Color.FromArgb(146, 13, 24);
        private void mExit(object sender, EventArgs e) => ( sender as Control ).BackColor = Color.Transparent;
        private void pictureBox4_Click( object sender, EventArgs e ) {
            Hide();
            this.control.Show();
        }
        private void homeScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Home;
        }
        private void serviceScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Servicio;
        }
        private void clientScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Clientes;
        }
        private void workersScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Trabajadores;
        }
        private void specialScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Especialidades;
        }
        private void catalogueScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Catalogo;
        }
        private void toolScreen( object sender, EventArgs e ) {
            this.PantallaActual = ActiveScreen.Herramientas;
        }
    }
}
