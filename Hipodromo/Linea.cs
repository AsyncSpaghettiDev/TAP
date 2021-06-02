using System.Drawing;
using System.Windows.Forms;

namespace Hipodromo {
    class Linea : PictureBox {
        public int WidthP {
            get;set;
        }
        public Linea( string num ) {
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            Bitmap foto = ( Bitmap ) Properties.Resources.ResourceManager.GetObject("Linea");
            Graphics ft = Graphics.FromImage(foto);
            ft.DrawString(num,new Font ("Times New Roman",20), Brushes.White, new Point(0, 15));
            this.Image = foto;
        }
    }
}
