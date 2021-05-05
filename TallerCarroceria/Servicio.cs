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
        readonly SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=TallerCarroceria; integrated security=true");
        public Servicio( ) {
            InitializeComponent();
            crearGrid();
        }
        private void crearGrid( ) {
            this.bunifuDataGridView1.ColumnCount = 7;
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
                string[] row = new string[] { data[ 0 ].ToString(), 
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
    }
}
