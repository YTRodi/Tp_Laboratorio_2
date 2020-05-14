using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
	{
        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> listaAlumnos;//lista de inscriptos
        private List<Jornada> listaJornadas;
        private List<Profesor> listaProfesores;//lista de quienes pueden dar clase.
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
        public Universidad()
        {
            this.listaAlumnos = new List<Alumno>();
            this.listaJornadas = new List<Jornada>();
            this.listaProfesores = new List<Profesor>();
        }
        #endregion

        #region Métodos
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.Jornada)
            {
                sb.AppendLine($"{item.Clase.ToString()}");//MUESTRO DATOS DE LAS CLASES
                sb.AppendLine($"{item.Instructor.ToString()}");//MUESTRO DATOS DE LOS PROFESORES
                sb.AppendLine($"{item.Alumnos.ToString()}");//MUESTRO DATOS DE LOS ALUMNOS
            }
            return sb.ToString();
        }

        public bool Guardar(Universidad uni)
        {
            return true;
        }

        public Universidad Leer()
        {
            return this;
        }
        #endregion

        #region Operaciones
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool inscripto = false;
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                    inscripto = true;
            }
            return inscripto;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool daClases = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                    daClases = true;
            }
            return daClases;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor primerProfesor = null;
            foreach  (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    primerProfesor = item;
                }
            }
            if (primerProfesor is null)
            {
                //throw new SinProfesorExceptio();
            }
            return primerProfesor;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor primerProfesor = null;
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    primerProfesor = item;//el primer profe que no pueda dar la clase lo retorno.
                    break;
                }
            }//Si no hubiera instructores, se lanza solo la exception QUE NO HAY PROFESOR?
            return primerProfesor;
        }


        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
            {
                //throw new AlumnoRepetidoException;
            }
            return u;
        }


        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            else
            {
                //throw SinProfesor
            }
            //No hace falta lanzar una exception debido a que ya se lanzaria en los operadores.
            return u;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            //JERARQUIA:
            //CLASE --> PROFESOR --> JORNADA --> ALUMNOS --> AGREGO LA JORNADA A LA UNIVERSIDAD.

            //En estas variables voy a guardar lo que suceda.
            Jornada auxJornada = null;
            Profesor auxProfesor = null;

            if(!(g is null))
            {
                //SE PUEDE HACER MEJOR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



                //////////////////////////////////////////////////////////////////////
                foreach (Profesor item in g.Instructores)
                {
                    if(item == clase)//si la clase está dada por algún profesor, se la asigno al profe.
                    {
                        auxProfesor = item;
                        break;
                    }
                }
                if(!(auxProfesor is null))
                {
                    //throw new SinPrxfesorExceptio();
                }
                else
                {
                    //Creo jornada.
                    auxJornada = new Jornada(clase, auxProfesor);
                }

                foreach (Alumno item in g.Alumnos)
                {
                    if (item == clase)
                        auxJornada.Alumnos.Add(item);//agrego el alumno a la jornada.
                }

                if(!(auxJornada is null))
                {
                    g.Jornada.Add(auxJornada);//agrego la jornada a la universidad.
                }
            }
            else
            {
                //SI ES NULL LA UNIVERSIDAD PODRÍA LANZAR UN NULLREFECENTEXCEPTION.
            }
            return g;
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

    }
}
