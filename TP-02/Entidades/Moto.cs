using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Constructores
        /// <summary>
        /// Único constructor.
        /// Utiliza los campos de la clase base.
        /// </summary>
        /// <param name="marca">Marca de la moto a inicializar</param>
        /// <param name="chasis">Chasis de la moto a inicializar</param>
        /// <param name="color">Color de la moto a inicializar</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Implementación de la propiedad abstracta Tamanio de la clase Vehiculo.
        /// Las motos son chicas.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Chico;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Publica los datos propios de la moto
        /// y los datos del vehiculo.
        /// </summary>
        /// <returns>Los datos de la moto.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--MOTO--");
            sb.AppendLine("Tipo de Vehiculo: " + this.GetType());
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
