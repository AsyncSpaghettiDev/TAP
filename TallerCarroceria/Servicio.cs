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

namespace TallerCarroceria {
    public partial class Servicio : UserControl {
        // Variables globales de los id's
        int idTrabajo = 0;
        int idCliente = 0;
        int idTrabajador = 0;
        // Establecer la conexion a la base de datos
        readonly SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=TallerCarroceria; integrated security=true");
        public Servicio( ) {
            InitializeComponent();
            crearGrid();
            cargarComboBox();
            // Se define que el primer y segundo datepicker tendrá el limite de fecha del proximo año
            this.bunifuDatePicker1.MaxDate = DateTime.Now.AddYears(1);
            this.bunifuDatePicker2.MaxDate = DateTime.Now.AddYears(1);
            // Se define que el segundo datepicker tendrá 1 semana mas que el primer datepicker
            this.bunifuDatePicker2.Value = DateTime.Now.AddDays(7);
            // Se oculta el boton de editar
            this.bunifuImageButton3.Visible = false;
        }
        private void crearGrid( ) {
            // Se define que tendrá 7 columnas el datagrid
            this.bunifuDataGridView1.ColumnCount = 7;
            // Se definen el texto de cada columna
            this.bunifuDataGridView1.Columns[ 0 ].Name = "Servicio #";
            this.bunifuDataGridView1.Columns[ 1 ].Name = "Inicio";
            this.bunifuDataGridView1.Columns[ 2 ].Name = "Final";
            this.bunifuDataGridView1.Columns[ 3 ].Name = "Precio";
            this.bunifuDataGridView1.Columns[ 4 ].Name = "Trabajo";
            this.bunifuDataGridView1.Columns[ 5 ].Name = "Cliente";
            this.bunifuDataGridView1.Columns[ 6 ].Name = "Trabajador";
            // Se cargan los datos en el dataGrid ya creado
            cargarGrid();
        }
        // Se cargan los datos al dataGrid
        private void cargarGrid( ) {
            // Comando de consulta
            SqlCommand consulta = new SqlCommand("SELECT * FROM Servicio", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan los datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Se limpian las columnas de datos
            this.bunifuDataGridView1.Rows.Clear();
            // Mientras haya datos para leer se registrarán en el dataGrid
            while (data.Read()) {
                // Se crea un array, y se "cambia" de SqlDataReader a un array normal. PD: SqlDataReader se recorre como un array normal
                string[] row = new string[] {
                    data[ 0 ].ToString(),
                    data[ 1 ].ToString(),
                    data[ 2 ].ToString(),
                    data[ 3 ].ToString(),
                    data[ 4 ].ToString(),
                    data[ 5 ].ToString(),
                    data[ 6 ].ToString()
                };
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
            SqlCommand obtenerID = new SqlCommand("SELECT noServicio FROM Servicio", this.conexion);
            // Se abre la conexión
            this.conexion.Open();
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox1.Items.Add(IDs[ "noServicio" ].ToString());
            }
            // Se cierra la conexion
            IDs.Close();
            // En caso que haya datos ya cargados se limpian para volver a cargarlos
            this.comboBox2.Items.Clear();
            // Se cargan los ID's (campo clave) de la tabla en cuestion
            obtenerID = new SqlCommand("SELECT nombreTrabajo FROM catalogoTrabajos", this.conexion);
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox2.Items.Add(IDs[ "nombreTrabajo" ].ToString());
            }
            // Se cierra la conexion
            IDs.Close();
            // En caso que haya datos ya cargados se limpian para volver a cargarlos
            this.comboBox3.Items.Clear();
            // Se cargan los ID's (campo clave) de la tabla en cuestion
            obtenerID = new SqlCommand("SELECT nombreCliente FROM Clientes", this.conexion);
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox3.Items.Add(IDs[ "nombreCliente" ].ToString());
            }
            // Se cierra la conexion
            IDs.Close();
            // En caso que haya datos ya cargados se limpian para volver a cargarlos
            this.comboBox4.Items.Clear();
            // Se cargan los ID's (campo clave) de la tabla en cuestion
            obtenerID = new SqlCommand("SELECT nombreTrabajador FROM Trabajadores", this.conexion);
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            IDs = obtenerID.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            while (IDs.Read()) {
                // Se añade ID por ID al comboBox
                this.comboBox4.Items.Add(IDs[ "nombreTrabajador" ].ToString());
            }
            // Se cierra la conexion
            this.conexion.Close();
            // En caso que haya datos cargados en el comboBox1, se elige el primero para mostrarse
            if (this.comboBox1.Items.Count > 0)
                this.comboBox1.SelectedIndex = 0;
            // En caso que haya datos cargados en el comboBox2, se elige el primero para mostrarse
            if (this.comboBox2.Items.Count > 0)
                this.comboBox2.SelectedIndex = -1;
            // En caso que haya datos cargados en el comboBox3, se elige el primero para mostrarse
            if (this.comboBox3.Items.Count > 0)
                this.comboBox3.SelectedIndex = -1;
            // En caso que haya datos cargados en el comboBox3, se elige el primero para mostrarse
            if (this.comboBox4.Items.Count > 0)
                this.comboBox4.SelectedIndex = -1;
        }
        // Se ejecuta cada que se modifica el valor seleccioando de los combobox
        private void calcularPrecio( object sender, EventArgs e ) {
            // Se limpia el texto del textbox1
            this.bunifuTextBox1.Clear();
            // Se definen variables auxiliares para calcular datos
            double precioBase = 0;
            double descuento = 0;
            double precioFinal;
            // Se obtiene el precio del trabajo con base en el nombre del trabajo
            SqlCommand obtenerPrecio = new SqlCommand("SELECT precioTrabajo FROM catalogoTrabajos WHERE nombreTrabajo=@nTrabajo", this.conexion);
            obtenerPrecio.Parameters.AddWithValue("@nTrabajo", this.comboBox2.Text);
            // Se abre la conexión
            this.conexion.Open();
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader Precio = obtenerPrecio.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            if (Precio.Read())
                // Se añade ID por ID al comboBox
                precioBase = double.Parse(Precio[ 0 ].ToString());
            Precio.Close();
            obtenerPrecio.Dispose();

            // Se obtiene el descuento del cliente con base en el nombre del cliente
            SqlCommand obtenerDescuento = new SqlCommand("SELECT descuentoCliente FROM Clientes WHERE nombreCliente=@nCliente", this.conexion);
            obtenerDescuento.Parameters.AddWithValue("@nCliente", this.comboBox3.Text);
            // Se abre la conexión
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader Descuento = obtenerDescuento.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            if (Descuento.Read())
                // Se añade ID por ID al comboBox
                descuento = double.Parse(Descuento[ 0 ].ToString());
            // Se cierran los dataReaders
            Descuento.Close();
            obtenerDescuento.Dispose();
            // Se cierra la conexion
            this.conexion.Close();
            // Se calcula el precio
            precioFinal = precioBase - ( descuento * precioBase );
            // Se escribe el precio en el textBox
            this.bunifuTextBox1.Text = precioFinal.ToString();
        }
        // Se obtienen los ids de los campos en los que se usó el nombre en lugar del id
        private void getIDS( ) {
            this.idCliente = getIdByName("SELECT idCliente FROM Clientes WHERE nombreCliente=@Nombre", this.comboBox3.Text);
            this.idTrabajo = getIdByName("SELECT idTrabajo FROM catalogoTrabajos WHERE nombreTrabajo=@Nombre", this.comboBox2.Text);
            this.idTrabajador = getIdByName("SELECT idTrabajador FROM Trabajadores WHERE nombreTrabajador=@Nombre", this.comboBox4.Text);
        }
        // Metodo encargado de conseguir un id apartir de un nombre
        private int getIdByName( string sql, string origen) {
            int id = 0;
            // Se cargan los ID's que cumplan la condicion de la tabla en cuestion
            SqlCommand getTrabajador = new SqlCommand(sql, this.conexion);
            this.conexion.Open();
            getTrabajador.Parameters.AddWithValue("@Nombre", origen);
            // Se abre la conexión
            // Se "guardan" todos los ID's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader IDTT = getTrabajador.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            if (IDTT.Read())
                // Se añade ID por ID al comboBox
                id = int.Parse(IDTT[ 0 ].ToString());
            this.conexion.Close();
            return id;
        }
        // Se cargan los datos a la BD
        public void alta( object sender, EventArgs e ) {
            getIDS();
            // Se crea el comando para dar de Altas a la BD
            SqlCommand altas = new SqlCommand("INSERT INTO Servicio VALUES(@ID,@Inicio,@Final,@Precio,@Trabajo,@Cliente,@Trabajador)", this.conexion);
            // Se pasan los valores de los textBox a las variables temporales
            altas.Parameters.AddWithValue("ID", int.Parse(this.comboBox1.Text));
            altas.Parameters.AddWithValue("Inicio", this.bunifuDatePicker1.Value.Date);
            altas.Parameters.AddWithValue("Final", this.bunifuDatePicker2.Value.Date);
            altas.Parameters.AddWithValue("Precio", double.Parse(this.bunifuTextBox1.Text));
            altas.Parameters.AddWithValue("Trabajo", this.idTrabajo);
            altas.Parameters.AddWithValue("Cliente", this.idCliente);
            altas.Parameters.AddWithValue("Trabajador", this.idTrabajador);
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
            // Se crea el comando para eliminar un registro con solo saber el id(campo principal, llave primaria)
            SqlCommand bajas = new SqlCommand("DELETE FROM Servicio WHERE noServicio=@ID", this.conexion);
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
            getIDS();
            // Se crea el comando para actualizar los datos
            SqlCommand actualizar = new SqlCommand("UPDATE Servicio SET fechaInicioServicio=@Inicio,fechaFinalServicio=@Final,precioServicio=@Precio,idTrabajo=@Trabajo,idCliente=@Cliente,idTrabajador=@Trabajador WHERE noServicio=@ID", this.conexion);
            // Se pasan los valores de los textBox a las variables temporales
            actualizar.Parameters.AddWithValue("ID", int.Parse(this.comboBox1.Text));
            actualizar.Parameters.AddWithValue("Inicio", this.bunifuDatePicker1.Value.Date);
            actualizar.Parameters.AddWithValue("Final", this.bunifuDatePicker2.Value.Date);
            actualizar.Parameters.AddWithValue("Precio", double.Parse(this.bunifuTextBox1.Text));
            actualizar.Parameters.AddWithValue("Trabajo", this.idTrabajo);
            actualizar.Parameters.AddWithValue("Cliente", this.idCliente);
            actualizar.Parameters.AddWithValue("Trabajador", this.idTrabajador);
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
            // Varibles locales para poder usar los datos posteriormente
            int idTrabajo = 0;
            int idCliente = 0;
            int idTrabajador = 0;
            // Se crea el comando para hacer una consulta solo con el id
            SqlCommand consulta = new SqlCommand("SELECT * FROM Servicio WHERE noServicio=@ID", this.conexion);
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
                this.bunifuDatePicker2.Text = data[ 2 ].ToString();
                this.bunifuTextBox1.Text = data[ 3 ].ToString();
                idTrabajo = int.Parse(data[ 4 ].ToString());
                idCliente = int.Parse(data[ 5 ].ToString());
                idTrabajador = int.Parse(data[ 6 ].ToString());
                MessageBox.Show("Registro encontrado");
            }
            // Se cierra la conexion
            this.conexion.Close();
            // Se selecciona un nombre apartir de un id
            this.comboBox2.SelectedItem = getNamebyID("SELECT nombreTrabajo FROM catalogoTrabajos WHERE idTrabajo=@ID", idTrabajo);
            this.comboBox3.SelectedItem = getNamebyID("SELECT nombreCliente FROM Clientes WHERE idCliente=@ID", idCliente);
            this.comboBox4.SelectedItem = getNamebyID("SELECT nombreTrabajador FROM Trabajadores WHERE idTrabajador=@ID", idTrabajador);
            this.bunifuImageButton1.Visible = false;
            this.bunifuImageButton3.Visible = true;
        }
        // Metodo encargado de obtener un nombre apartir de un id
        private string getNamebyID( string sql, int id) {
            string name = null;
            // Se cargan los nombres (campo clave) de la tabla en cuestion
            SqlCommand getCliente = new SqlCommand(sql, this.conexion);
            getCliente.Parameters.AddWithValue("ID", id);
            // Se abre la conexión
            this.conexion.Open();
            // Se "guardan" todos los nombres's en SqlDataReader, que no es mas que una lista de arrays
            SqlDataReader IDC = getCliente.ExecuteReader();
            // Mientras haya datos en el SqlDataReader se leeran los datos
            if (IDC.Read())
                // Se añade el nombre a la variable local
                name =  IDC[ 0 ].ToString();
            this.conexion.Close();
            // Se regresa el nombre encontrado apartir del id
            return name;
        }
        // Metodo para limpiar todos los campos de entrada
        public void limpiar( ) {
            this.bunifuTextBox1.Clear();
            // Se cargan los comboBox
            cargarComboBox();
        }
        // En caso de cambiar la fecha el segundo datepicker tendrá el valor de inicio + 7 dias
        private void bunifuDatePicker1_ValueChanged( object sender, EventArgs e ) {
            this.bunifuDatePicker2.Value = this.bunifuDatePicker1.Value.Date.AddDays(7);
        }
    }
}
