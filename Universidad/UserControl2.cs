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
    public partial class UserControl2 : UserControl {
        SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=uni; integrated security=true");
        public UserControl2( ) {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            // se crea el comando para dar de altas al sistema

            SqlCommand altas = new SqlCommand("INSERT INTO alumnos VALUES(@expedienteAlumno,@nombreAlumno,@direccionAlumno,@telefonoAlumno,@emailAlumno,@centroAlumno,@titulacionAlumno,@idProf)", this.conexion);
            //se pasan los valores de los text box a las variables temporales
            altas.Parameters.AddWithValue("expedienteAlumno", this.bunifuTextBox1.Text);
            altas.Parameters.AddWithValue("nombreAlumno", this.bunifuTextBox2.Text);
            altas.Parameters.AddWithValue("direccionAlumno", this.bunifuTextBox3.Text);
            altas.Parameters.AddWithValue("telefonoAlumno", this.bunifuTextBox4.Text);
            altas.Parameters.AddWithValue("emailAlumno", this.bunifuTextBox5.Text);
            altas.Parameters.AddWithValue("centroAlumno", this.bunifuTextBox6.Text);
            altas.Parameters.AddWithValue("titulacionAlumno", this.bunifuTextBox7.Text);
            altas.Parameters.AddWithValue("idProf", this.bunifuTextBox8.Text);

            this.conexion.Open();
            altas.ExecuteNonQuery();
            this.conexion.Close();
        }
    }
}
