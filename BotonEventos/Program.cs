using System;
using System.Windows.Forms;
using System.Drawing;
namespace BotonEventos {
    class Program {
        static void Main() {
            // Se ejecuta la form, ajustando la posicion inicial al centro de la pantalla
            Application.Run(new Lienzo() {
                Size = new Size(500, 500),
                BackColor = Color.Gray,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Mojica Vidal Jonathan Jafet - 19211688"
            });
        }
    }
    class Lienzo : Form {
        readonly BotonMov btn;
        // Se crea un boton con movimientos en la forma
        public Lienzo() {
            this.btn = new BotonMov(this) {};
            this.Controls.Add(this.btn);
            // Se da la orden de moverse al boton.
            this.btn.mover();
        }
    }
}
