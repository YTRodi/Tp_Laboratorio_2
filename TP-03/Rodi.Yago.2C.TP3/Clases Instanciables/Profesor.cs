using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;//FIFO
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático que inicializa el atributo.
        /// - random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de la clase Profesor
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
		/// Constructor que llama la base e inicializa los atributos:
        /// - clasesDelDia
        /// - Y se asignan dos clases al azar para el Profesor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que expone los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Método que asigna una clase al azar a la cola.
        /// </summary>
        private void _randomClases()
        {
            /*Hasta 4, no sé por qué, sino elije aleatoriamente entre programación, 
             * laboratorio o legislación y no llega a SPD.*/
            int auxRnd = random.Next(0, 4);
            this.clasesDelDia.Enqueue((Universidad.EClases)auxRnd);
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// Sobrecarga del operador "==" que compara si un profesor
        /// da esa clase.
        /// </summary>
        /// <param name="profe"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor profe, Universidad.EClases clase)
        {
            bool daLaClase = false;
            foreach (Universidad.EClases item in profe.clasesDelDia)
            {
                if (item == clase)
                    daLaClase = true;
            }
            return daLaClase;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que compara si un profesor
        /// no da esa clase
        /// </summary>
        /// <param name="profe"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor profe, Universidad.EClases clase)
        {
            return !(profe == clase);
        }
        #endregion

        #region Override
        /// <summary>
		/// Implementación del método abstracto de la clase Universitario.
        /// </summary>
        /// <returns>Las clases del día y el nombre del profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASES DEL DÍA:\n");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendFormat($"{clase}\n");
            }
            return sb.ToString();
        }

        /// <summary>
		/// Sobrescritura del método ToString() que llama al
		/// método MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
