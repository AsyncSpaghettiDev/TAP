using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BotonEventos {
    class BotonMov : Button {
        private int velocidadx;
        private int velocidady;
        readonly private List<Control> caritas = new List<Control>(3);
        readonly private List<Control> nombres = new List<Control>();
        public Form Lienzo {
            get; set;
        }
        public BotonMov(Form Lienzo, int vx = 4, int vy = 4) {
            this.Lienzo = Lienzo;
            this.velocidadx = vx;
            this.velocidady = vy;
        }
        public async void mover() {
            while (true) {
                if (this.Right > this.Lienzo.Width - 15)
                    this.velocidadx = -4;
                // Rebote izq
                else if (this.Left < 0) {
                    this.velocidadx = 4;
                }
                // Rebote parte superior
                else if (this.Top < 0) {
                    this.velocidady = 4;
                    pintarCaritas();
                }
                // Rebote parte inferior
                else if (this.Bottom > Lienzo.Height - 35) {
                    this.velocidady = -4;
                    //pintarNombres();
                }
                // Toca equina superior derecha
                else if (this.Top < 10 && this.Right > Lienzo.Width - 30 - this.Width) {
                    quitarCosas(caritas, Color.Yellow);
                }
                // Toca esquina inferior derecha
                else if (this.Bottom > Lienzo.Height - 55 && this.Right > Lienzo.Width - 30 - this.Width) {
                    quitarCosas(this.nombres, Color.Blue);
                }
                // Movimiento
                this.Left += this.velocidadx;
                this.Top += this.velocidady;
                await Task.Delay(20);
            }
        }
        private void quitarCosas(List<Control> lista, Color fondo) {
            for (int i = 0; i < lista.Count; i++)
                this.Lienzo.Controls.Remove(lista[ i ]);
            lista.Clear();
            Lienzo.BackColor = fondo;
        }
        private void pintarCaritas() {
            quitarCosas(this.caritas, Color.Yellow);
            for (int i = 0; i < 3; i++) {
                caritas.Add(new Carita(Lienzo, i).ElemMovible);
                this.Lienzo.Controls.Add(caritas[ i ]);
            }
        }
        /*private void pintarNombres() {
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
        }*/
    }
    class ElemMov {
        protected int velocidadx;
        protected int velocidady;

        protected readonly int[,] vel = new int[,] { { -5, 6 }, { -6, -4 }, { 4, -5 } };
        protected readonly int[,] pos = new int[,] { { 25, 30 }, { 100, 31 }, { 52, 120 } };
        public Form Lienzo {
            get; private set;
        }
        protected Control ElemMovible {
            get; private set;
        }
        public ElemMov(Form Lienzo, int indice) {
            this.ElemMovible = new Control();
            this.Lienzo = Lienzo;
            this.velocidadx = vel[ indice, 0 ];
            this.velocidady = vel[ indice, 1 ];
        }
        public async void mover(Control mov) {
            while (true) {
                if (mov.Right > Lienzo.Width - 15)
                    this.velocidadx = -4;
                else if (mov.Left < 0)
                    this.velocidadx = 4;
                else if (mov.Top < 0)
                    this.velocidady = 4;
                else if (mov.Bottom > Lienzo.Height - 35)
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
        public Carita(Form Lienzo, int indice): base(Lienzo, indice) {
            this.ElemMovible = new PictureBox() {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(50,50)
            };
            this.ElemMovible.Load("https://images.emojiterra.com/google/android-11/512px/1f60a.png");
            this.ElemMovible.Location = new Point(this.pos[ indice, 0 ], this.pos[ indice, 1 ]);
            mover(this.ElemMovible);
        }
    }
    class BotonSenc : ElemMov {
        protected new Button ElemMovible {
            get; private set;
        }
        public BotonSenc(Form Lienzo, int indice) : base(Lienzo, indice) {
            this.ElemMovible = new Button();
            this.ElemMovible.Location = new Point(this.pos[ indice, 0 ], this.pos[ indice, 1 ]);
        }
    }
}
