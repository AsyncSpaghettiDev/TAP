using System;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace Hipodromo {
    public partial class Form1 : Form {
        readonly Random rdm = new Random();
        readonly ArrayList hilos = new ArrayList();
        readonly ArrayList caballos = new ArrayList();
        readonly ArrayList lineas = new ArrayList();
        readonly ArrayList ganadores = new ArrayList();
        public Form1( int cantidadCaballos ) {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.pictureBox2.Enabled = false;
            cargarCaballos(cantidadCaballos);
        }
        void cargarCaballos( int cantidadCaballos ) {
            if (cantidadCaballos >= 6)
                this.Height += ( cantidadCaballos - 6 ) * 60;
            else 
                this.Height -= (6 - cantidadCaballos ) * 60;
            for (int i = 0; i < cantidadCaballos; i++) {
                this.hilos.Add(new Thread(new ThreadStart(correr)) {
                    Name = i.ToString()
                });

                Point ubicacion;
                if (i == 0)
                    ubicacion = new Point(0, this.Height - 100);
                else
                    ubicacion = new Point(0, ( lineas[ i - 1 ] as Control ).Location.Y - 60);
                Linea lineaTemp = new Linea(( i + 1 ).ToString()) {
                    Location = ubicacion
                };
                PictureBox caballo = new PictureBox() {
                    Location = new Point(0, lineaTemp.Location.Y + 7),
                    Size = new Size(53, 53),
                    Image = ( Image ) Properties.Resources.ResourceManager.GetObject("_0"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.FromArgb(180, 113, 38)
                };
                this.caballos.Add(caballo);
                this.Controls.Add(caballo);
                this.lineas.Add(lineaTemp);
                this.Controls.Add(lineaTemp);
            }
        }

        private void pictureBox1_MouseEnter( object sender, EventArgs e ) {
            Image img = this.pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipXY);
            this.pictureBox1.Image = img;
        }

        private void pictureBox1_MouseLeave( object sender, EventArgs e ) {
            Image img = this.pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate270FlipXY);
            this.pictureBox1.Image = img;
        }

        private void pictureBox1_Click( object sender, EventArgs e ) {
            jugar();
            ( sender as Control ).Hide();
        }
        void jugar( ) {
            foreach (Thread tr in this.hilos)
                tr.Start();
        }
        void correr( ) {
            int vel;
            double probabilidad = rdm.NextDouble();
            if (probabilidad <= 0.5)
                vel = 10;
            else if (probabilidad <= ( 0.5 + 0.25 ))
                vel = 12;
            else
                vel = 15;
            int noHilo = int.Parse(Thread.CurrentThread.Name);
            PictureBox temp = this.caballos[ noHilo ] as PictureBox;
            while (true) {
                temp.Image = ( Image ) Properties.Resources.ResourceManager.GetObject("_1");
                temp.Left += vel;
                Thread.Sleep(50);
                temp.Image = ( Image ) Properties.Resources.ResourceManager.GetObject("_2");
                temp.Left += vel;
                Thread.Sleep(50);
                if (( this.Width - temp.Right ) < 10) {
                    temp.Image = ( Image ) Properties.Resources.ResourceManager.GetObject("_0");
                    llegarMeta(noHilo + 1);
                    Thread.CurrentThread.Abort();
                    break;
                }
            }
        }
        void llegarMeta( int noCaballo ) {
            if (this.ganadores.Count == 0)
                this.label2.Text = "Caballo Ganador #" + noCaballo;
            this.ganadores.Add(noCaballo);

            if (this.ganadores.Count == this.hilos.Count) {
                MessageBox.Show("Se acabó");
                this.pictureBox2.BringToFront();
                this.pictureBox2.Enabled = true;
            }
        }
        void restart( ) {
            this.ganadores.Clear();
            this.label2.Text = "";
            for (int i = 0; i < this.hilos.Count; i++) {
                this.hilos[ i ] = new Thread(new ThreadStart(correr)) {
                    Name = i.ToString()
                };
                ( this.caballos[ i ] as PictureBox ).Location = new Point(0, ( this.lineas[ i ] as Control ).Location.Y + 7);
                ( this.caballos[ i ] as PictureBox ).Size = new Size(53, 53);
                ( this.caballos[ i ] as PictureBox ).Image = ( Image ) Properties.Resources.ResourceManager.GetObject("_0");
            }
        }

        private void pictureBox2_Click( object sender, EventArgs e ) {
            restart();
            this.pictureBox2.Enabled = false;
            this.pictureBox1.Show();
        }

        private void form1_FormClosing( object sender, FormClosingEventArgs e ) {
            foreach (Thread tr in this.hilos)
                tr.Abort();
            new Home().Show();
            Dispose(false);
        }
    }
}
