using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BotonEventos {
    class BotonMov : Button {
        // Variables locales para definir la velocidad
        private int velocidadx;
        private int velocidady;
        // Listas para controlar los eventos que pasarán
        readonly private List<Control> nombres = new List<Control>();
        readonly private List<Control> botones = new List<Control>(5);
        readonly private List<Control> caritas = new List<Control>(3);
        // Form donde se desplegarán los "eventos"
        public Form Lienzo {
            get; set;
        }
        // Constructor
        public BotonMov( Form Lienzo, int vx = 4, int vy = 4 ) {
            // Inicializar atributos locales
            this.Lienzo = Lienzo;
            this.velocidadx = vx;
            this.velocidady = vy;
            // Inicializacion de los atributos del boton
            this.BackColor = Color.Brown;
            this.ForeColor = Color.White;
            this.Text = "Me\nmuevo";
            this.Font = new Font(familyName: "Comic Sans MS", 12);
            this.AutoSize = true;
            this.Location = new Point(25, 250);
            this.Height = this.Width;
        }
        // Metodo encargado de mover el boton y ejecutar los eventos
        public async void mover( ) {
            while (true) {
                // Rebote derecha
                if (this.Location.X > this.Lienzo.Width - 10 - this.Width) {
                    this.velocidadx = -4;
                    // Se ejecuta el metodo de pintar los botones
                    await pintarBotones();
                }
                // Rebote izq
                else if (this.Location.X < 5) {
                    this.velocidadx = 4;
                    // Se limpian las listas y se desocupa la memoria
                    await quitarCosas(this.caritas, Color.Gray);
                    await quitarCosas(this.nombres, Color.Gray);
                    await quitarCosas(this.botones, Color.Gray);
                }
                // Rebote parte superior
                else if (this.Location.Y < 10) {
                    this.velocidady = 4;
                    // Se llama el metodo para desplegar las caritas felices
                    await pintarCaritas();
                }
                // Rebote parte inferior
                else if (this.Location.Y > this.Lienzo.Height - 35 - this.Height) {
                    this.velocidady = -4;
                    // Se llama al metodo para desplegar las etiquetas con mi nombre
                    await pintarNombres();
                }
                // Toca equina superior derecha
                if (this.Location.Y < 10 && this.Location.X > this.Lienzo.Width - 30 - this.Width) {
                    // Se llama al metodo para quitar las caritas y dejar el fondo amarillo
                    await quitarCosas(this.caritas, Color.Yellow);
                }
                // Toca esquina inferior derecha
                if (this.Location.Y > this.Lienzo.Height - 90 - this.Height && this.Location.X > this.Lienzo.Width - 20 - this.Width) {
                    // Se llama al metodo para quitar las etiquetas y dejar el fondo azul
                    await quitarCosas(this.nombres, Color.Blue);
                }
                // Movimiento
                this.Left += this.velocidadx;
                this.Top += this.velocidady;

                await Task.Delay(20);
            }
        }
        // Tarea encargada de quitar un lista local de la lista de la forma y se limpia la lista local, y se estable el color de fondo
        private async Task quitarCosas( List<Control> lista, Color fondo ) {
            for (int i = 0; i < lista.Count; i++)
                this.Lienzo.Controls.Remove(lista[ i ]);
            lista.Clear();
            this.Lienzo.BackColor = fondo;
            // Para evitar que se cuelgue el programa se agrega una pausa de 1ms
            await Task.Delay(1);
        }
        // Tarea encargada de agregar las 3 caritas felices
        private async Task pintarCaritas( ) {
            // Se limpia la lista con las caritas, en caso de existir
            await quitarCosas(this.caritas, Color.Yellow);
            // Se agregan 3 caritas a la lista local y a la lista de controles de la form
            for (int i = 0; i < 3; i++) {
                this.caritas.Add(new Carita(this.Lienzo, i).ElemMovible);
                this.Lienzo.Controls.Add(this.caritas[ i ]);
            }
            // Para evitar que se cuelgue el programa se agrega una pausa de 1ms
            await Task.Delay(1);
        }
        // Tarea encargada de agregar las etiquetas necesarias 
        private async Task pintarNombres( ) {
            // Se limpia la lista con los labels, en caso de existir
            if (this.nombres.Count > 0)
                await quitarCosas(this.nombres, Color.Blue);
            // 150 H & 20 W, tamaño de la Label
            // Se calcula la cantidad maxima de etiquetas que cabrán en la forma a lo alto y lo ancho
            int maxW = this.Lienzo.Width / 150, maxH = ( this.Lienzo.Height - 40 ) / 20;
            // Se recorre la cantidad de veces que se podrán agregar etiquetas a lo alto
            for (int i = 0; i < maxH; i++)
                // Se recorre la cantidad de veces que se podrán agregar etiquetas a lo ancho
                for (int j = 0; j < maxW; j++) {
                    // Se añade la etiqueta a la lista local y la lista de controles de la forma
                    this.nombres.Add(new Label() {
                        Text = "Mojica Vidal Jonathan Jafet",
                        AutoSize = true,
                        Location = new Point(j * 150, i * 20)
                    });
                    this.Lienzo.Controls.Add(this.nombres[ this.nombres.Count - 1 ]);
                }
            // Para evitar que se cuelgue el programa se agrega una pausa de 1ms
            await Task.Delay(1);
        }
        // Tarea encargada de desplegar los botones adicionales
        private async Task pintarBotones( ) {
            // Se limpia la lista con los botones, en caso de existir
            await quitarCosas(this.botones, Color.Orange);
            // Se añaden 5 botones a la lista local y la lista de controles
            for (int i = 0; i < 5; i++) {
                this.botones.Add(new BotonSenc(this.Lienzo, i).ElemMovible);
                this.Lienzo.Controls.Add(this.botones[ i ]);
            }
            // Para evitar que se cuelgue el programa se agrega una pausa de 1ms
            await Task.Delay(1);
        }
    }
    // Clase base de elementosMovibles
    class ElemMov {
        // Velocidades en x & y
        protected int velocidadx;
        protected int velocidady;
        // Vectores con velocidades y posiciones "aleatorias"
        protected readonly int[,] vel = new int[,] { { -5, 6 }, { -6, -4 }, { 4, -5 } };
        protected readonly int[,] pos = new int[,] { { 25, 30 }, { 100, 31 }, { 52, 120 } };
        // Form en la que se dibujarán los elementos
        public Form Lienzo {
            get; private set;
        }
        // Elemento privada de control que se manipulará
        public Control ElemMovible {
            get; protected set;
        }
        // Constructor para inicializar la form y el control base
        public ElemMov( Form Lienzo ) {
            this.ElemMovible = new Control();
            this.Lienzo = Lienzo;
        }
        // Metodo encargado de mover el control pasado por parametro
        // pd: se puede usar con los Padding (.Right | .Left | .Top | .Bottom) o con Location (.Location.X | .Location.Y)
        public async void mover( Control mov ) {
            while (true) {
                // Rebote a la derecha
                if (mov.Right > this.Lienzo.Width - 15)
                    this.velocidadx = -4;
                // Rebote Izquierda
                else if (mov.Left < 0)
                    this.velocidadx = 4;
                // Rebote arriba
                else if (mov.Top < 0)
                    this.velocidady = 4;
                // Rebote Abajo
                else if (mov.Bottom > this.Lienzo.Height - 35)
                    this.velocidady = -4;
                // Actualizacion de movimiento
                mov.Left += this.velocidadx;
                mov.Top += this.velocidady;
                await Task.Delay(30);
                // Se coloca al frente el control añadido
                mov.BringToFront();
            }
        }
    }
    // Clase carita
    class Carita : ElemMov {
        // Control que se usará: PictureBox
        public new PictureBox ElemMovible {
            get; private set;
        }
        // Constructor para inicializar el control local y se designa la velocidad "aleatoria"
        public Carita( Form Lienzo, int indice ) : base(Lienzo) {
            this.ElemMovible = new PictureBox() {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(50, 50)
            };
            this.ElemMovible.Load("https://images.emojiterra.com/google/android-11/512px/1f60a.png");
            this.ElemMovible.Location = new Point(this.pos[ indice, 0 ], this.pos[ indice, 1 ]);
            this.velocidadx = this.vel[ indice, 0 ];
            this.velocidady = this.vel[ indice, 1 ];
            // Se ejecuta el metodo para que se mueva el control
            mover(this.ElemMovible);
        }
    }
    // Boton que solo se mueve, no tiene ningun evento
    class BotonSenc : ElemMov {
        // Vectores con velocidad, posicion y color "aleatorios"
        private new readonly int[,] vel = new int[,] { { -5, 6 }, { -6, -4 }, { 4, -5 }, { 2, 6 }, { -7, 6 } };
        private new readonly int[,] pos = new int[,] { { 25, 30 }, { 100, 31 }, { 52, 120 }, { 125, 100 }, { 200, 350 } };
        private readonly int[,] colores = new int[,] { { 128, 0, 0 }, { 128, 128, 128 }, { 0, 0, 128 }, { 128, 0, 128 }, { 128, 128, 0 } };
        // Constructor donde se inicializa el control a usar
        public BotonSenc( Form Lienzo, int indice ) : base(Lienzo) {
            this.ElemMovible = new Button();
            this.ElemMovible.Location = new Point(this.pos[ indice, 0 ], this.pos[ indice, 1 ]);
            // Se define la velocidad y el color de manera "aleatoria"
            this.velocidadx = this.vel[ indice, 0 ];
            this.velocidady = this.vel[ indice, 1 ];
            this.ElemMovible.BackColor = Color.FromArgb(this.colores[ indice, 0 ], this.colores[ indice, 1 ], this.colores[ indice, 2 ]);
            // Se ejecuta el metodo para que se mueva el control.
            mover(this.ElemMovible);
        }
    }
}
