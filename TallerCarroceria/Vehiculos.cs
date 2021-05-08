using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TallerCarroceria {
    public partial class Vehiculos : UserControl {
        // Se guardan datos de manera global para hacer cambios, para evitar que el usuario cambie los datps y ocasione un problema
        int idCliente;
        string matricula;
        // Se crea la conexion a la base de datos
        readonly SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=TallerCarroceria; integrated security=true");
        public Vehiculos( ) {
            InitializeComponent();
            // Se crea el grid donde se desplegarán los autos
            crearGrid();
            // Se cargan los años en el combobox
            cargarAnioCombobox();
            // Se oculta el panel donde están los botones y se oculta el botón de editar
            this.bunifuPanel5.Visible = false;
            this.bunifuImageButton3.Visible = false;
        }
        private void crearGrid( ) {
            // Se establece la cantidad de columnas y el texto que tendrán
            this.bunifuDataGridView1.ColumnCount = 4;
            this.bunifuDataGridView1.Columns[ 0 ].Name = "Matricula";
            this.bunifuDataGridView1.Columns[ 1 ].Name = "Marca";
            this.bunifuDataGridView1.Columns[ 2 ].Name = "Modelo";
            this.bunifuDataGridView1.Columns[ 3 ].Name = "Año";
        }
        // Se cargan los datos al dataGrid
        private void cargarGrid( ) {
            // Comando de consulta para obtener los vehiculos del cliente buscado
            SqlCommand consulta = new SqlCommand("SELECT * FROM Vehiculos WHERE idCliente=@ID", this.conexion);
            // Se pasa el valor de id de cliente al comando de consulta
            consulta.Parameters.AddWithValue("ID", this.idCliente);
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
        private void cargarAnioCombobox( ) {
            // Se crea un for que va desde el año actual hasta 1980 y cada año se añade al combobox
            for (int i = DateTime.Now.Year; i >= 1980; i--) {
                this.comboBox1.Items.Add(i.ToString());
            }
            // Se deja seleccionado el primer año, es decir, el año actual
            this.comboBox1.SelectedIndex = 0;
        }
        // Se cargan datos a los comboBox directo de la BD
        private void cargarComboBox( ) {
            // En caso que haya datos ya cargados se limpian para volver a cargarlos
            this.comboBox2.Items.Clear();
            // Se cargan las matriculas (campo clave) de la tabla en cuestion
            SqlCommand obtenerID = new SqlCommand("SELECT matriculaVehiculo FROM Vehiculos WHERE idCliente = @ID", this.conexion);
            obtenerID.Parameters.AddWithValue("ID", this.idCliente);
            // Se abre la conexión
            this.conexion.Open();
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox2.Items.Add(IDs[ "matriculaVehiculo" ].ToString());
            }
            // Se cierra la conexion
            this.conexion.Close();
            // En caso que haya datos cargados en el comboBox, se elige el primero para mostrarse
            if (this.comboBox2.Items.Count > 0)
                this.comboBox2.SelectedIndex = 0;
        }
        // Se busca si existe el cliente
        private bool buscar( ) {
            // Se crea un bool indicando que no existe el cliente
            bool confirm = false;
            // Se crea el comando para hacer una consulta solo con el id
            SqlCommand consulta = new SqlCommand("SELECT * FROM Clientes WHERE idCliente=@ID", this.conexion);
            // Se carga el id en el parametro usado en el comando SQL
            if (string.IsNullOrEmpty(this.bunifuTextBox1.Text))
                MessageBox.Show("¡Ingresa un ID!");
            else {
                this.idCliente = int.Parse(this.bunifuTextBox1.Text);
                consulta.Parameters.AddWithValue("ID", this.idCliente);
                // Se abre la conexion
                this.conexion.Open();
                // Se guardan datos en un SqlDataReader
                SqlDataReader data = consulta.ExecuteReader();
                // Si comprueba que si hay algun registro con ese usuario
                confirm = data.Read();
            }
            // Se cierra la conexion
            this.conexion.Close();
            // Se regresa el valor para saber si existe el cliente
            return confirm;
        }
        // Se buscan datos en la BD
        public void buscarV( object sender, EventArgs e ) {
            // Se crea el comando para hacer una consulta solo con el id
            SqlCommand consulta = new SqlCommand("SELECT * FROM Vehiculos WHERE matriculaVehiculo=@Matricula AND idCliente=@ID", this.conexion);
            // Se carga el id en el parametro usado en el comando SQL
            consulta.Parameters.AddWithValue("Matricula", this.comboBox2.Text);
            consulta.Parameters.AddWithValue("ID", this.idCliente);
            this.matricula = this.comboBox2.Text;
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Si hay datos que leer se leen
            while (data.Read()) {
                // Se cargan los datos conseguidos en cada textBox y se indica que se ha encontrado
                this.bunifuTextBox3.Text = data[ 1 ].ToString();
                this.bunifuTextBox4.Text = data[ 2 ].ToString();
                this.comboBox1.SelectedItem = data[ 3 ].ToString();
                MessageBox.Show("Registro encontrado");
            }
            // Se cierra la conexion
            this.conexion.Close();
            this.bunifuImageButton1.Visible = false;
            this.bunifuImageButton3.Visible = true;
        }
        // Se cargan los datos a la BD
        public void alta( object sender, EventArgs e ) {
            // Se crea el comando para dar de Altas a la BD
            SqlCommand altas = new SqlCommand("INSERT INTO Vehiculos VALUES(@Matricula,@Marca,@Modelo,@Anio,@ID)", this.conexion);
            // Se pasan los valores de los textBox a las variables temporales
            altas.Parameters.AddWithValue("Matricula", this.comboBox2.Text);
            altas.Parameters.AddWithValue("Marca", this.bunifuTextBox3.Text);
            altas.Parameters.AddWithValue("Modelo", this.bunifuTextBox4.Text);
            altas.Parameters.AddWithValue("Anio", int.Parse(this.comboBox1.Text));
            altas.Parameters.AddWithValue("ID", this.idCliente);
            // Se abre la conexion
            this.conexion.Open();
            try {
                // Se cargan los datos a la BD
                altas.ExecuteNonQuery();
            }
            // En caso que haya un excepcion sql, en este caso solo podria darse por intentar
            // hacer un registro con un id existente, se actualiza el registro
            catch (SqlException) {
                this.conexion.Close();
                actualizar(null, null);
            }
            finally {
                // En caso de que la conexion esté abierta se cierra
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
            // Se crea el comando para eliminar un registro con solo saber la matricula(campo principal, llave primaria)
            SqlCommand bajas = new SqlCommand("DELETE FROM Vehiculos WHERE matriculaVehiculo = @Matricula AND idCliente = @ID", this.conexion);
            bajas.Parameters.AddWithValue("ID", this.idCliente);
            bajas.Parameters.AddWithValue("Matricula", this.comboBox2.Text);
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
            SqlCommand actualizar = new SqlCommand("UPDATE Vehiculos SET matriculaVehiculo=@Matricula,marcaVehiculo=@Marca,modeloVehiculo=@Modelo,anioVehiculo=@Anio WHERE matriculaVehiculo=@mat AND idCliente=@ID", this.conexion);
            // Se cargan las variables que se declaraon en el comando anterior
            actualizar.Parameters.AddWithValue("mat", this.matricula);
            actualizar.Parameters.AddWithValue("ID", this.idCliente);
            actualizar.Parameters.AddWithValue("Matricula", this.comboBox2.Text);
            actualizar.Parameters.AddWithValue("Marca", this.bunifuTextBox3.Text);
            actualizar.Parameters.AddWithValue("Modelo", this.bunifuTextBox4.Text);
            actualizar.Parameters.AddWithValue("Anio", int.Parse(this.comboBox1.Text));
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
        // Metodo para limpiar todos los campos de entrada
        public void limpiar( ) {
            this.bunifuTextBox3.Clear();
            this.bunifuTextBox4.Clear();
            // Se cargan los comboBox
            cargarComboBox();
            this.comboBox1.SelectedIndex = 0;
        }
        private void bunifuImageButton5_Click( object sender, EventArgs e ) {
            this.bunifuPanel5.Visible = buscar();
            if (this.bunifuPanel5.Visible) {
                buscar();
                cargarComboBox();
                cargarGrid();
            }
        }
    }
}
