using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        #region Enumerados
        /// <summary>
        /// Enumerado que contiene los Tipos de Vehiculos.
        /// </summary>
        public enum ETipo
        {
            Moto, 
            Automovil, 
            Camioneta, 
            Todos
        }
        #endregion

        #region Atributos
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privaro que inicializa la lista de vehiculos.
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor por defecto que establece el espacio disponible
        /// que tendrá el estacionamiento.
        /// Además invoca al constructor privado.
        /// </summary>
        /// <param name="espacioDisponible">Espacio que tendra el estacionamiento</param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Sobre carga del método ToString.
        /// Que llama al método mostrar de la misma clase.
        /// Muestro el estacionamiento y TODOS los vehículos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
            //return Estacionamiento.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido.
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>El méodo Mostrar dependiendo su tipo.</returns>
        public string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("   Tenemos {0} lugares ocupados de un total de {1} disponibles\n", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("*************************************************************");
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if(v is Camioneta)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case ETipo.Moto:
                        if(v is Moto)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case ETipo.Automovil:
                        if(v is Automovil)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;

                    case ETipo.Todos:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista.
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            bool retorno = false;

            if (c.vehiculos.Count < c.espacioDisponible)
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                    {
                        retorno = true;
                        break;
                    }
                }
                if (!retorno)
                {
                    c.vehiculos.Add(p);
                }

            }

            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            for (int i = 0; i < c.vehiculos.Count; i++)
            {
                if(c.vehiculos[i] == p)
                {
                    c.vehiculos.RemoveAt(i);
                }
            }
            return c;
        }
        #endregion
    }
}
