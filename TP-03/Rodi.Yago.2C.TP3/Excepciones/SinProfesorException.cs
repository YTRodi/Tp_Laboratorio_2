using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor que llama a la base e inicializa el mensaje.
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {

        }
        #endregion
    }
}
