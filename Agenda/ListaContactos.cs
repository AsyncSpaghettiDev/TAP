using System;
using Conexion;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Agenda {
    public partial class ListaContactos : UserControl {
        int h = 0;
        int nid = 0;
        readonly PictureBox agregarBtn;
        readonly string usuario;
        readonly BaseDatos @base;
        public ListaContactos( string usuario, PictureBox agregarBtn ) {
            InitializeComponent();
            this.usuario = usuario;
            this.agregarBtn = agregarBtn;
            this.@base = new BaseDatos(@"JONATHAN\JONATHANSERVER", "Agenda");
            CargarContactos();
        }
        public void CargarContactos( ) {
            List<string[]> contactos = this.@base.Buscar("Contactos", $"nombreUsuario='{this.usuario}'", out this.h);
            this.Controls.Clear();
            this.h = 0;
            foreach (string[] contacto in contactos) {
                this.Controls.Add(new Contacto(this, this.usuario, contacto[ 0 ].ToString(), contacto[ 1 ].ToString(), contacto[ 2 ].ToString(), contacto[ 3 ].ToString(), contacto[ 4 ].ToString()) {
                    Location = new Point(5, h * 165)
                });
                this.h++;
            }
            this.agregarBtn.Show();
        }
        public void AgregarContacto( ) {
            this.Controls.Add(new Contacto(this, this.usuario, this.nid, this.agregarBtn) {
                Location = new Point(5, h * 165)
            });
            this.h++;
            this.nid++;
            this.agregarBtn.Hide();
        }
    }
}
