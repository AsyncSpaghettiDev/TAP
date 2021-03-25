using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PracticaU1 {
    enum Estado {
        derecha,
        izquierda,
        arriba,
        abajo
    }
    // Clase base de elementosMovibles
    abstract class Boton : Button {
        public bool chocado = false;
        // Velocidades en x & y
        protected int velocidadx = 0;
        protected int velocidady = 0;
        protected Estado _pos;
        public Estado Pos {
            get => this._pos;
            set {
                switch (value) {
                    case Estado.abajo:
                        this.velocidady = -Math.Abs(this.velocidady);
                        break;
                    case Estado.arriba:
                        this.velocidady = Math.Abs(this.velocidady);
                        break;
                    case Estado.derecha:
                        this.velocidadx = -Math.Abs(this.velocidadx);
                        break;
                    case Estado.izquierda:
                        this.velocidadx = Math.Abs(this.velocidadx);
                        break;
                }
                this._pos = value;
            }
        }
        // Form en la que se dibujarán los elementos
        public Form Lienzo {
            get; private set;
        }
        // Constructor para inicializar la form y el control base
        public Boton( Form Lienzo, Point ubicacion ) {
            this.Lienzo = Lienzo;
            this.Location = ubicacion;
            while (this.velocidadx == 0)
                this.velocidadx = new Random().Next(-10, 10);
            this.velocidady = -this.velocidadx;
            this.AutoSize = true;
            mover();
        }
        // Metodo encargado de mover el control pasado por parametro
        // pd: se puede usar con los Padding (.Right | .Left | .Top | .Bottom) o con Location (.Location.X | .Location.Y)
        public async void mover( ) {
            while (true) {
                if (this.chocado) {
                    this.velocidadx = -this.velocidadx;
                    this.velocidady = -this.velocidady;
                    this.chocado = false;
                }
                // Rebote a la derecha
                if (this.Right >= this.Lienzo.Width - 15)
                    this.Pos = Estado.derecha;
                // Rebote Izquierda
                if (this.Left <= 0)
                    this.Pos = Estado.izquierda;
                // Rebote arriba
                if (this.Top <= 0)
                    this.Pos = Estado.arriba;
                // Rebote Abajo
                if (this.Bottom >= this.Lienzo.Height - 35)
                    this.Pos = Estado.abajo;
                // Actualizacion de movimiento
                this.Location = new Point(this.Location.X + this.velocidadx, this.Location.Y + this.velocidady);
                await Task.Delay(50);
                // Se coloca al frente el control añadido
                BringToFront();
                this.Text = this.Location.ToString();
            }
        }
        public virtual void colision( Boton choque ) {
            if (this.Location.X <= choque.Location.X + choque.Width && this.Location.X >= choque.Location.X - choque.Width &&
                this.Location.Y >= choque.Location.Y - choque.Height && this.Location.Y <= choque.Location.Y + choque.Height) {
                this.chocado = true;
                choque.chocado = true;
            }
        }
    }
    class Par : Boton {
        public Par( Form Tablero, Point ubicacion ) : base(Tablero, ubicacion) {
            this.Text = "Par";
        }
    }
    class Impar : Boton {
        public Impar( Form Tablero, Point ubicacion ) : base(Tablero, ubicacion) {
            this.Text = "Impar";
        }
    }
}
