using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor por defecto que reutiliza otro constructor e inicializa
        /// el mensaje.
        /// </summary>
        public DniInvalidoException() : this("No se pudo cargar el DNI")
        {

        }

        /// <summary>
        /// Sobrecarga de constructor que llama a al base e inicializa el mensaje y 
        /// la innerException.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : base(e.Message, e)
        {

        }

        /// <summary>
        /// Sobrecarga de constructor que llama a al base e inicializa el mensaje.
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {

        }

        /// <summary>
        /// Sobrecarga de constructor que llama a al base e inicializa el mensaje y
        /// la innerException pasadas por parámetro.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
        #endregion
    }
}
