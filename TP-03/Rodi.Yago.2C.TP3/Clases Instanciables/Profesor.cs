using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
//Simplifico el enumerado.
//using Eclase = Clases_Instanciables.Universidad.EClases;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
	{
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;//FIFO
        private static Random random;
        #endregion

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            //Genero dos clases aleatorias???
            //this._randomClases();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            //this._randomClases();
        }
        #endregion

        #region Métodos
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        private void _randomClases()
        {
            Array array = Enum.GetValues(typeof(Universidad.EClases));
            this.clasesDelDia.Enqueue((Universidad.EClases)array.GetValue(random.Next(array.Length)));
        }
        #endregion

        #region Operaciones
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

        public static bool operator !=(Profesor profe, Universidad.EClases clase)
        {
            return !(profe == clase);
        }
        #endregion

        #region Override
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del día:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendFormat($"{clase} ");
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
