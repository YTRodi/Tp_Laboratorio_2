using EntidadesHechas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesHechas
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Paquete> listaPaquetes;
        private List<Thread> mockPaquetes;
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad de lectura y escritura para la lista 
        /// de paquetes que se encuentra en el correo.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.listaPaquetes; }
            set { this.listaPaquetes = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto sin parámetros, que inicializa las listas:
        ///  listaPaquetes
        ///  mockPaquetes
        ///  
        /// </summary>
        public Correo()
        {
            this.listaPaquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Implementación interfaz genérica
        /// <summary>
        /// Implementación del método MostrarDatos de la interface genérica IMostrar.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Los datos de cada paquete que se encuentre en la lista de paquetes.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in this.Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n   ", p.TrackingID , p.DireccionEntrega, p.Estado.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que finaliza los hilos que siguen en ejecución de la lista mockPaquetes.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                    hilo.Abort();
            }
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// 
        /// Sobrecarga del operador +
        /// que se encargar de:
        ///  Verificar si el paquete se encuentra en la lista.
        ///  Si no está en la lista, lo agrega.
        ///  Y por último se crea un nuevo hilo para este paquete, se lo agrega a mockPaquetes
        ///  y se inicia el hilo con el método MockCicloDeVida de la clase paquete.
        ///  
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                    throw new TrackingIDException($"El paquete '{item.ToString()}' ya se encuentra en la lista");
            }

            c.Paquetes.Add(p);

            Thread hiloMCDV = new Thread(new ThreadStart(p.MockCicloDeVida));

            c.mockPaquetes.Add(hiloMCDV);

            hiloMCDV.Start();

            return c;
        }
        #endregion
    }
}
