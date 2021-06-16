using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ConexionMYSQL {
    public class BaseDatos {
        readonly MySqlConnection conexion;
        public BaseDatos( string servidor, string usuario, string password, string nombreBD , string puerto = "3306" ) {
            this.conexion = new MySqlConnection($@"server={servidor}; port={puerto}; user id={usuario}; password={password}; database={nombreBD};");           
        }
        public bool Alta( string tabla, string[] values ) {
            bool correcto = true;
            string insert = string.Join(",", values);
            // Se crea el comando para dar de Altas a la BD
            MySqlCommand altas = new MySqlCommand($"INSERT INTO { tabla } VALUES({ insert })", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            try {
                // Se cargan los datos a la BD
                altas.ExecuteNonQuery();
            }
            catch (MySqlException) {
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
            MySqlCommand bajas = new MySqlCommand($"DELETE FROM {tabla} WHERE {condicion}", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se ejecuta el comando de eliminar
            bajas.ExecuteNonQuery();
            // Se cierra la conexion
            this.conexion.Close();
        }
        /// <summary>
        /// Se actualiza un registro con los datos recopilados
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="values"></param>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public bool Actualizar( string tabla, string[] values, string condicion ) {
            bool correcto = true;
            string insert = string.Join(",", values);
            // Se crea el comando para actualizar los datos
            MySqlCommand actualizar = new MySqlCommand($"UPDATE {tabla} SET {insert} WHERE {condicion}", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // En caso de haber algun problema al ejecutar el editar se notifica al usuario
            try {
                actualizar.ExecuteNonQuery();
            }
            catch (MySqlException) {
                correcto = false;
            }
            finally {
                // Se cierra la conexion
                this.conexion.Close();
            }
            return correcto;
        }
        public List<List<string>> Buscar( string tabla, string condicion = null) {
            List<List<string>> datosSalida = new List<List<string>>();
            // Comando de consulta
            MySqlCommand consulta = condicion == null ? new MySqlCommand($"SELECT * FROM {tabla}", this.conexion) : new MySqlCommand($"SELECT * FROM {tabla} WHERE {condicion}", this.conexion);
            // Se abre la conexion
            this.conexion.Open();
            // Se guardan los datos en un MySqlDataReader
            MySqlDataReader data = consulta.ExecuteReader();
            // Mientras haya datos para leer se registrarán en el dataGrid
            while (data.Read()) {
                List<string> dataS = new List<string>();
                for (int i = 0; i < data.FieldCount; i++)
                    dataS.Add(data[ i ].ToString());
                datosSalida.Add(dataS);
            }
            // Se cierra la conexion
            this.conexion.Close();
            return datosSalida;
        }
    }
}