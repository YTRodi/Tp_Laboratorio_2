using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerado que contiene Marcas de los vehiculos.
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        /// <summary>
        /// Enumerado que contiene los Tamaños de los vehiculos.
        /// Camioneta = Grande.
        /// Automovil = Mediano.
        /// Moto = Chico.
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Atributos
        private EMarca marca;
        private ConsoleColor color;
        private string chasis;
        #endregion

        #region Constuctores
        /// <summary>
        /// Único constructor que inicializa todos los atributos.
        /// </summary>
        /// <param name="chasis">Chasis del Vehiculo a inicializar</param>
        /// <param name="marca">Marca del Vehiculo a inicializar</param>
        /// <param name="color">Color del Vehiculo a inicializar</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad protegida y abstracta.
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Publica todos los datos del Vehiculo utilizando una conversión explicita.
        /// </summary>
        /// <returns>Los datos del vehiculo.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Conversiones
        /// <summary>
        /// Conversión explícita de string.
        /// </summary>
        /// <param name="p">Vehiculo a retornar sus datos.</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: " + p.chasis);
            sb.AppendLine("MARCA : " + p.marca.ToString());
            sb.AppendLine("COLOR : " + p.color.ToString());
            sb.Append("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// Operacion == entre dos vehiculos.
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vehiculo 1 a comparar</param>
        /// <param name="v2">Vehiculo 2 a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// /// Operacion != entre dos vehiculos.
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vehiculo 1 a comparar</param>
        /// <param name="v2">Vehiculo 2 a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

    }
}
