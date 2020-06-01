using Clases_Instanciables;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaEnConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            /*ok*/Universidad uni = new Universidad();

            /*ok*/Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            /*ok*/uni += a1;

            try
            {
                /*NO*/Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                /*NO*/uni += a2;
            }
            catch (NacionalidadInvalidaException e) /*ok*/
            {
                Console.WriteLine(e.Message); /*ok*/
            }
            try
            {
                /*NO*/Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
                /*NO*/uni += a3;
            }
            catch (AlumnoRepetidoException e) /*ok*/
            {
                Console.WriteLine(e.Message); /*ok*/
            }
            /*ok*/Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            /*ok*/uni += a4;
            /*ok*/Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            /*ok*/uni += a5;
            /*ok(DEUDOR)*/Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            /*ok*/uni += a6;
            /*ok*/Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            /*ok*/uni += a7;
            /*ok*/Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            /*ok*/uni += a8;

            //ALUMNOS (6): a1,a4,a5,a6(DEUDOR),a7
            //--------------------------------------------------------------------------------------------------------------------

            /*ok*/Profesor i1 = new Profesor(1, "Juan", "Lopez", "12224458", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            /*ok*/uni += i1;
            /*ok*/Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            /*ok*/uni += i2;

            //PROFESORES/INSTRUCTORES (2): i1,i2
            //--------------------------------------------------------------------------------------------------------------------

            try
            {
                uni += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(uni.ToString());
            Console.ReadKey();
            Console.Clear();

            /*TODO OK HASTA ACÁ*/

            try
            {
                Universidad.Guardar(uni);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                int jornada = 0;
                Jornada.Guardar(uni[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
                //Console.WriteLine(Jornada.Leer());
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
