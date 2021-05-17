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
    /// <summary>
    /// Establece el operador Aritmetico
    /// </summary>
    enum Operador {
        /// <summary>
        /// Operador de suma
        /// </summary>
        Suma,
        /// <summary>
        /// Operador de resta
        /// </summary>
        Resta,
        /// <summary>
        /// Operador de multipliacion
        /// </summary>
        Multiplicacion,
        /// <summary>
        /// Operador de division
        /// </summary>
        Division
    }
    public partial class Form1 : Form {
        /// <summary>
        /// Establece el operador aritmetico actual
        /// </summary>
        Operador operadorActivo;
        /// <summary>
        /// Objeto encargado de realizar los calculos basicos (suma,resta,division, multipliacion)
        /// </summary>
        readonly OperacionesBasicas calculos;
        public Form1( ) {
            InitializeComponent();
            calculos = new OperacionesBasicas(0.00, 0.00);
        }
        /// <summary>
        /// Se añade el valor del boton al textBox
        /// </summary>
        private void numClick( object sender, EventArgs e ) {
            this.textBox1.Text += ( sender as Control ).Tag;
        }
        /// <summary>
        /// Se cierra la aplicacion al presionar el boton de cerrar
        /// </summary>
        private void pictureBox21_Click( object sender, EventArgs e ) => Application.Exit();
        /// <summary>
        /// Se limpia el textoBox1 al presionar el boton de backspace
        /// </summary>
        private void pictureBox18_Click( object sender, EventArgs e ) => this.textBox1.Clear();
        /// <summary>
        /// Se reinician todos los datos al presionar el boton de Reinicio
        /// </summary>
        private void pictureBox20_Click( object sender, EventArgs e ) {
            this.calculos.N1 = 0.00;
            this.calculos.N2 = 0.00;
            this.textBox1.Clear();
            this.textBox2.Clear();
        }
        /// <summary>
        /// Se cambia a un numero cuadrado cuando el mouse entra en el pictureBox
        /// </summary>
        private void numeroCuadrado( object sender, EventArgs e ) =>
            ( sender as PictureBox ).Image =
            new ComponentResourceManager(typeof(Properties.Resources)).GetObject("_" + ( sender as Control ).Tag + "h") as Image;
        /// <summary>
        /// Se cambia a un numero circular cuando el mouse sale del pictureBox
        /// </summary>
        private void numeroCircular( object sender, EventArgs e ) =>
            ( sender as PictureBox ).Image =
            new ComponentResourceManager(typeof(Properties.Resources)).GetObject("_" + ( sender as Control ).Tag) as Image;
        /// <summary>
        /// Al entrar el mouse al pictureBox se le asigna el color de fondo
        /// </summary>
        private void cambiarColor( object sender, EventArgs e ) => ( sender as Control ).BackColor = Color.FromArgb(47, 49, 49);
        /// <summary>
        /// Al entrar el mouse al pictureBox se le asigna el color transparente de fondo
        /// </summary>
        private void regresarColor( object sender, EventArgs e ) => ( sender as Control ).BackColor = Color.Transparent;
        /// <summary>
        /// Evento encargado de realizar las operaciones con los datos obtenidos
        /// </summary>
        private void operar( object sender, EventArgs e = null ) {
            // Se comprueba que el texto tenga un formato correcto
            if (!string.IsNullOrEmpty(this.textBox1.Text)) {
                // Se evalua el 'nombre' del boton presionado
                switch (( sender as Control ).Tag) {
                    // Operacion de suma
                    case "Suma":
                        // En caso que cambie el operador se calcula el valor de la operacion en curso
                        if (this.operadorActivo != Operador.Suma)
                            resultado();
                        // Se asigna el nuevo operador
                        this.operadorActivo = Operador.Suma;
                        // Se comprueba que el primer valor no sea 0, en caso de serlo se asigna el valor ingresado
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        // Sino se asigna a la variable 2 y se realiza el calculo
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;

                    case "Resta":
                        // En caso que cambie el operador se calcula el valor de la operacion en curso
                        if (this.operadorActivo != Operador.Resta)
                            resultado();
                        // Se asigna el nuevo operador
                        this.operadorActivo = Operador.Resta;
                        // Se comprueba que el primer valor no sea 0, en caso de serlo se asigna el valor ingresado
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        // Sino se asigna a la variable 2 y se realiza el calculo
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;

                    case "Multiplicacion":
                        // En caso que cambie el operador se calcula el valor de la operacion en curso
                        if (this.operadorActivo != Operador.Multiplicacion)
                            resultado();
                        this.operadorActivo = Operador.Multiplicacion;
                        // Se comprueba que el primer valor no sea 0, en caso de serlo se asigna el valor ingresado
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        // Sino se asigna a la variable 2 y se realiza el calculo
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;

                    case "Division":
                        // En caso que cambie el operador se calcula el valor de la operacion en curso
                        if (this.operadorActivo != Operador.Division)
                            resultado();
                        this.operadorActivo = Operador.Division;
                        // Se comprueba que el primer valor no sea 0, en caso de serlo se asigna el valor ingresado
                        if (this.calculos.N1 == 0.00)
                            this.calculos.N1 = double.Parse(this.textBox1.Text);
                        // Sino se asigna a la variable 2 y se realiza el calculo
                        else {
                            this.calculos.N2 = double.Parse(this.textBox1.Text);
                            realizarOperacion();
                        }
                        break;
                }
                // Se limpia la entrada y se actualiza el valor superior
                this.textBox1.Clear();
                this.textBox2.Text = this.calculos.N1.ToString();
            }
        }
        /// <summary>
        /// Evento para calcular el valor final de la operacion actual
        /// </summary>
        private void resultado( object sender = null, EventArgs e = null ) {
            // Se comprueba que el textBox tenga un valor correcto para poder hacer la operacion
            if (!string.IsNullOrEmpty(this.textBox1.Text)) {
                // Se asigna el valor a la variable 1 o 2
                if (this.calculos.N1 == 0.00)
                    this.calculos.N1 = double.Parse(this.textBox1.Text);
                else
                    this.calculos.N2 = double.Parse(this.textBox1.Text);
                // Se ejecuta la operacion
                realizarOperacion();
                // Se asigna el resultado al textBox en foco y se limpia el resultado de arriba
                this.textBox1.Text = this.calculos.Resultado.ToString();
                this.textBox2.Clear();
                // Se limpia el objeto que hace las operaciones
                this.calculos.N1 = 0.00;
                this.calculos.N2 = 0.00;
            }
        }
        /// <summary>
        /// Metodo encargado de realizar la operacion aritmetica correspondiente
        /// </summary>
        private void realizarOperacion( ) {
            // Se comprueba que el campo de texto tenga un formato correcto
            if (!string.IsNullOrEmpty(this.textBox1.Text))
                // Se evalua el operador activo
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
        /// <summary>
        /// Evento encargado encargado de manejar cuando una tecla es presionada
        /// </summary>
        private void textBox1_KeyPress( object sender, KeyPressEventArgs e ) {
            // Se crea un control temporal, solo se usará para asignar el tag
            Control temp = new Control();
            // Se evalua la tecla presionada
            switch (e.KeyChar) {
                // Tecla + presionada
                case '+':
                    // Se asigna el operador de suma y tambien se asigna el tag de suma al control temporal
                    this.operadorActivo = Operador.Suma;
                    temp.Tag = "Suma";
                    e.Handled = true;
                    // Se añade un + al textBox de arriba para que se sepa la operacion que se está haciendo
                    this.textBox2.Text += " +";
                    break;
                // Tecla - presionada
                case '-':
                    // Se asigna el operador de resta y tambien se asigna el tag de resta al control temporal
                    this.operadorActivo = Operador.Resta;
                    temp.Tag = "Resta";
                    e.Handled = true;
                    // Se añade un - al textBox de arriba para que se sepa la operacion que se está haciendo
                    this.textBox2.Text += " -";
                    break;
                // Tecla * presionada
                case '*':
                    // Se asigna el operador de multiplicacion y tambien se asigna el tag de multiplicacion al control temporal
                    this.operadorActivo = Operador.Multiplicacion;
                    temp.Tag = "Multiplicacion";
                    e.Handled = true;
                    // Se añade un * al textBox de arriba para que se sepa la operacion que se está haciendo
                    this.textBox2.Text += " x*";
                    break;
                // Tecla / presionada
                case '/':
                    // Se asigna el operador de division y tambien se asigna el tag de division al control temporal
                    this.operadorActivo = Operador.Division;
                    temp.Tag = "Division";
                    e.Handled = true;
                    // Se añade un / al textBox de arriba para que se sepa la operacion que se está haciendo
                    this.textBox2.Text += " /";
                    break;
                // Tecla enter presionada
                case ( char ) Keys.Enter:
                    resultado();
                    break;
            }
            // En caso que se haya presionado alguna tecla de operador se calculará la operacion
            if (e.KeyChar.Equals('+') || e.KeyChar.Equals('-') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/'))
                operar(temp);
        }
    }
}
