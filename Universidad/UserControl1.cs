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
    public partial class UserControl1 : UserControl {
        SqlConnection conexion = new SqlConnection(@"server=JONATHAN\JONATHANSERVER; Initial Catalog=uni; integrated security=true");
        public UserControl1( ) {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click( object sender, EventArgs e ) {
            // se crea el comando para dar de altas al sistema

            SqlCommand altas = new SqlCommand("INSERT INTO profesores VALUES(@idProf,@nombreProf,@direccionProf,@telefonoProf,@emailProf,@departamentoProf,@dedicacionProf,@centroProf)", this.conexion);
            //se pasan los valores de los text box a las variables temporales
            altas.Parameters.AddWithValue("idProf", this.bunifuTextBox1.Text);
            altas.Parameters.AddWithValue("nombreProf", this.bunifuTextBox2.Text);
            altas.Parameters.AddWithValue("direccionProf", this.bunifuTextBox3.Text);
            altas.Parameters.AddWithValue("telefonoProf", this.bunifuTextBox4.Text);
            altas.Parameters.AddWithValue("emailProf", this.bunifuTextBox5.Text);
            altas.Parameters.AddWithValue("departamentoProf", this.bunifuTextBox6.Text);
            altas.Parameters.AddWithValue("dedicacionProf", this.bunifuTextBox7.Text);
            altas.Parameters.AddWithValue("centroProf", this.bunifuTextBox8.Text);

            this.conexion.Open();
            altas.ExecuteNonQuery();
            this.conexion.Close();
        }
    }
}
