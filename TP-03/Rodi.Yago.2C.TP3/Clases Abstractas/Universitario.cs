using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universitario.
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constructor que llama la base e inicializa el atributo:
        /// - legajo.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        /// <summary>
        /// Propiedad pura y exclusivamente para la serialización XML
        /// </summary>
        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }
        #region Métodos
        /// <summary>
        /// Método que expone los datos del universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}\nLEGAJO NÚMERO: {this.legajo}\n\n");
            return sb.ToString();
        }

        /// <summary>
        /// Método abstracto que tendrá implementación en las 
        /// clases heredadas.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operaciones
        /// <summary>
        /// Sobrecarga del operador "==" que compara dos universitarios.
        /// </summary>
        /// <param name="uni1"></param>
        /// <param name="uni2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario uni1, Universitario uni2)
        {
            return uni1.Equals(uni2);
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que compara si un universitario es 
        /// distinto de otro.
        /// </summary>
        /// <param name="uni1"></param>
        /// <param name="uni2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario uni1, Universitario uni2)
        {
            return !(uni1 == uni2);
        }
        #endregion

        #region Override
        /// <summary>
        /// Sobrecarga del método Equals() que verifica
        /// Si el obj pasado por parámetro es:
        /// - Universitario, tiene el mismo legajo y el mismo dni.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool sonIguales = false;
            if (obj is Universitario)
            {
                if (((Universitario)obj).legajo == this.legajo || ((Universitario)obj).DNI == this.DNI)
                    sonIguales = true;
            }
            return sonIguales;
        }
        #endregion
    }
}
