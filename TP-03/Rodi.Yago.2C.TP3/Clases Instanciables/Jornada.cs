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
        private Jornada()
        {
            //this.listaAlumnos = new List<Alumno>();
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Métodos
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTxt = new Texto();
            string ruta = Directory.GetCurrentDirectory() + @"\Jornada.txt";
            bool pudoGuardar = false;

            if (archivoTxt.Guardar(ruta, jornada.ToString()))
                pudoGuardar = true;

            return pudoGuardar;
        }

        public static string Leer()
        {
            Texto archivoTxt = new Texto();
            string ruta = Directory.GetCurrentDirectory() + @"\Jornada.txt";
            archivoTxt.Leer(ruta, out string jornadaDatos);
            return jornadaDatos;
        }
        #endregion

        #region Operaciones
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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.listaAlumnos.Add(a);
            return j;
        }
        #endregion

        #region Override
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
