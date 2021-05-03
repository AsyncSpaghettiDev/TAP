using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Universidad {
    // Enumeracion para definir en que pantalla estamos actualmente
    enum Estado {
        Principal,
        Profesores,
        Estudiantes,
        Personal
    }
    public partial class Form1 : Form {
        // Atributo para saber en que pantalla estamos actualmente
        private Estado _pantalla;
        private Estado Pantalla {
            // Se regresa el campo privado _pantalla
            get => this._pantalla;
            // Parte de la propiedad para establecer un valor
            set {
                // Se asigna el valor de la varibale
                this._pantalla = value;
                // En caso que estemos en la pantalla personal se moverá el panel con los botones de manipulacion
                if (value == Estado.Personal)
                    this.bunifuPanel3.Location = new Point(this.bunifuPanel3.Location.X, 410);
                // Si estamos en otra pantalla volveran a su posicion habitual
                else
                    this.bunifuPanel3.Location = new Point(this.bunifuPanel3.Location.X, 435);
                // Si estamos en la pantalla principal los botones desapareceran
                if (this.Pantalla == Estado.Principal)
                    this.bunifuPanel3.Visible = false;
                // En caso contrario se mostrarán
                else
                    this.bunifuPanel3.Visible = true;
            }
        }
        public Form1( ) {
            InitializeComponent();
        }
        // Accion de presionar el boton de salir
        private void pictureBox1_Click( object sender, EventArgs e ) {
            // Se cierra la ejecución del programa
            Application.Exit();
        }
        // Acccion de presionar el boton de profesores
        private void bunifuTileButton1_Click( object sender, EventArgs e ) {
            // Se evalua en que pantalla estamos
            switch (this.Pantalla) {
                // Si estamos en la Principal, esta se oculta
                case Estado.Principal:
                    this.bunifuTransition4.HideSync(this.userControl41);
                    break;
                // Si estamos en la de Profesores, esta se oculta
                case Estado.Profesores:
                    this.bunifuTransition1.HideSync(this.userControl11);
                    break;
                // Si estamos en la de Estudiantes, esta se oculta
                case Estado.Estudiantes:
                    this.bunifuTransition2.HideSync(this.userControl21);
                    break;
                // Si estamos en la de Personal, esta se oculta
                case Estado.Personal:
                    this.bunifuTransition3.HideSync(this.userControl31);
                    break;
            }
            // Se establece que estamos en la pantalla Profesores y se muestra
            this.Pantalla = Estado.Profesores;
            this.bunifuTransition1.ShowSync(this.userControl11);
        }
        // Accion de presionar el boton de Estudiantes
        private void bunifuTileButton2_Click( object sender, EventArgs e ) {
            switch (this.Pantalla) {
                // Si estamos en la Principal, esta se oculta
                case Estado.Principal:
                    this.bunifuTransition4.HideSync(this.userControl41);
                    break;
                // Si estamos en la de Profesores, esta se oculta
                case Estado.Profesores:
                    this.bunifuTransition1.HideSync(this.userControl11);
                    break;
                // Si estamos en la de Estudiantes, esta se oculta
                case Estado.Estudiantes:
                    this.bunifuTransition2.HideSync(this.userControl21);
                    break;
                // Si estamos en la de Personal, esta se oculta
                case Estado.Personal:
                    this.bunifuTransition3.HideSync(this.userControl31);
                    break;
            }
            // Se establece que estamos en la pantalla Estudiantes y se muestra
            this.Pantalla = Estado.Estudiantes;
            this.bunifuTransition2.ShowSync(this.userControl21);
        }
        // Accion de presionar el boton de Personal
        private void bunifuTileButton3_Click( object sender, EventArgs e ) {
            switch (this.Pantalla) {
                // Si estamos en la Principal, esta se oculta
                case Estado.Principal:
                    this.bunifuTransition4.HideSync(this.userControl41);
                    break;
                // Si estamos en la de Profesores, esta se oculta
                case Estado.Profesores:
                    this.bunifuTransition1.HideSync(this.userControl11);
                    break;
                // Si estamos en la de Estudiantes, esta se oculta
                case Estado.Estudiantes:
                    this.bunifuTransition2.HideSync(this.userControl21);
                    break;
                // Si estamos en la de Personal, esta se oculta
                case Estado.Personal:
                    this.bunifuTransition3.HideSync(this.userControl31);
                    break;
            }
            // Se establece que estamos en la pantalla Personal y se muestra
            this.Pantalla = Estado.Personal;
            this.bunifuTransition3.ShowSync(this.userControl31);
        }
        // Accion de presionar "el boton" de Inicio
        private void pictureBox3_Click( object sender, EventArgs e ) {
            switch (this.Pantalla) {
                // Si estamos en la Principal, esta se oculta
                case Estado.Principal:
                    this.bunifuTransition4.HideSync(this.userControl41);
                    break;
                // Si estamos en la de Profesores, esta se oculta
                case Estado.Profesores:
                    this.bunifuTransition1.HideSync(this.userControl11);
                    break;
                // Si estamos en la de Estudiantes, esta se oculta
                case Estado.Estudiantes:
                    this.bunifuTransition2.HideSync(this.userControl21);
                    break;
                // Si estamos en la de Personal, esta se oculta
                case Estado.Personal:
                    this.bunifuTransition3.HideSync(this.userControl31);
                    break;
            }
            // Se establece que estamos en la pantalla Principal y se muestra
            this.Pantalla = Estado.Principal;
            this.bunifuTransition4.ShowSync(this.userControl41);
        }
        // Evento de cuando se carga por primera vez la forma
        private void form1_Load( object sender, EventArgs e ) {
            // Se ocultan todos los controles de usuarios
            this.bunifuTransition1.HideSync(this.userControl11);
            this.bunifuTransition2.HideSync(this.userControl21);
            this.bunifuTransition3.HideSync(this.userControl31);
            // Se muestra la pantalla principal
            this.bunifuTransition4.ShowSync(this.userControl41);
            // Se indica que estamos en la pantalla principal
            this.Pantalla = Estado.Principal;
            // Se ocultan los botones para manipular
            this.bunifuImageButton3.Visible = false;
        }
        // Accion de presionar el boton guardar
        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            // Se evalua en que pantalla está
            switch (this.Pantalla) {
                // En caso de estar en la pantalla Profesores
                case Estado.Profesores:
                    // En caso que la validacion sea correcta se ejecuta la alta
                    if (this.userControl11.validate()) 
                        this.userControl11.alta();
                    break;
                // En caso de estar en la pantalla Estudiantes
                case Estado.Estudiantes:
                    // En caso que la validacion sea correcta se ejecuta la alta
                    if (this.userControl21.validate()) 
                        this.userControl21.alta();
                    break;
                // En caso de estar en la pantalla Personal
                case Estado.Personal:
                    // En caso que la validacion sea correcta se ejecuta la alta
                    if (this.userControl31.validate()) 
                        this.userControl31.alta();
                    break;
            }
        }
        // Accion de presionar el boton eliminar
        private void bunifuImageButton4_Click( object sender, EventArgs e ) {
            // Se evalua en que pantalla está
            switch (this.Pantalla) {
                // En caso de estar en la pantalla Profesores
                case Estado.Profesores:
                    // En caso que la validacion sea correcta se ejecuta la baja
                    if (this.userControl11.validate(false)) 
                        this.userControl11.baja();
                    break;
                // En caso de estar en la pantalla Estudiantes
                case Estado.Estudiantes:
                    // En caso que la validacion sea correcta se ejecuta la baja
                    if (this.userControl21.validate(false)) 
                        this.userControl21.baja();
                    break;
                // En caso de estar en la pantalla Personal
                case Estado.Personal:
                    // En caso que la validacion sea correcta se ejecuta la baja
                    if (this.userControl31.validate(false))
                        this.userControl31.baja();
                    break;
            }
        }
        // Accion de presionar el boton editar
        private void bunifuImageButton3_Click( object sender, EventArgs e ) {
            // Se evalua en que pantalla está
            switch (this.Pantalla) {
                // En caso de estar en la pantalla Profesores
                case Estado.Profesores:
                    // En caso que la validacion sea correcta se actualiza el registro
                    if (this.userControl11.validate())
                        this.userControl11.actualizar();
                    break;
                // En caso de estar en la pantalla Estudiantes
                case Estado.Estudiantes:
                    // En caso que la validacion sea correcta se actualiza el registro
                    if (this.userControl21.validate()) 
                        this.userControl21.actualizar();
                    break;
                // En caso de estar en la pantalla Personal
                case Estado.Personal:
                    // En caso que la validacion sea correcta se actualiza el registro
                    if (this.userControl31.validate())
                        this.userControl31.actualizar();
                    break;
            }
            // Se oculta el boton editar y se muestra el boton de guardar
            this.bunifuImageButton3.Visible = false;
            this.bunifuImageButton1.Visible = true;
        }
        // Accion de presionar el boton buscar
        private void bunifuImageButton2_Click( object sender, EventArgs e ) {
            // Se evalua en que pantalla está
            switch (this.Pantalla) {
                // En caso de estar en la pantalla Profesores
                case Estado.Profesores:
                    // En caso que la validacion sea correcta se ejecuta la consulta
                    if (this.userControl11.validate(false))
                        this.userControl11.buscar();
                    break;
                // En caso de estar en la pantalla Estudiantes
                case Estado.Estudiantes:
                    // En caso que la validacion sea correcta se ejecuta la consulta
                    if (this.userControl21.validate(false))
                        this.userControl21.buscar();
                    break;
                // En caso de estar en la pantalla Personal
                case Estado.Personal:
                    // En caso que la validacion sea correcta se ejecuta la consulta
                    if (this.userControl31.validate(false))
                        this.userControl31.buscar();
                    break;
            }
            // Se muestra el boton editar y se oculta el boton de guardar
            this.bunifuImageButton3.Visible = true;
            this.bunifuImageButton1.Visible = false;
        }
    }
}
