using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor que llama a la base e inicializa la innerException.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            :base("El archivo no se guardó/leyó.",innerException)
        {

        }
        #endregion
    }
}
