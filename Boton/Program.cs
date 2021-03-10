using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Form bt = new Form() {
                Size = new Size(500, 500),
                Text = "Solo soy una form con un boton :)"
            };
            bt.Controls.Add(new Button() {
                Text = "Soy un Boton",
                AutoSize = true,
                Location = new Point(200, 200)
            }
            );
            Application.Run(bt);
        }
    }
}
