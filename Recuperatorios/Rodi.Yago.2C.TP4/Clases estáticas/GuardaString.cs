using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesHechas;

namespace EntidadesHechas
{
    public static class GuardaString
    {
        #region Path de salida
        public static string pathSalida = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        #endregion

        #region Métodos
        /// <summary>
        /// Método que extiende la clase string y escribe en un archivo de texto los datos a guardar.
        /// (Va a guardar los errores que vayan sucediendo en el programa (log.txt)).
        /// 
        /// Verificando que:
        ///  Si el archivo existe -> Lo sobrescribe.
        ///  Si no existe el archivo -> Lo crea.
        /// 
        /// Si pudo guardar, el archivo se encontrará en el escritorio.
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>Si pudo guardar o no.</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter sw = null;
            bool pudoGuardar = false;

            if (File.Exists(pathSalida + archivo))
            {
                if (Path.GetExtension(archivo) is ".txt")
                {
                    using (sw = new StreamWriter(pathSalida + archivo, true, Encoding.UTF8))
                    {
                        sw.WriteLine(texto);
                        pudoGuardar = true;
                    }
                }
            }
            else
            {
                using (sw = new StreamWriter(pathSalida + archivo))
                {
                    sw.WriteLine(texto);
                    pudoGuardar = true;
                }
            }
            return pudoGuardar;
        }
        #endregion

    }
}
