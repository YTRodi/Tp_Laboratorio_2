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
            this._randomClases();
        }
        #endregion

        #region Métodos
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.ToString());
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            return sb.ToString();
        }
        private void _randomClases()
        {
            //Hasta 4, no sé por qué, sino elije aleatoriamente entre programación, laboratorio o legislación y no llega a SPD.
            int auxRnd = random.Next(0, 4);
            this.clasesDelDia.Enqueue((Universidad.EClases)auxRnd);
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
            sb.AppendFormat("CLASES DEL DÍA:\n");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendFormat($"{clase}\n");
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
