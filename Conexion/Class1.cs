using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Conexion {
    public class BaseDatos {
        readonly SqlConnection conexion;
        public BaseDatos( string servidor, string nombreBD ) {
            this.conexion = new SqlConnection($@"server={servidor}; Initial Catalog={nombreBD}; integrated security=true");
        }
        public bool Alta( string tabla, string[] values ) {
            bool correcto = true;
            string insert = string.Join(",", values);
            // Se crea el comando para dar de Altas a la BD
            SqlCommand altas = new SqlCommand($"INSERT INTO { tabla } VALUES({ insert })", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            try {
                // Se cargan los datos a la BD
                altas.ExecuteNonQuery();
            }
            catch (SqlException) {
                correcto = false;
            }
            finally {
                // Se cierra la conexion
                this.conexion.Close();
            }
            return correcto;

        }
        public bool Alta( string tabla, string[] values , DateTime fechaParam) {
            bool correcto = true;
            string insert = string.Join(",", values);
            // Se crea el comando para dar de Altas a la BD
            SqlCommand altas = new SqlCommand($"INSERT INTO { tabla } VALUES({ insert })", this.conexion);
            altas.Parameters.AddWithValue("@fecha", fechaParam);
            // Se abre la conexion
            this.conexion.Open();
            try {
                // Se cargan los datos a la BD
                altas.ExecuteNonQuery();
            }
            catch (SqlException) {
                correcto = false;
            }
            finally {
                // Se cierra la conexion
                this.conexion.Close();
            }
            return correcto;
        }
        public void Baja( string tabla, string condicion ) {
            // Se crea el comando para eliminar un registro con solo saber el id(campo principal, llave primaria)
            SqlCommand bajas = new SqlCommand($"DELETE FROM {tabla} WHERE {condicion}", this.conexion);
            // Se liberan los recursos
            bajas.Dispose();
            // Se abre la conexion
            this.conexion.Open();
            // Se ejecuta el comando de eliminar
            bajas.ExecuteNonQuery();
            // Se cierra la conexion
            this.conexion.Close();
        }
        // Se actualiza un registro con los datos recopilados
        public bool Actualizar( string tabla, string[] values, string condicion ) {
            bool correcto = true;
            string insert = string.Join(",", values);
            // Se crea el comando para actualizar los datos
            SqlCommand actualizar = new SqlCommand($"UPDATE {tabla} SET {insert} WHERE {condicion}'", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // En caso de haber algun problema al ejecutar el editar se notifica al usuario
            try {
                actualizar.ExecuteNonQuery();
            }
            catch (SqlException) {
                correcto = false;
            }
            finally {
                // Se cierra la conexion
                this.conexion.Close();
            }
            return correcto;
        }
        public bool Login( string tabla, string condiciones ) {
            // Comando de consulta
            SqlCommand consulta = new SqlCommand($"SELECT * FROM {tabla} WHERE {condiciones}", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan los datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            bool columnas = data.HasRows;
            // Se cierra la conexion
            this.conexion.Close();
            return columnas;
        }
        public List<string[]> Buscar( string tabla, string condicion, out int nid ) {
            nid = 0;
            List<string[]> datosSalida = new List<string[]>();
            // Comando de consulta
            SqlCommand consulta = new SqlCommand($"SELECT * FROM {tabla} WHERE {condicion}", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan los datos en un SqlDataReader
            SqlDataReader data = consulta.ExecuteReader();
            // Mientras haya datos para leer se registrarán en el dataGrid
            while (data.Read()) {
                datosSalida.Add(new string[]
                    { data[ 0 ].ToString(), data[ 1 ].ToString(), data[ 2 ].ToString(), data[ 3 ].ToString(), data[ 4 ].ToString()}
                    );
                nid = int.Parse(data[ 0 ].ToString().Split('|')[ 1 ]) + 1;
            }
            // Se cierra la conexion
            this.conexion.Close();
            return datosSalida;
        }
    }
    public class Seguridad {
        // Encripta una cadena
        public static string Encriptar( string _cadenaAencriptar )
            => Convert.ToBase64String(Encoding.Unicode.GetBytes(_cadenaAencriptar));

        // Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string Desencriptar( string _cadenaAdesencriptar )
            => Encoding.Unicode.GetString(Convert.FromBase64String(_cadenaAdesencriptar));
    }
}
