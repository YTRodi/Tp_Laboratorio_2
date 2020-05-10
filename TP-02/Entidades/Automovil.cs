using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerado que contiene los Tipos de automoviles.
        /// </summary>
        public enum ETipo
        {
            Monovolumen,
            Sedan
        }
        #endregion

        #region Atributos
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de 3 parámetros.
        /// Utiliza los campos de la clase base.
        /// Setea por defecto el tipo en Monovolumen.
        /// </summary>
        /// <param name="marca">Marca del automovil a inicializar</param>
        /// <param name="chasis">Chasis del automovil a inicializar</param>
        /// <param name="color">Color del automovil a inicializar</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Constructor de 4 parámetros.
        /// 1er Sobrecarga.
        /// </summary>
        /// <param name="marca">Marca del automovil a inicializar</param>
        /// <param name="chasis">Chasis del automovil a inicializar</param>
        /// <param name="color">Color del automovil a inicializar</param>
        /// <param name="tipo">Tipo del automovil a inicializar</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Implementación de la propiedad abstracta Tamanio de la clase Vehiculo.
        /// Los automoviles son medianos.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return Vehiculo.ETamanio.Mediano;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Publica los datos propios del automovil
        /// y los datos del vehiculo.
        /// </summary>
        /// <returns>Los datos del automovil.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--AUTOMOVIL--");
            sb.AppendLine("Tipo de Vehiculo: " + this.GetType());
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
