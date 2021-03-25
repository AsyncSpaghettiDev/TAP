using System;
using System.Threading;
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
            _ = crearBotones();
            _ = jugar();
        }
        private async Task crearBotones( ) {
            for (int i = 0; i < 4; i++) {
                Boton nuevo;
                int v = new Random().Next(1, 10);
                await Task.Delay(110);
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
                        ( this.Controls[ i ] as Boton ).colision(this.Controls[ j ] as Boton);
                    }
                await Task.Delay(40);
            }
        }
    }
}
