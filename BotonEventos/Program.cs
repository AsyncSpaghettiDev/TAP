using System;
using System.Windows.Forms;
using System.Drawing;
namespace BotonEventos {
    class Program {
        static void Main() {
            Application.Run(new Lienzo() {
                Size = new Size(500, 500),
                BackColor = Color.Coral,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Mojica Vidal Jonathan Jafet - 19211688"
            });
        }
    }
    class Lienzo : Form {
        readonly BotonMov btn;
        public Lienzo() {
            this.btn = new BotonMov(this) {};
            this.Controls.Add(this.btn);
            this.btn.mover();
        }
    }
}
