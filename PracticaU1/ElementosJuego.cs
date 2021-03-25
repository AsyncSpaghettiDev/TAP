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
        protected int _valor;
        public virtual int Valor {
            get => this._valor;
            set {
                this._valor = value;
            }
        }
        public bool chocado = false;
        // Velocidades en x & y
        public int Velocidadx {
            get; protected set;
        }
        public int Velocidady {
            get; protected set;
        }
        protected Estado _pos;
        public Estado Pos {
            get => this._pos;
            set {
                switch (value) {
                    case Estado.abajo:
                        this.Velocidady = -Math.Abs(this.Velocidady);
                        break;
                    case Estado.derecha:
                        this.Velocidadx = -Math.Abs(this.Velocidadx);
                        break;
                    case Estado.arriba:
                        this.Velocidady = Math.Abs(this.Velocidady);
                        break;
                    case Estado.izquierda:
                        this.Velocidadx = Math.Abs(this.Velocidadx);
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
        public Boton( Form Lienzo, Point ubicacion, int valor ) {
            this.Valor = valor;
            this.Lienzo = Lienzo;
            this.Location = ubicacion;
            this.Velocidadx = 5;
            this.Velocidady = -5;
            this.Size = new Size(30,30);
            mover();
        }
        public Boton( Form Lienzo, Point ubicacion, int valor, int vlx ) {
            this.Valor = valor;
            this.Lienzo = Lienzo;
            this.Location = ubicacion;
            this.Velocidadx = -vlx;
            this.Velocidady = vlx;
            this.Size = new Size(30, 30);
            mover();
        }
        // Metodo encargado de mover el control pasado por parametro
        // pd: se puede usar con los Padding (.Right | .Left | .Top | .Bottom) o con Location (.Location.X | .Location.Y)
        public async void mover( ) {
            while (true) {
                if (this.chocado) {
                    this.Velocidadx = -this.Velocidadx;
                    this.Velocidady = -this.Velocidady;
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
                this.Location = new Point(this.Location.X + this.Velocidadx, this.Location.Y + this.Velocidady);
                await Task.Delay(70);
                // Se coloca al frente el control añadido
                BringToFront();
            }
        }
        public virtual int colision( Boton choque ) {
            if (this.Location.X <= choque.Location.X + choque.Width && this.Location.X >= choque.Location.X - choque.Width &&
                this.Location.Y >= choque.Location.Y - choque.Height && this.Location.Y <= choque.Location.Y + choque.Height) {
                this.chocado = true;
                choque.chocado = true;
                this.Location = new Point(this.Location.X - 10, this.Location.Y - 10);
                choque.Location = new Point(choque.Location.X + 10, choque.Location.Y + 10);
                if (this is Impar && choque is Impar)
                    return 1;
                if (( this is Impar && choque is Par ) || ( this is Par && choque is Impar ))
                    return 2;
            }
            return 0;
        }
    }
    class Par : Boton {
        public override int Valor {
            set {
                this.Text = value.ToString();
                this._valor = value;
            }
        }
        public Par( Form Tablero, Point ubicacion, int valor, int vel ) : base(Tablero, ubicacion, valor, vel) { }
        public Par( Form Tablero, Point ubicacion, int valor ) : base(Tablero, ubicacion, valor) { }
    }
    class Impar : Boton {
        public override int Valor {
            set {
                this.Text = value.ToString();
                this._valor = value;
            }
        }
        public Impar( Form Tablero, Point ubicacion, int valor ) : base(Tablero, ubicacion, valor) { }
    }
}
