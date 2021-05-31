using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Memorama {
    class Jugador : Panel {
        DateTime tiempo;
        public Thread cronometro;
        readonly private Label lblNombre = new Label() {
            Location = new Point(10, 5),
            Font = new Font("Times New Roman", 14, FontStyle.Bold),
            AutoSize = true
        };
        readonly private Label lblCronometro = new Label() {
            Location = new Point(10, 350),
            Font = new Font("Times New Roman", 16, FontStyle.Bold),
        };
        readonly private Label lblMovimientos = new Label() {
            Location = new Point(10, 35),
            Font = new Font("Times New Roman", 16, FontStyle.Bold),
            AutoSize = true
        };
        public string NombreJugador {
            get => this.lblNombre.Text;
            set => this.lblNombre.Text = value;
        }
        private int noMovimientos;
        public int NoMovimientos {
            get => this.noMovimientos;
            set {
                this.noMovimientos = value;
                this.lblMovimientos.Text = $"Turnos: { value }";
            }
        }
        public int Puntos {
            get; private set;
        }
        public Jugador( int NumeroJugador ) {
            this.lblNombre.Text = string.Format($"Jugador #{ NumeroJugador + 1}");
            this.Size = new Size( 150, 500);
            this.Location = new Point((NumeroJugador * 150 )+ 520, 10);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCronometro);
            this.Controls.Add(this.lblMovimientos);
            this.cronometro = new Thread(new ThreadStart(contadorTiempo));
        }
        public void IniciarJuego( ) {
            Clear();
            CheckForIllegalCrossThreadCalls = false;
            iniciarCronometro();
        }
        public void AgregarPunto( Image carta ) {
            this.Puntos++;
            Point ubicacion;
            if (this.Puntos > 4)
                ubicacion = new Point(80, ( this.Puntos - 4 ) * 70);
            else
                ubicacion = new Point(10, this.Puntos * 70);

            this.Controls.Add(new PictureBox {
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = carta,
                Size = new Size(60, 60),
                Location = ubicacion
            });
        }
        public void Clear( ) {
            this.Puntos = 0;
            this.tiempo = new DateTime();
            this.lblCronometro.Text = "00:00";
            this.lblMovimientos.Text = string.Format("Turnos: 0");
        }
        void iniciarCronometro( ) {
            this.cronometro = new Thread(new ThreadStart(contadorTiempo));
            this.cronometro.Start();
        }
        void contadorTiempo( ) {
            while (true) {
                Thread.Sleep(1000);
                this.lblCronometro.Text = tiempo.ToString("mm:ss");
                this.tiempo = this.tiempo.AddSeconds(1);
            }
        }        
    }
}