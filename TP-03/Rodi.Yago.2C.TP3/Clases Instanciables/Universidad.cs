using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Enumerados
        /// <summary>
		/// Enumerado que contiene los tres tipos de clases.
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> listaAlumnos;
        private List<Jornada> listaJornadas;
        private List<Profesor> listaProfesores;
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
        /// que retorna la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.listaJornadas;
            }
            set
            {
                this.listaJornadas = value;
            }
        }


        /// <summary>
        /// Propiedad de lectura y escritura,
        /// que permite indexar la lista de jornadas.
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.listaJornadas[i];
            }
            set
            {
                this.listaJornadas[i] = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura,
        /// que retorna la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.listaProfesores;
            }
            set
            {
                this.listaProfesores = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa las listas de alumnos, jornadas y profesores.
        /// </summary>
        public Universidad()
        {
            this.listaAlumnos = new List<Alumno>();
            this.listaJornadas = new List<Jornada>();
            this.listaProfesores = new List<Profesor>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que expone los datos de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("JORNADA:\n");
            foreach (Jornada item in uni.Jornada)
            {
                sb.AppendFormat(item.ToString());
                sb.AppendFormat("<-------------------------------------------------->\r\n\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método estático que guardará en un archivo XML
        /// los datos de la Universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivoXmlUni = new Xml<Universidad>();
            string ruta = Directory.GetCurrentDirectory() + @"\Universidad.xml";
            bool pudoGuardar = false;

            if (archivoXmlUni.Guardar(ruta, uni))
                pudoGuardar = true;

            return pudoGuardar;
        }

        /// <summary>
        /// Método estático que leera el archivo XML de Universidad.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> archivoXmlUni = new Xml<Universidad>();
            string ruta = Directory.GetCurrentDirectory() + @"\Universidad.xml";

            archivoXmlUni.Leer(ruta, out Universidad uni);

            return uni;
        }
        #endregion

        #region Operaciones
        /// <summary>
        /// Sobrecarga del operador "==" que compara si el Alumno
        /// está incripto en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool inscripto = false;
            if (!(g is null))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == a)
                    {
                        inscripto = true;
                        break;
                    }
                }
            }

            return inscripto;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que compara si el Alumno
        /// no está incripto en la Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador "==" que compara si el Profesor
        /// está dando clases en esa Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool daClases = false;
            if (!(g is null))
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == i)
                    {
                        daClases = true;
                        break;
                    }
                }
            }

            return daClases;
        }

        /// <summary>
        /// Sobrecarga del operador "==" que compara si el Profesor
        /// no está dando clases en esa Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador "==" que retorna el primer
        /// profesor capaz de dar esa clase.
        /// Caso contrario lanzará la excepción: SinProfesorException().
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor primerProfeCapazDeDarEsaClase = null;
            if (!(u is null))
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item == clase)
                    {
                        primerProfeCapazDeDarEsaClase = item;
                        //el primer profe que SI pueda dar la clase lo retorno.
                        break;
                    }
                }
                if (primerProfeCapazDeDarEsaClase is null)
                    throw new SinProfesorException();
            }

            return primerProfeCapazDeDarEsaClase;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" que retorna el primer
        /// profesor que no puede dar esa clase.
        /// Caso contrario lanzará la excepción: SinProfesorException().
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor primerProfeQueNoPuedaDarLaClase = null;
            if (!(u is null))
            {
                foreach (Profesor item in u.Instructores)
                {
                    if (item != clase)
                    {
                        primerProfeQueNoPuedaDarLaClase = item;
                        //el primer profe que NO pueda dar la clase lo retorno.
                        break;
                    }
                }
            }

            return primerProfeQueNoPuedaDarLaClase;
        }

        /// <summary>
        /// Sobrecarga del operador "+" que agrega a un Alumno a la lista
        /// solamente si no se encuentra en ella.
        /// Caso contrario lanzará la excepción: AlumnoRepetidoException().
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador "+" que agrega a un Profesor a la lista.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador "+" que agrega a una clase a la a la lista
        /// de jornadas. Indicando la clase, el profesor que pueda dar esa clase y 
        /// la lista de alumnos que la toman.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            if(!(g is null))
            {
                Profesor auxProfesor = (g == clase);
                Jornada auxJornada = new Jornada(clase, auxProfesor);

                foreach (Alumno alumnito in g.Alumnos)
                {
                     if (alumnito == clase)//si el alumno cumpleRequisitos entra y lo agrego
                        auxJornada += alumnito;
                }

                if (!(auxJornada is null))
                    g.Jornada.Add(auxJornada);//agrego jornada a la universidad.
            }

            return g;
        }
        #endregion

        #region Override
        /// <summary>
		/// Sobrescritura del método ToString() que llama al
		/// método MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

    }
}
