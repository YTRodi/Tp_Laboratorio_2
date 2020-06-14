using Archivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> listaAlumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Properties
        /// <summary>
		/// Propiedad de lectura y escritura,
		/// que retorna la lista de alumnos.
		/// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.listaAlumnos;
            }
            set
            {
                this.listaAlumnos = value;
            }
        }

        /// <summary>
		/// Propiedad de lectura y escritura,
		/// que retorna la clase.
		/// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
		/// Propiedad de lectura y escritura,
		/// que retorna la lista de instructores.
		/// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa la lista
        /// de alumnos.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
		/// Constructor que reutiliza el constructor anterior e inicializa
        /// los atributos:
        /// - Clase.
        /// - Instructor.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método estático que guardará en un archivo de texto
        /// los datos de la Jornada.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Si pudo guardar o no.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTxt = new Texto();
            string ruta = Directory.GetCurrentDirectory() + @"\Jornada.txt";
            bool pudoGuardar = false;

            if (archivoTxt.Guardar(ruta, jornada.ToString()))
                pudoGuardar = true;

            return pudoGuardar;
        }

        /// <summary>
        /// Método estático que leera el archivo de texto de Jornada.
        /// </summary>
        /// <returns>Los datos de la Jornada en formato de texto.</returns>
        public static string Leer()
        {
            Texto archivoTxt = new Texto();
            string ruta = Directory.GetCurrentDirectory() + @"\Jornada.txt";
            archivoTxt.Leer(ruta, out string jornadaDatos);
            return jornadaDatos;
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// Sobrecarga del operador "==" que compara si el Alumno
        /// participa en esa clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool participaEnLaClase = false;
            foreach (Alumno item in j.listaAlumnos)
            {
                if (item == a)
                    participaEnLaClase = true;
            }
            return participaEnLaClase;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que compara si el Alumno
        /// no participa en esa clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador "+" que agrega a un Alumno a la lista
        /// solamente si no se encuentra cargado.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.listaAlumnos.Add(a);
            return j;
        }
        #endregion

        #region Override
        /// <summary>
		/// Sobrescritura del método ToString() que expone
		/// los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"CLASE DE {this.Clase.ToString()} POR {this.Instructor.ToString()}");
            sb.AppendFormat("\nALUMNOS:\n");
            foreach (Alumno item in this.listaAlumnos)
            {
                sb.AppendFormat(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

    }
}
