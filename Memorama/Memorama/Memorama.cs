using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Memorama {
    public partial class Memorama : Form {
        // Tamaño total del memorama, este será cuadrado siempre
        readonly int tamanioColumnasFilas = 4;
        // Cantidad de tarjetas descubiertas
        int cantidadCartasVolteadas = 0;
        // Cartas correctamente volteadas
        readonly List<string> cartasEnumeradas = new List<string>();
        // Cartas ocultas
        readonly List<string> cartasRevueltas = new List<string>();
        // Cartas volteadas
        readonly ArrayList cartasSeleccionadas = new ArrayList();
        // Jugadores
        readonly ArrayList jugadores = new ArrayList();
        // Jugador actual
        Jugador jugadorActual;
        // Indice jugador actual
        int indiceJugadorActual = 0;
        // Cartas volteadas antes de ser verificar
        PictureBox cartaTemporal1;
        PictureBox cartaTemporal2;
        // Valor de carta actual
        int cartaActual = 0;
        public Memorama( int jugadores ) {
            InitializeComponent();
            for (int i = 0; i < jugadores; i++) {
                var jugador = new Jugador(i);
                this.jugadores.Add(jugador);
                this.Controls.Add(jugador);
            }
            IniciarJuego();
        }
        // Se inicia el juego o se reinicia
        public void IniciarJuego( ) {
            cambiarJugador();
            // Contador de cartas descubiertas
            this.cantidadCartasVolteadas = 0;
            // Se limpia el "tablero" de juego
            this.PanelPerros.Controls.Clear();
            // Se cargan las cartas en pares
            for (int i = 0; i < 8; i++) {
                this.cartasEnumeradas.Add(i.ToString());
                this.cartasEnumeradas.Add(i.ToString());
            }
            // Se crea una variable que tendrá un valor aleatorio
            var NumeroAleatorio = new Random();
            // Se ordenan las cartas
            var Resultado = cartasEnumeradas.OrderBy(item => NumeroAleatorio.Next());
            foreach (string ValorCarta in Resultado) {
                this.cartasRevueltas.Add(ValorCarta);
            }
            // Se crea una cuadricula con las dimensiones
            var tablaPanel = new TableLayoutPanel {
                RowCount = tamanioColumnasFilas,
                ColumnCount = tamanioColumnasFilas
            };
            // Se define el tamaño de las columnas y filas
            for (int i = 0; i < tamanioColumnasFilas; i++) {
                var Porcentaje = 150f / tamanioColumnasFilas - 10;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }
            int contadorFichas = 0;
            // Se colocan en pictureBox las cartas
            for (var i = 0; i < tamanioColumnasFilas; i++) {
                for (var j = 0; j < tamanioColumnasFilas; j++) {
                    var CartasJuego = new PictureBox {
                        Name = contadorFichas.ToString(),
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Properties.Resources.Girada,
                        Cursor = Cursors.Hand
                    };
                    // Se asigna el evento del click, se añade al panel principal
                    CartasJuego.Click += carta_Click;
                    tablaPanel.Controls.Add(CartasJuego, j, i);
                    contadorFichas++;
                }
            }
            tablaPanel.Dock = DockStyle.Fill;
            PanelPerros.Controls.Add(tablaPanel);
        }
        // Se vuelve a cargar todos los elementos del juego
        private void btnReiniciar_Click( object sender, EventArgs e ) {
            finalizar();
            foreach (Jugador jg in this.jugadores)
                jg.Clear();
            this.jugadorActual = null;
            IniciarJuego();
        }
        private async void carta_Click( object sender, EventArgs e ) {
            if (this.cartasSeleccionadas.Count < 2) {
                this.jugadorActual.NoMovimientos++;
                ( sender as Control ).Enabled = false;
                this.cartaActual = int.Parse(cartasRevueltas[ int.Parse((sender as PictureBox ).Name) ]);
                (sender as PictureBox ).Image = recuperarImagen(cartaActual);
                this.cartasSeleccionadas.Add(sender as PictureBox );

                if (this.cartasSeleccionadas.Count == 2) {
                    this.cartaTemporal1 = ( PictureBox ) cartasSeleccionadas[ 0 ];
                    this.cartaTemporal2 = ( PictureBox ) cartasSeleccionadas[ 1 ];
                    int Carta1 = int.Parse(cartasRevueltas[ int.Parse(cartaTemporal1.Name) ]);
                    int Carta2 = int.Parse(cartasRevueltas[ int.Parse(cartaTemporal2.Name) ]);

                    if (Carta1 != Carta2) {
                        cambiarJugador();
                        await Task.Delay(1000);
                        this.cartaTemporal1.Enabled = true;
                        this.cartaTemporal2.Enabled = true;
                        this.cartaTemporal1.Image = Properties.Resources.Girada;
                        this.cartaTemporal2.Image = Properties.Resources.Girada;
                    }
                    if (Carta1 == Carta2) {
                        this.jugadorActual.AgregarPunto(this.cartaTemporal1.Image);
                        this.cantidadCartasVolteadas++;
                        this.cartaTemporal1.Dispose();
                        this.cartaTemporal2.Dispose();
                    }

                    if (cantidadCartasVolteadas > 7) {
                        finalizar();
                        MessageBox.Show("El juego termino");
                    }
                    cartasSeleccionadas.Clear();
                }
            }
        }
        private Bitmap recuperarImagen( int NumeroImagen ) => ( Bitmap ) Properties.Resources.ResourceManager.GetObject("Perros_" + NumeroImagen);
        private void memorama_FormClosing( object sender, FormClosingEventArgs e ) {
            finalizar();
            new Principal().Show();
            Dispose(false);
        }
        private void cambiarJugador( ) {
            if (this.jugadorActual == null) {
                this.jugadorActual = ( Jugador ) this.jugadores[ 0 ];
                this.jugadorActual.IniciarJuego();
            }
            else {
                this.jugadorActual.cronometro.Suspend();
                this.indiceJugadorActual++;
                if (this.indiceJugadorActual >= this.jugadores.Count)
                    this.indiceJugadorActual = 0;
                this.jugadorActual = ( Jugador ) this.jugadores[ this.indiceJugadorActual ];
                try {
                    this.jugadorActual.cronometro.Resume();
                }
                catch (Exception) {
                    this.jugadorActual.IniciarJuego();
                }
            }
        }
        private void finalizar( ) {
            foreach (Jugador jg in this.jugadores)
                try {
                    jg.cronometro.Abort();
                }
                catch (ThreadStateException) {
                    jg.cronometro.Resume();
                    jg.cronometro.Abort();
                }
        }
    }
}
