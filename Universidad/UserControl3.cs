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
    public partial class UserControl3 : UserControl {
        // Se crea la conexion con la base de datos
        readonly SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=uni; integrated security=true");
        public UserControl3( ) {
            // Se cargan todos los elementos visuales, y se cargan los datos de los comboBox y el dataGrid
            InitializeComponent();
            cargarComboBox();
            crearGrid();
        }
        // Se cargan datos a los comboBox directo de la BD
        private void cargarComboBox( ) {
            // En caso que haya datos ya cargados se limpian para volver a cargarlos
            this.comboBox1.Items.Clear();
            // Se cargan los ID's (campo clave) de la tabla en cuestion
            SqlCommand obtenerID = new SqlCommand("SELECT idPersonal FROM personal", this.conexion);
            // Se abre la conexión
            this.conexion.Open();
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox1.Items.Add(IDs[ "idPersonal" ].ToString());
            }
            // Se cierra la conexion
            this.conexion.Close();
            // En caso que haya datos cargados en el comboBox, se elige el primero para mostrarse
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
        }
        // Se cargan los datos a la BD
        public void alta() {
            // Se crea el comando para dar de Altas a la BD
            SqlCommand altas = new SqlCommand("INSERT INTO personal VALUES(@idPersonal,@nombrePersonal,@direccionPersonal,@telefonoPersonal,@emailPersonal,@unidadPersonal,@categoriaPersonal)", this.conexion);
            // Se pasan los valores de los textBox a las variables temporales
            altas.Parameters.AddWithValue("idPersonal", int.Parse(this.comboBox1.Text));
            altas.Parameters.AddWithValue("nombrePersonal", this.bunifuTextBox2.Text);
            altas.Parameters.AddWithValue("direccionPersonal", this.bunifuTextBox3.Text);
            altas.Parameters.AddWithValue("telefonoPersonal", long.Parse(this.bunifuTextBox4.Text));
            altas.Parameters.AddWithValue("emailPersonal", this.bunifuTextBox5.Text);
            altas.Parameters.AddWithValue("unidadPersonal", this.bunifuTextBox6.Text);
            altas.Parameters.AddWithValue("categoriaPersonal", this.bunifuTextBox7.Text);
            // Se abre la conexion
            this.conexion.Open();
            // Se cargan los datos a la BD
            altas.ExecuteNonQuery();
            // Se cierra la conexion
            this.conexion.Close();
            // Se actualiza la gridData
            cargarGrid();
            // Se limpian los datos
            limpiar();
            MessageBox.Show("Registro guardado correctamente");
        }
        // Eliminar un registro
        public void baja( ) {
            // Se crea el comando para eliminar un registro con solo saber el id(campo principal, llave primaria)
            SqlCommand bajas = new SqlCommand("DELETE FROM personal WHERE idPersonal = @idPersonal", this.conexion);
            bajas.Parameters.AddWithValue("idPersonal",int.Parse(this.comboBox1.Text));
            // Se liberan los recursos
            bajas.Dispose();
            // Se abre la conexion
            this.conexion.Open();
            // Se ejecuta el comando de eliminar
            bajas.ExecuteNonQuery();
            // Se cierra la conexion
            this.conexion.Close();
            // Se actualiza la gridData
            cargarGrid();
            // Se limpian los datos
            limpiar();
            MessageBox.Show("Registro eliminado correctamente");
        }
        // Se actualiza un registro con los datos recopilados
        public void actualizar( ) {
            // Se crea el comando para actualizar los datos
            SqlCommand actualizar = new SqlCommand("UPDATE personal SET nombrePersonal=@nombrePersonal,direccionPersonal=@direccionPersonal,telefonoPersonal=@telefonoPersonal,emailPersonal=@emailPersonal,unidadPersonal=@unidadPersonal,categoriaPersonal=@categoriaPersonal WHERE idPersonal = @idPersonal", this.conexion);
            // Se cargan las variables que se declaraon en el comando anterior
            actualizar.Parameters.AddWithValue("idPersonal", int.Parse(this.comboBox1.Text));
            actualizar.Parameters.AddWithValue("nombrePersonal", this.bunifuTextBox2.Text);
            actualizar.Parameters.AddWithValue("direccionPersonal", this.bunifuTextBox3.Text);
            actualizar.Parameters.AddWithValue("telefonoPersonal", long.Parse(this.bunifuTextBox4.Text));
            actualizar.Parameters.AddWithValue("emailPersonal", this.bunifuTextBox5.Text);
            actualizar.Parameters.AddWithValue("unidadPersonal", this.bunifuTextBox6.Text);
            actualizar.Parameters.AddWithValue("categoriaPersonal", this.bunifuTextBox7.Text);
            // Se abre la conexion
            this.conexion.Open();
            // En caso de haber algun problema al ejecutar el editar se notifica al usuario
            try {
                actualizar.ExecuteNonQuery();
                MessageBox.Show("Registro actualizado correctamente");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally {
                // Se cierra la conexion
                this.conexion.Close();
                // Se actualiza la gridData
                cargarGrid();
                // Se limpian los datos
                limpiar();
            }
        }
        // Se crean las columnas del dataGrid y se les da nombre a cada columna, el campo ID se restringe a 25px
        private void crearGrid( ) {
            this.bunifuDataGridView1.ColumnCount = 7;
            this.bunifuDataGridView1.Columns[ 0 ].Name = "ID";
            this.bunifuDataGridView1.Columns[ 0 ].Width = 25;
            this.bunifuDataGridView1.Columns[ 1 ].Name = "Nombre";
            this.bunifuDataGridView1.Columns[ 2 ].Name = "Direccion";
            this.bunifuDataGridView1.Columns[ 3 ].Name = "Telefono";
            this.bunifuDataGridView1.Columns[ 4 ].Name = "e-mail";
            this.bunifuDataGridView1.Columns[ 5 ].Name = "Unidad Administativa";
            this.bunifuDataGridView1.Columns[ 6 ].Name = "Categoria Profesional";
            // Se cargan los datos en el dataGrid ya creado
            cargarGrid();
        }
        // Se cargan los datos al dataGrid
        private void cargarGrid( ) {
            // Comando de consulta
            SqlCommand consulta = new SqlCommand("SELECT * FROM personal", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan los datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Se limpian las columnas de datos
            this.bunifuDataGridView1.Rows.Clear();
            // Mientras haya datos para leer se registrarán en el dataGrid
            while (data.Read()) {
                // Se crea un array, y se "cambia" de SqlDataReader a un array normal. PD: SqlDataReader se recorre como un array normal
                string[] row = new string[] { data[ 0 ].ToString(), data[ 1 ].ToString(), data[ 2 ].ToString(), data[ 3 ].ToString(), data[ 4 ].ToString(), data[ 5 ].ToString(), data[ 6 ].ToString() };
                // En caso que el ID este vacio se da la instruccion de seguir
                if (string.IsNullOrEmpty(data[ 0 ].ToString()))
                    continue;
                // En caso contrario se añade esa fila a la dataGrid
                else
                    this.bunifuDataGridView1.Rows.Add(row);
            }
            // Se cierra la conexion
            this.conexion.Close();
        }
        // Metodo para limpiar todos los campos de entrada
        public void limpiar( ) {
            this.bunifuTextBox2.Clear();
            this.bunifuTextBox3.Clear();
            this.bunifuTextBox4.Text = "664";
            this.bunifuTextBox5.Clear();
            this.bunifuTextBox6.Clear();
            this.bunifuTextBox7.Clear();
            // Se cargan los comboBox
            cargarComboBox();
        }
        // Se buscan datos en la BD
        public void buscar( ) {
            // Se crea el comando para hacer una consulta solo con el id
            SqlCommand consulta = new SqlCommand("SELECT * FROM personal WHERE nombrePersonal=@nombrePersonal", this.conexion);
            // Se carga el id en el parametro usado en el comando SQL
            consulta.Parameters.AddWithValue("nombrePersonal", int.Parse(this.comboBox1.Text));
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Si hay datos que leer se leen
            while (data.Read()) {
                // Se cargan los datos conseguidos en cada textBox
                this.bunifuTextBox2.Text = data[ 1 ].ToString();
                this.bunifuTextBox3.Text = data[ 2 ].ToString();
                this.bunifuTextBox4.Text = data[ 3 ].ToString();
                this.bunifuTextBox5.Text = data[ 4 ].ToString();
                this.bunifuTextBox6.Text = data[ 5 ].ToString();
                this.bunifuTextBox7.Text = data[ 6 ].ToString();
                MessageBox.Show("Registro encontrado");
            }
            // Se cierra la conexion
            this.conexion.Close();
        }
        // Se hacen validaciones para evitar errores
        public bool validate( bool validar = true ) {
            // Se comprueba que el campo ID no esté vacio
            if (string.IsNullOrEmpty(this.comboBox1.Text)) {
                MessageBox.Show("¡Ingrese un ID!");
                return false;
            }
            // Se comprueba que el telefono tenga una longitud de 10 digitos
            if (this.bunifuTextBox4.Text.Length != 10 && validar) {
                MessageBox.Show("¡Ingresa un teléfono de 10 dígitos!");
                return false;
            }
            // Se comprueba que sea un ID numerico
            if (!long.TryParse(this.comboBox1.Text, out _)) {
                MessageBox.Show("¡EL ID debe ser numérico!");
                return false;
            }
            // Se comprueba que se puede convertir a numero
            if (!long.TryParse(this.bunifuTextBox4.Text, out _) && validar) {
                MessageBox.Show("¡Ingresa un teléfono válido!");
                return false;
            }
            return true;
        }
    }
}
