using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmetica {
    /// <summary>
    /// Representa todas las operaciones basicas que puedes hacer con 2 numeros
    /// </summary>
    public class OperacionesBasicas {
        /// <summary>
        /// Obtener o establecer el primer dato de entrada
        /// </summary>
        public double N1 {
            get; set;
        }
        /// <summary>
        /// Obtener o establecer el segundo dato de entrada
        /// </summary>
        public double N2 {
            get; set;
        }
        /// <summary>
        /// Obtener el resultado de las operacioes
        /// </summary>
        public double Resultado {
            get;private set;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Operaciones Basicas
        /// </summary>
        /// <param name="n1">Primer dato de entrada</param>
        /// <param name="n2">Segundo dato de entrada</param>
        public OperacionesBasicas(double n1, double n2) {
            this.N1 = n1;
            this.N2 = n2;
        }
        /// <summary>
        /// Representa la suma de 2 numeros
        /// </summary>
        /// <returns>Suma de N1 y N2</returns>
        public double Suma( ) {
            this.N1 += this.N2;
            this.N2 = 0.00;
            return this.Resultado = this.N1;
        }
        /// <summary>
        /// Representa la resta de 2 numeros
        /// </summary>
        /// <returns>Resta de N1 y N2</returns>
        public double Resta( ) {
            this.N1 -= this.N2;
            this.N2 = 0.00;
            return this.Resultado = this.N1;
        }
        /// <summary>
        /// Representa la multiplicacion de 2 numeros
        /// </summary>
        /// <returns>Multiplicacion de N1 y N2</returns>
        public double Multiplicacion( ) {
            this.N1 *= this.N2;
            this.N2 = 0.00;
            return this.Resultado = this.N1;
        }
        /// <summary>
        /// Representa la division de 2 numeros
        /// </summary>
        /// <returns>Division de N1 y N2</returns>
        public double Division( ) {
            this.N1 /= this.N2;
            this.N2 = 0.00;
            return this.Resultado = this.N1;
        }
    }
}
