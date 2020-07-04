using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesHechas
{
    public interface IMostrar<T>
    {
        #region Métodos
        /// <summary>
        /// Método sin implementación que tendrá como propósito
        /// mostrar datos de elemento del tipo genérico.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);
        #endregion
    }
}
