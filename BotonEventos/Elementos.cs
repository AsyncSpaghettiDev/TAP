using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BotonEventos {
    class BotonMov : Button {
        private int velocidadx;
        private int velocidady;
        readonly private List<Control> nombres = new List<Control>();
        readonly private List<Control> botones = new List<Control>(5);
        readonly private List<Control> caritas = new List<Control>(3);
        public Form Lienzo {
            get; set;
        }
        public BotonMov( Form Lienzo, int vx = 4, int vy = 4 ) {
            this.Lienzo = Lienzo;
            this.velocidadx = vx;
            this.velocidady = vy;
            this.BackColor = Color.Brown;
            this.ForeColor = Color.White;
            this.Text = "Me\nmuevo";
            this.Font = new Font(familyName: "Comic Sans MS",12);
            this.AutoSize = true;
            this.Location = new Point(25, 250);
            this.Height = this.Width;
        }
        public async void mover( ) {
            while (true) {
                // Rebote derecha
                if (this.Location.X > this.Lienzo.Width - 10 - this.Width) {
                    this.velocidadx = -4;
                    pintarBotones();
                }
                // Rebote izq
                else if (this.Location.X < 5) {
                    this.velocidadx = 4;
                    this.Lienzo.Controls.Clear();
                }
                // Rebote parte superior
                else if (this.Location.Y < 10) {
                    this.velocidady = 4;
                    pintarCaritas();
                }
                // Rebote parte inferior
                else if (this.Location.Y > this.Lienzo.Height - 35 - this.Height) {
                    this.velocidady = -4;
                    pintarNombres();
                }
                // Toca equina superior derecha
                if (this.Location.Y < 10 && this.Location.X > this.Lienzo.Width - 30 - this.Width) {
                    quitarCosas(this.caritas, Color.Yellow);
                }
                // Toca esquina inferior derecha
                if (this.Location.Y > this.Lienzo.Height - 90 - this.Height && this.Location.X > this.Lienzo.Width - 20 - this.Width) {
                    quitarCosas(this.nombres, Color.Blue);
                }
                // Movimiento
                this.Left += this.velocidadx;
                this.Top += this.velocidady;
                this.Lienzo.Text = this.Location.ToString() + this.Lienzo.Size;

                await Task.Delay(20);
            }
        }
        private void quitarCosas( List<Control> lista, Color fondo ) {
            for (int i = 0; i < lista.Count; i++)
                this.Lienzo.Controls.Remove(lista[ i ]);
            lista.Clear();
            this.Lienzo.BackColor = fondo;
        }
        private void pintarCaritas( ) {
            quitarCosas(this.caritas, Color.Yellow);
            for (int i = 0; i < 3; i++) {
                this.caritas.Add(new Carita(this.Lienzo, i).ElemMovible);
                this.Lienzo.Controls.Add(this.caritas[ i ]);
            }
        }
        private void pintarNombres( ) {
            quitarCosas(this.nombres, Color.Blue);
            // 150 H & 20 W
            int maxW = this.Lienzo.Width / 150, maxH = ( this.Lienzo.Height - 40 ) / 20;
            for (int i = 0; i < maxH; i++)
                for (int j = 0; j < maxW; j++) {
                    this.nombres.Add(new Label() {
                        Text = "Mojica Vidal Jonathan Jafet",
                        AutoSize = true,
                        Location = new Point(j * 150, i * 20)
                    });
                    this.Lienzo.Controls.Add(this.nombres[ this.nombres.Count - 1 ]);
                }
        }
        private void pintarBotones( ) {
            quitarCosas(this.botones, Color.Orange);
            for (int i = 0; i < 5; i++) {
                this.botones.Add(new BotonSenc(this.Lienzo, i).ElemMovible);
                this.Lienzo.Controls.Add(this.botones[ i ]);
            }
        }
    }
    class ElemMov {
        protected int velocidadx;
        protected int velocidady;
        protected readonly int[,] vel = new int[,] { { -5, 6 }, { -6, -4 }, { 4, -5 } };
        protected readonly int[,] pos = new int[,] { { 25, 30 }, { 100, 31 }, { 52, 120 } };
        public Form Lienzo {
            get; private set;
        }
        public Control ElemMovible {
            get; protected set;
        }
        public ElemMov( Form Lienzo ) {
            this.ElemMovible = new Control();
            this.Lienzo = Lienzo;
        }
        public async void mover( Control mov ) {
            while (true) {
                if (mov.Right > this.Lienzo.Width - 15)
                    this.velocidadx = -4;
                else if (mov.Left < 0)
                    this.velocidadx = 4;
                else if (mov.Top < 0)
                    this.velocidady = 4;
                else if (mov.Bottom > this.Lienzo.Height - 35)
                    this.velocidady = -4;

                mov.Left += this.velocidadx;
                mov.Top += this.velocidady;
                await Task.Delay(30);
                mov.BringToFront();
            }
        }
    }
    class Carita : ElemMov {
        public new PictureBox ElemMovible {
            get; private set;
        }
        public Carita( Form Lienzo, int indice ) : base(Lienzo) {
            this.ElemMovible = new PictureBox() {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(50, 50)
            };
            this.ElemMovible.Load("https://images.emojiterra.com/google/android-11/512px/1f60a.png");
            this.ElemMovible.Location = new Point(this.pos[ indice, 0 ], this.pos[ indice, 1 ]);
            this.velocidadx = this.vel[ indice, 0 ];
            this.velocidady = this.vel[ indice, 1 ];
            mover(this.ElemMovible);
        }
    }
    class BotonSenc : ElemMov {
        private new readonly int[,] vel = new int[,] { { -5, 6 }, { -6, -4 }, { 4, -5 }, { 2, 6 }, { -7, 6 } };
        private new readonly int[,] pos = new int[,] { { 25, 30 }, { 100, 31 }, { 52, 120 }, { 125, 100 }, { 200, 350 } };
        private readonly int[,] colores = new int[,] { { 128, 0, 0 }, { 128, 128, 128 }, { 0, 0, 128 }, { 128, 0, 128 }, { 128, 128, 0 } };
        public BotonSenc( Form Lienzo, int indice ) : base(Lienzo) {
            this.ElemMovible = new Button();
            this.ElemMovible.Location = new Point(this.pos[ indice, 0 ], this.pos[ indice, 1 ]);
            this.velocidadx = this.vel[ indice, 0 ];
            this.velocidady = this.vel[ indice, 1 ];
            this.ElemMovible.BackColor = Color.FromArgb(this.colores[ indice, 0 ], this.colores[ indice, 1 ], this.colores[ indice, 2 ]);
            mover(this.ElemMovible);
        }
    }
}
