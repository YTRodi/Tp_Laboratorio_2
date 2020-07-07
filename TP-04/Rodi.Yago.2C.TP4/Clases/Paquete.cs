using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesHechas
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Delegados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado público que contiene los estados que podrá
        /// tener el paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private string trackingID;
        private EEstado estado;
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad de lectura y escritura para la dirección 
        /// de entrega del paquete.
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el número de tracking 
        /// del paquete.
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el estado
        /// del paquete.
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa los campos:
        ///  DireccionEntrega
        ///  TrackingID
        ///  
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region Implementación interfaz genérica
        /// <summary>
        /// Implementación del método MostrarDatos de la interface genérica IMostrar.
        /// </summary>
        /// <param name="elemento">paquete a mostrar sus datos</param>
        /// <returns>Los datos del paquete.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).DireccionEntrega, ((Paquete)elemento).TrackingID);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que se encarga de:
        /// 
        /// Primero: Verificar que el Turno no sea null.
        /// 
        /// Segundo: Ejecutar un bucle while hasta que el estado del paquete no sea "Entregado".
        /// 
        /// Tercero: Mientras tanto, adentro del bucle va dormir la ejecución del programa (Simulando el cambio de estado del paquete).
        ///         Cambiará el estado del paquete.
        ///         
        /// Cuarto: Si el estado del paquete es igual a "Entregado", lo inserto en la tabla Paquetes.
        /// 
        /// </summary>
        /// 

        public void MockCicloDeVida()
        {
            if (!(this is null))
            {
                this.InformaEstado(this, null);

                while (this.Estado != EEstado.Entregado)
                {
                    Thread.Sleep(4000);

                    this.Estado++;

                    this.InformaEstado(this, null);
                }

                if (this.Estado == EEstado.Entregado)
                {
                    PaqueteDAO.Insertar(this);
                }
            }
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// Sobrecarga del operador ==, 
        /// que verifica si dos paquetes son iguales
        /// por el TrackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True: si son iguales (TrackingID iguales)</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Sobrecarga del operador !=.
        /// que verifica si dos paquetes son distintos
        /// por el TrackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True: si son distintos (TrackingID distintos)</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Override
        /// <summary>
        /// Sobreescritura del método ToString().
        /// </summary>
        /// <returns>Los datos del paquete.</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

    }
}
