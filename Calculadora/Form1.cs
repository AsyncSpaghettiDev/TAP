using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aritmetica;

namespace Calculadora {
    enum Operador {
        Suma,
        Resta,
        Multiplicacion,
        Division
    }
    public partial class Form1 : Form {
        Operador operadorActivo;
        readonly OperacionesBasicas calculos;
        public Form1( ) {
            InitializeComponent();
            calculos = new OperacionesBasicas(0.00, 0.00);
        }
        private void numClick( object sender, EventArgs e ) {
            this.textBox1.Text += ( sender as Control ).Tag;
        }
        private void pictureBox21_Click( object sender, EventArgs e ) => Application.Exit();
        private void pictureBox18_Click( object sender, EventArgs e ) => this.textBox1.Clear();
        private void pictureBox20_Click( object sender, EventArgs e ) {
            this.calculos.N1 = 0.00;
            this.calculos.N2 = 0.00;
            this.textBox1.Clear();
            this.textBox2.Clear();
        }
        private void numeroCuadrado( object sender, EventArgs e ) =>
            ( sender as PictureBox ).Image =
            new ComponentResourceManager(typeof(Properties.Resources)).GetObject("_" + ( sender as Control ).Tag + "h") as Image;
        private void numeroCircular( object sender, EventArgs e ) =>
            ( sender as PictureBox ).Image =
            new ComponentResourceManager(typeof(Properties.Resources)).GetObject("_" + ( sender as Control ).Tag) as Image;

        private void cambiarColor( object sender, EventArgs e ) => ( sender as Control ).BackColor = Color.FromArgb(47, 49, 49);
        private void regresarColor( object sender, EventArgs e ) => ( sender as Control ).BackColor = Color.Transparent;
        private void operar( object sender, EventArgs e = null ) {
            if (!string.IsNullOrEmpty(this.textBox1.Text)) {
                switch (( sender as Control ).Tag) {
                    case "Suma":
                        if (this.operadorActivo != Operador.Suma)
                            resultado();
                        this.operadorActivo = Operador.Suma;
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;

                    case "Resta":
                        if (this.operadorActivo != Operador.Resta)
                            resultado();
                        this.operadorActivo = Operador.Resta;
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;

                    case "Multiplicacion":
                        if (this.operadorActivo != Operador.Multiplicacion)
                            resultado();
                        this.operadorActivo = Operador.Multiplicacion;
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;

                    case "Division":
                        if (this.operadorActivo != Operador.Division)
                            resultado();
                        this.operadorActivo = Operador.Division;
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;
                }
                this.textBox1.Clear();
                this.textBox2.Text = this.calculos.N1.ToString();
            }
        }
        private void resultado( object sender = null, EventArgs e = null ) {
            if (!string.IsNullOrEmpty(this.textBox1.Text)) {
                if (this.calculos.N1 == 0.00)
                    this.calculos.N1 = double.Parse(this.textBox1.Text);
                else
                    this.calculos.N2 = double.Parse(this.textBox1.Text);

                realizarOperacion();
                this.textBox1.Text = this.calculos.Resultado.ToString();
                this.textBox2.Clear();
                this.calculos.N1 = 0.00;
                this.calculos.N2 = 0.00;
            }

        }
        private void realizarOperacion( ) {
            if (!string.IsNullOrEmpty(this.textBox1.Text))
                switch (this.operadorActivo) {
                    case Operador.Suma:
                        this.calculos.Suma();
                        break;

                    case Operador.Resta:
                        this.calculos.Resta();
                        break;

                    case Operador.Multiplicacion:
                        this.calculos.Multiplicacion();
                        break;

                    case Operador.Division:
                        this.calculos.Division();
                        break;
                }
        }

        private void textBox1_KeyPress( object sender, KeyPressEventArgs e ) {
            Control temp = new Control();
            switch (e.KeyChar) {
                case '+':
                    this.operadorActivo = Operador.Suma;
                    temp.Tag = "Suma";
                    e.Handled = true;
                    this.textBox2.Text += " +";
                    break;

                case '-':
                    this.operadorActivo = Operador.Resta;
                    temp.Tag = "Resta";
                    e.Handled = true;
                    this.textBox2.Text += " -";
                    break;

                case '*':
                    this.operadorActivo = Operador.Multiplicacion;
                    temp.Tag = "Multiplicacion";
                    e.Handled = true;
                    this.textBox2.Text += " *";
                    break;

                case '/':
                    this.operadorActivo = Operador.Division;
                    temp.Tag = "Division";
                    e.Handled = true;
                    this.textBox2.Text += " /";
                    break;

                case ( char ) Keys.Enter:
                    resultado();
                    break;
            }
            if (e.KeyChar.Equals('+') || e.KeyChar.Equals('-') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/'))
                operar(temp);
        }
    }
}
