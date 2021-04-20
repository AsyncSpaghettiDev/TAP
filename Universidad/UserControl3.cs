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
        SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=uni; integrated security=true");
        public UserControl3( ) {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            // se crea el comando para dar de altas al sistema

            SqlCommand altas = new SqlCommand("INSERT INTO personal VALUES(@idPersonal,@nombrePersonal,@direccionPersonal,@telefonoPersonal,@emailPersonal,@unidadPersonal,@categoriaPersonal,@idProf)", this.conexion);
            //se pasan los valores de los text box a las variables temporales
            altas.Parameters.AddWithValue("idPersonal", this.bunifuTextBox1.Text);
            altas.Parameters.AddWithValue("nombrePersonal", this.bunifuTextBox2.Text);
            altas.Parameters.AddWithValue("direccionPersonal", this.bunifuTextBox3.Text);
            altas.Parameters.AddWithValue("telefonoPersonal", this.bunifuTextBox4.Text);
            altas.Parameters.AddWithValue("emailPersonal", this.bunifuTextBox5.Text);
            altas.Parameters.AddWithValue("unidadPersonal", this.bunifuTextBox6.Text);
            altas.Parameters.AddWithValue("categoriaPersonal", this.bunifuTextBox7.Text);

            this.conexion.Open();
            altas.ExecuteNonQuery();
            this.conexion.Close();
        }
    }
}
