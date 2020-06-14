using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor por defecto de NacionalidadInvalidaException.
        /// </summary>
        public NacionalidadInvalidaException()
        {

        }

        /// <summary>
        /// Sobrecarga de constructor que llama a al base e inicializa el mensaje.
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
        #endregion
    }
}
