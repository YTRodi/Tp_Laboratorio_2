using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        #region Constructores
        /// <summary>
        /// Único constructor.
        /// Utiliza los campos de la clase base.
        /// </summary>
        /// <param name="marca">Marca de la camioneta a inicializar</param>
        /// <param name="chasis">Chasis de la camioneta a inicializar</param>
        /// <param name="color">Color de la camioneta a inicializar</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Implementación de la propiedad abstracta Tamanio de la clase Vehiculo.
        /// Las camionetas son grandes.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Grande;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Publica los datos propios de la camioneta
        /// y los datos del vehiculo.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--CAMIONETA--");
            sb.AppendLine("Tipo de Vehiculo: " + this.GetType());
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
