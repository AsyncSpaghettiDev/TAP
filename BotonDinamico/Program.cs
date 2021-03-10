using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BotonDinamico {
    class Program {
        static void Main() {
            Application.Run(new Lienzo() {
                Size = new Size(500,500),
                BackColor = Color.Coral,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Mojica Vidal Jonathan Jafet - 19211688"
            });
        }
    }
    class Lienzo : Form {
        readonly Button btn;
        int velx = 4, vely = 4;
        public Lienzo() {
            btn = new Button() {
                BackColor = Color.Brown,
                ForeColor = Color.White,
                Text = "Me\nmuevo",
                Font = new Font(familyName:"Comic Sans MS", 12),
                AutoSize = true,
                Location = new Point(0, 250)
            };
            this.btn.Height = this.btn.Width;

            this.Controls.Add(this.btn);
            moverBoton();
        }
        private async void moverBoton() {
            while (true) {
                if (this.btn.Right > this.Width - 15)
                    this.velx = -4;
                if (this.btn.Left < 0)
                    this.velx = 4;

                if (this.btn.Top < 0)
                    this.vely = 4;
                if (this.btn.Bottom > this.Height - 35)
                    this.vely = -4;

                this.btn.Left += this.velx;
                this.btn.Top += this.vely;
                await Task.Delay(20);
            }
        }
    }
}
