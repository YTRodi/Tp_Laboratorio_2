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
        public Universitario()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{base.ToString()}\nLEGAJO NÚMERO: {this.legajo}\n\n");
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operaciones
        public static bool operator ==(Universitario uni1, Universitario uni2)
        {
            return uni1.Equals(uni2);
        }

        public static bool operator !=(Universitario uni1, Universitario uni2)
        {
            return !(uni1 == uni2);
        }
        #endregion

        #region Override
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
