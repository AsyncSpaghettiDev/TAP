using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TallerCarroceria {
    public partial class Herramientas : UserControl {
        readonly SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=TallerCarroceria; integrated security=true");
        public Herramientas( ) {
            InitializeComponent();
            crearGrid();
            cargarComboBox();
            this.bunifuImageButton3.Visible = false;
            this.bunifuDatePicker1.MaxDate = DateTime.Now.AddYears(1);
        }
        private void crearGrid( ) {
            this.bunifuDataGridView1.ColumnCount = 4;
            this.bunifuDataGridView1.Columns[ 0 ].Name = "ID";
            this.bunifuDataGridView1.Columns[ 1 ].Name = "Fecha Compra";
            this.bunifuDataGridView1.Columns[ 2 ].Name = "Nombre";
            this.bunifuDataGridView1.Columns[ 3 ].Name = "Marca";
            // Se cargan los datos en el dataGrid ya creado
            cargarGrid();
        }
        // Se cargan los datos al dataGrid
        private void cargarGrid( ) {
            // Comando de consulta
            SqlCommand consulta = new SqlCommand("SELECT * FROM Herramientas", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan los datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Se limpian las columnas de datos
            this.bunifuDataGridView1.Rows.Clear();
            // Mientras haya datos para leer se registrarán en el dataGrid
            while (data.Read()) {
                // Se crea un array, y se "cambia" de SqlDataReader a un array normal. PD: SqlDataReader se recorre como un array normal
                string[] row = new string[] { data[ 0 ].ToString(), data[ 1 ].ToString(), data[ 2 ].ToString(), data[ 3 ].ToString() };
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
        // Se cargan datos a los comboBox directo de la BD
        private void cargarComboBox( ) {
            // En caso que haya datos ya cargados se limpian para volver a cargarlos
            this.comboBox1.Items.Clear();
            // Se cargan los ID's (campo clave) de la tabla en cuestion
            SqlCommand obtenerID = new SqlCommand("SELECT idHerramienta FROM Herramientas", this.conexion);
            // Se abre la conexión
            this.conexion.Open();
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox1.Items.Add(IDs[ "idHerramienta" ].ToString());
            }
            // Se cierra la conexion
            this.conexion.Close();
            // En caso que haya datos cargados en el comboBox, se elige el primero para mostrarse
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
        }
        // Se cargan los datos a la BD
        public void alta( object sender, EventArgs e ) {
            // Se crea el comando para dar de Altas a la BD
            SqlCommand altas = new SqlCommand("INSERT INTO Herramientas VALUES(@ID,@Fecha,@Tipo,@Marca)", this.conexion);
            // Se pasan los valores de los textBox a las variables temporales
            altas.Parameters.AddWithValue("ID", int.Parse(this.comboBox1.Text));
            altas.Parameters.AddWithValue("Fecha", this.bunifuDatePicker1.Value.Date);
            altas.Parameters.AddWithValue("Tipo", this.bunifuTextBox2.Text);
            altas.Parameters.AddWithValue("Marca", this.bunifuTextBox1.Text);
            // Se abre la conexion
            this.conexion.Open();
            try {
                // Se cargan los datos a la BD
                altas.ExecuteNonQuery();
            }
            catch (SqlException) {
                this.conexion.Close();
                actualizar(null, null);
            }
            finally {
                if (this.conexion.State == ConnectionState.Open)
                    // Se cierra la conexion
                    this.conexion.Close();
            }
            // Se actualiza la gridData
            cargarGrid();
            // Se limpian los datos
            limpiar();
            MessageBox.Show("Registro guardado correctamente");
        }
        // Eliminar un registro
        public void baja( object sender, EventArgs e ) {
            // Se crea el comando para eliminar un registro con solo saber el id(campo principal, llave primaria)
            SqlCommand bajas = new SqlCommand("DELETE FROM Herramientas WHERE idHerramienta = @ID", this.conexion);
            bajas.Parameters.AddWithValue("ID", int.Parse(this.comboBox1.Text));
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
        private void actualizar( object sender, EventArgs e ) {
            // Se crea el comando para actualizar los datos
            SqlCommand actualizar = new SqlCommand("UPDATE Herramientas SET idHerramienta=@ID,fechaCompraHerramienta=@Fecha,tipoHerramienta=@Tipo, marcaHerramienta=@Marca WHERE idHerramienta=@ID", this.conexion);
            // Se pasan los valores de los textBox a las variables temporales
            actualizar.Parameters.AddWithValue("ID", int.Parse(this.comboBox1.Text));
            actualizar.Parameters.AddWithValue("Fecha", this.bunifuDatePicker1.Value.Date);
            actualizar.Parameters.AddWithValue("Tipo", this.bunifuTextBox2.Text);
            actualizar.Parameters.AddWithValue("Marca", this.bunifuTextBox1.Text);
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
                this.bunifuImageButton1.Visible = true;
                this.bunifuImageButton3.Visible = false;
            }
        }
        // Se buscan datos en la BD
        public void buscar( object sender, EventArgs e ) {
            // Se crea el comando para hacer una consulta solo con el id
            SqlCommand consulta = new SqlCommand("SELECT * FROM Herramientas WHERE idHerramienta=@ID", this.conexion);
            // Se carga el id en el parametro usado en el comando SQL
            consulta.Parameters.AddWithValue("ID", int.Parse(this.comboBox1.Text));
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Si hay datos que leer se leen
            while (data.Read()) {
                // Se cargan los datos conseguidos en cada textBox
                this.bunifuDatePicker1.Text = data[ 1 ].ToString();
                this.bunifuTextBox2.Text = data[ 2 ].ToString();
                this.bunifuTextBox1.Text = data[ 3 ].ToString();
                MessageBox.Show("Registro encontrado");
            }
            // Se cierra la conexion
            this.conexion.Close();
            this.bunifuImageButton1.Visible = false;
            this.bunifuImageButton3.Visible = true;
        }
        // Metodo para limpiar todos los campos de entrada
        public void limpiar( ) {
            this.bunifuDatePicker1.Value = DateTime.Now;
            this.bunifuTextBox1.Clear();
            // Se cargan los comboBox
            cargarComboBox();
        }
    }
}
