using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaVisor {
    public partial class Form1 : Form {
        public Form1( ) {
            InitializeComponent();
            userControl11.ImagenSeleccionada += new ControlesPersonalizados.UserControl1.ImagenSeleccionadaDelegate(visorImagenSelecc);
        }
        private void visorImagenSelecc( object sender, ControlesPersonalizados.ImagenSeleccionadaArgs e ) {
            MessageBox.Show("Has pinchado en " + e.FileName);
        }
    }
}
