using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PracticaU1 {
    class Program {
        static void Main( ) {
            Application.Run(new Juego());
        }
    }
    class Juego : Form {
        readonly List<Boton> pares = new List<Boton>();
        readonly List<Boton> impares = new List<Boton>();
        public Juego( ) {
            this.Size = new Size(500, 500);
            crearBotones(4);
            _ = jugar();
        }
        private void crearBotones( int botones) {
            for (int i = 0; i < botones; i++) {
                Boton nuevo;
                int v = new Random().Next(1, 10);
                if (v % 2 == 1) {
                    nuevo = new Impar(this, new Point(80 * i + 50, 80 * i + 50), v);
                    this.impares.Add(nuevo);
                }
                else {
                    nuevo = new Par(this, new Point(90 * i + 70, 90 * i + 70), v);
                    this.pares.Add(nuevo);
                }
                this.Controls.Add(nuevo);
            }
        }
        private async Task jugar( ) {
            while (true) {
                for (int i = 0; i < this.Controls.Count; i++)
                    for (int j = 0; j < this.Controls.Count; j++) {
                        if (i == j)
                            continue;
                        decisiones(( this.Controls[ i ] as Boton ).colision(this.Controls[ j ] as Boton),
                            this.Controls[ i ] as Boton,
                            this.Controls[ j ] as Boton
                            );
                        break;
                    }
                await Task.Delay(50);
                this.Text = "Botones: " + this.Controls.Count;
            }
        }
        private void decisiones( int decision, Boton a, Boton b ) {
            switch (decision) {
                case 1:
                    // 2 impares chocan
                    int indice = a.Valor + b.Valor;
                    Console.WriteLine(a.Valor + " + " + b.Valor + " = " + indice);
                    this.Controls.Add(new Par(this, a.Location, indice, a.Velocidadx));
                    this.Controls.Add(new Par(this, b.Location, indice, b.Velocidadx));
                    this.Controls.Remove(a);
                    this.Controls.Remove(b);
                    crearBotones(indice);
                    break;

                case 2:
                    // Par e impar chocan
                    break;
            }
        }
    }
}
