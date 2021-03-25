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
            Par primero = new Par(this, new Point(50, 50)) {
                Name = "1",
            };
            this.pares.Add(primero);
            this.Controls.Add(primero);
            Par segundo = new Par(this, new Point(100, 100)) { 
                Name = "2",
            };
            this.pares.Add(segundo);
            this.Controls.Add(segundo);
            Impar Iprimero = new Impar(this, new Point(10, 10)) {
                Name = "3",
            };
            this.impares.Add(Iprimero);
            this.Controls.Add(Iprimero);
            Impar Isegundo = new Impar(this, new Point(200, 200)) {
                Name = "4",
            };
            this.impares.Add(Isegundo);
            this.Controls.Add(Isegundo);
            _ = jugar();
        }
        public async Task jugar( ) {
            while (true) {
                for (int i = 0; i < this.Controls.Count ; i++)
                    for (int j = 0; j < this.Controls.Count; j++) {
                        if (i == j)
                            continue;
                        ( this.Controls[ i ] as Boton ).colision(this.Controls[ j ] as Boton);
                    }
                await Task.Delay(100);
            }
        }
    }
}
