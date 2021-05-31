using System;
using Conexion;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Agenda {
    public partial class Contacto : UserControl {
        readonly BaseDatos @base = new BaseDatos(@"JONATHAN\JONATHANSERVER", "Agenda");
        readonly string user;
        readonly string id;
        readonly ListaContactos contenedor;
        readonly PictureBox agregarBtn;
        public Contacto( ListaContactos contenedor, string user, int actual, PictureBox agregarBtn ) {
            InitializeComponent();
            this.user = user;
            this.id = user + "|" + actual;
            this.agregarBtn = agregarBtn;
            this.comboBox1.SelectedIndex = 0;
            this.contenedor = contenedor;
        }
        public Contacto( ListaContactos contenedor, string user, string ID, string nombre, string telefono, string fecha, string redSocial ) {
            InitializeComponent();
            DateTimeConverter dateTimeConverter = new DateTimeConverter();
            dateTimeConverter.ConvertFromString(fecha);
            DateTime dateTime = new DateTime(( ( DateTime ) dateTimeConverter.ConvertFromString(fecha) ).Year, ( ( DateTime ) dateTimeConverter.ConvertFromString(fecha) ).Month, ( ( DateTime ) dateTimeConverter.ConvertFromString(fecha) ).Day);
            this.id = ID;
            this.user = user;
            this.bunifuTextBox1.Text = nombre;
            this.bunifuTextBox2.Text = telefono;
            this.bunifuDatePicker1.Text = dateTime.ToString("dd - MMMM");
            this.comboBox1.SelectedItem = redSocial;
            this.contenedor = contenedor;
        }

        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            guardarContacto();
        }
        private void guardarContacto( ) {
            string[] data = new string[] {
                $"('{this.id}')",
                $"('{this.bunifuTextBox1.Text}')",
                $"('{long.Parse(this.bunifuTextBox2.Text)}')",
                $"@fecha",
                $"('{this.comboBox1.Text}')",
                $"('{this.user}')",
            };
            if (this.@base.Alta("Contactos", data, this.bunifuDatePicker1.Value.Date)) {
                this.agregarBtn.Show();
                MessageBox.Show("Contacto guardado correctamente");
            }
            else 
                actualizarContacto();
        }
        // Se actualiza un registro con los datos recopilados
        private void actualizarContacto( ) {
            string[] data = new string[] {
                $"nombreContacto='{this.bunifuTextBox1.Text}'",
                $"telefonoContacto='{long.Parse(this.bunifuTextBox2.Text)}'",
                $"fechaNacimientoContacto='{this.bunifuDatePicker1.Value.Date}'",
                $"redSocialContacto='{this.comboBox1.Text}'"
            };
            if (this.@base.Actualizar("Contactos", data, "idContacto='{this.id}'"))
                MessageBox.Show("Contacto actualizado correctamente");
        }

        private void bunifuImageButton2_Click( object sender, EventArgs e ) {
            eliminarContactor();
        }
        // Eliminar un registro
        private void eliminarContactor( ) {
            this.@base.Baja("Contactos", "idContacto='{this.id}'");
            Dispose();
            // Se limpia los contactos cargados
            this.contenedor.CargarContactos();
            MessageBox.Show("Contacto eliminado correctamente");
        }

        private void bunifuTextBox2_Validating( object sender, CancelEventArgs e ) {
            ToolTip toolTip = new ToolTip() {
                ToolTipTitle = "Telefono inválido"
            };
            if (!long.TryParse(this.bunifuTextBox2.Text, out _)) {
                toolTip.Show("El número de teléfono debe ser solo de números", sender as IWin32Window, 5000);
                e.Cancel = true;
            }
            else if (this.bunifuTextBox2.Text.Length != 10) {
                toolTip.Show("El número de teléfono debe ser de 10 dígitos", sender as IWin32Window, 5000);
                e.Cancel = true;
            }
        }
    }
}
