using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ControlesPersonalizados {
    public partial class UserControl1 : UserControl {
        public delegate void ImagenSeleccionadaDelegate( object sender, ImagenSeleccionadaArgs e );
        public event ImagenSeleccionadaDelegate ImagenSeleccionada;

        // Variables para controlar propiedades
        private string directorio = null;
        private int dimension;
        private int separacion;

        // Variables para calculos internos
        readonly private int borde = 7;
        readonly private List<ImagenNombre> imagenes = new List<ImagenNombre>();

        // Get's y setter's
        public string Directorio {
            get => this.directorio;
            set {
                this.directorio = value;
                getImagenes();
                updateControl();
            }
        }
        public int Dimension {
            get => this.dimension;
            set {
                this.dimension = value;
                updateControl();
            }
        }
        public int Separacion {
            get => this.separacion;
            set {
                this.separacion = value;
                updateControl();
            }
        }
        // Constructor
        public UserControl1( ) {
            InitializeComponent();
        }
        // Se obtienen todas las iamgenes del directorio dado
        private void getImagenes( ) {
            if (!string.IsNullOrEmpty(this.directorio)) {
                this.imagenes.Clear();
                DirectoryInfo dir = new DirectoryInfo(this.Directorio);
                foreach (FileInfo file in dir.GetFiles("*.jpg")) {
                    this.imagenes.Add(new ImagenNombre(Image.FromFile(file.FullName), file.FullName));
                }
            }
        }
        // Se crea la funcion para mostrar las imagenes
        private void updateControl( ) {
            // Se suspende el refresh para evitar errores
            this.panel1.SuspendLayout();
            // Se cierran todos los controles que tengamos
            foreach (Control ctr in this.panel1.Controls)
                ctr.Dispose();
            // Se limpian los controles
            this.panel1.Controls.Clear();
            // Se definen variables locales para estabelecer la posiciom
            int col = this.borde, fila = this.borde;
            // Se crean picturesBox en con los datos obtenidos de la lista
            foreach (ImagenNombre img in this.imagenes) {
                // Se crea un pictoreBox y se definen sus atributos
                PictureBox pic = new PictureBox() {
                    Image = img.Imagen,
                    Tag = img.FileName,
                    Size = new Size(this.dimension, this.dimension),
                    Location = new Point(col, fila),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                // Se añade a la lista de controles del panel
                this.panel1.Controls.Add(pic);
                pic.Click += new EventHandler(pic_Click);

                // Se define el proximo valor para columna y fila
                col += this.dimension + this.separacion;
                // En caso que ya no se pueda seguir añadiendo a lo ancho se saltará a la siguiente fila y se "restablece" la columna
                if (( col + this.dimension + this.separacion + this.borde ) > this.Width) {
                    col = this.borde;
                    fila += this.dimension + this.separacion;
                }
            }
            // Se reanuda el refresh
            this.panel1.ResumeLayout();
        }
        // Se refrescan las imagenes
        public void Refresh( ) {
            getImagenes();
            updateControl();
        }
        // Actualizar tamaño de imagenes
        protected override void OnSizeChanged( EventArgs e ) {
            updateControl();
            base.OnSizeChanged(e);
        }
        // Evento de click en un picture box
        private void pic_Click( object sender, EventArgs e) {
            PictureBox picSeleccionado = ( PictureBox ) sender;
            ImagenSeleccionadaArgs args = new ImagenSeleccionadaArgs(picSeleccionado.Image, (string)picSeleccionado.Tag);
            ImagenSeleccionada(this, args);
        }
    }
    internal class ImagenNombre {
        public Image Imagen {
            get; set;
        }
        public string FileName {
            get; set;
        }
        public ImagenNombre( Image img, string FileName ) {
            this.Imagen = img;
            this.FileName = FileName;
        }
    }
    public class ImagenSeleccionadaArgs:EventArgs {
        public Image Imagen {
            get; set;
        }
        public string FileName {
            get; set;
        }
        public ImagenSeleccionadaArgs( Image img, string FileName ) {
            this.Imagen = img;
            this.FileName = FileName;
        }
    }
}
