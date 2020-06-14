using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Implementación métodos interface (IArchivo)

        /// <summary>
        /// Implementación del método de la interface IArchivos
        /// que guarda datos en formato de texto.
        /// Caso contrario, lanzará la excepción: ArchivosException().
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool pudoGuardar = false;

            try
            {
                if (!(archivo is null))
                {
                    using (StreamWriter sw = new StreamWriter(archivo))
                    {
                        sw.WriteLine(datos);
                        pudoGuardar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return pudoGuardar;
        }

        /// <summary>
        /// Implementación del método de la interface IArchivos
        /// que lee datos en formato de texto.
        /// Caso contrario, lanzará la excepción: ArchivosException().
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool pudoLeer = false;
            datos = string.Empty;

            try
            {
                if (!(archivo is null))
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        datos = sr.ReadToEnd();
                        pudoLeer = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return pudoLeer;
        }
        #endregion
    }
}
