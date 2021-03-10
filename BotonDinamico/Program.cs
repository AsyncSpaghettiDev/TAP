using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BotonDinamico {
    class Program {
        static void Main(string[] args) {
            Application.Run(new Lienzo());
        }
    }
    class Lienzo : Form {
        Button btn;
        public Lienzo() {
            this.Size = new Size(500, 500);
            this.BackColor = Color.Aquamarine;

            btn = new Button() {
                BackColor = Color.Brown,
                ForeColor = Color.White,
                Text = "Me muevo",
                AutoSize = true,
                Location = new Point(250, 250)
            };

            this.Controls.Add(this.btn);

            moverBoton();
        }
        private async void moverBoton() {
            while (5 > 1) {

                int a = new Random().Next(this.btn.Width / 2, maxValue: this.Width - 50 - ( this.btn.Width / 2 ));
                int b = new Random().Next(this.btn.Height / 2, maxValue: this.Height - 40 - ( this.btn.Height / 2 ));

                await Task.Delay(1000);
                this.btn.Location = new Point(a, b);
            }
        }
    }
}
