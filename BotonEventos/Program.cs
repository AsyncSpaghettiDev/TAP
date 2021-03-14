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
            btn = new BotonMov(this) {
                BackColor = Color.Brown,
                ForeColor = Color.White,
                Text = "Me\nmuevo",
                Font = new Font(familyName: "Comic Sans MS", 12),
                AutoSize = true,
                Location = new Point(new Random().Next(this.Width), new Random().Next(this.Height))
            };
            this.btn.Height = this.btn.Width;
            Controls.Add(this.btn);
            this.btn.mover();
        }
    }
}
