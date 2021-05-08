using System.Windows.Forms;
using System.Data.SqlClient;

namespace TallerCarroceria {
    public partial class ClientesVista : UserControl {
        readonly SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=TallerCarroceria; integrated security=true");
        public ClientesVista( ) {
            InitializeComponent();
            crearGrid();
        }
        private void crearGrid( ) {
            this.bunifuDataGridView1.ColumnCount = 4;
            this.bunifuDataGridView1.Columns[ 0 ].Name = "Matricula";
            this.bunifuDataGridView1.Columns[ 1 ].Name = "Marca";
            this.bunifuDataGridView1.Columns[ 2 ].Name = "Modelo";
            this.bunifuDataGridView1.Columns[ 3 ].Name = "Año";
        }
        // Se cargan los datos al dataGrid
        private void cargarGrid() {
            // Comando de consulta
            SqlCommand consulta = new SqlCommand("SELECT * FROM Vehiculos WHERE idCliente=@ID", this.conexion);
            consulta.Parameters.AddWithValue("ID", int.Parse(this.bunifuTextBox1.Text));
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
        // Evento que se ejecuta cuando se da click en el boton buscar
        private void bunifuImageButton1_Click( object sender, System.EventArgs e ) {
            // En caso que se encuentre un usuario con el id dado se cargan sus vehiculos en el datagrid
            if (buscar()) 
                cargarGrid();
            // Se limpia el campo donde ingresas el id
            this.bunifuTextBox1.Clear();
        }
        // Se buscan datos en la BD
        private bool buscar( ) {
            bool confirm = false;
            // Se carga el id en el parametro usado en el comando SQL
            if (string.IsNullOrEmpty(this.bunifuTextBox1.Text))
                MessageBox.Show("¡Ingresa un ID!");
            else {
                // Se crea el comando para hacer una consulta solo con el id
                SqlCommand consulta = new SqlCommand("SELECT * FROM Clientes WHERE idCliente=@ID", this.conexion);
                consulta.Parameters.AddWithValue("ID", int.Parse(this.bunifuTextBox1.Text));
                // Se abre la conexion
                this.conexion.Open();
                // Se guardan datos en un SqlDataReader
                SqlDataReader data = consulta.ExecuteReader();
                // Si hay datos que leer se leen
                if (data.Read()) {
                    // Se cargan los datos conseguidos en cada textBox
                    this.bunifuTextBox2.Text = data[ 2 ].ToString();
                    this.bunifuTextBox3.Text = data[ 1 ].ToString();
                    this.bunifuTextBox4.Text = data[ 3 ].ToString();
                    MessageBox.Show("Cliente encontrado");
                    confirm = true;
                }
                // Se cierra la conexion
                this.conexion.Close();
            }
            return confirm;
        }
    }
}
