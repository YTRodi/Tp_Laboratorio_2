using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesHechas
{
    public class TrackingIDException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor que llama a la base y inicializa el mensaje.
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIDException(string mensaje) : base(mensaje)
        {
        }


        /// <summary>
        /// Constructor que llama a la base, inicializa el mensaje y la innerException.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIDException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
        #endregion
    }
}
