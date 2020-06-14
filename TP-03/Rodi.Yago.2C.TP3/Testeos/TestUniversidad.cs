using System;
using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testeos
{
    [TestClass]
    public class TestUniversidad
    {
        /// <summary>
        /// Test que valida que se produce la excepción "AlumnoRepetidoException"
        /// cuando quiere agregarse el mismo alumno a la universidad.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            //Arrange
            Universidad uni = new Universidad();
            Alumno alumno01 = new Alumno(1, "Lalo", "Landa", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno alumno02 = new Alumno(2, "Elsa", "Lame", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.Becado);

            //Act
            uni += alumno01;
            uni += alumno02;

            //Assert Exception.
        }

        /// <summary>
        /// Test que valida que se produce la excepción "NacionalidadInvalidaException"
        /// cuando el dni del alumno no coincide con el rango de dni que tendría que tener
        /// su nacionalidad.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            //Arrange
            Alumno alumno01 = null;

            //Act
            alumno01 = new Alumno(1, "Lalo", "Landa", "90000000", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            //Assert Exception.
        }

        /// <summary>
        /// Test que valida que se produce la excepción "SinProfesorException"
        /// cuando un profesor no da esa clase.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor()
        {
            //Arrange
            Universidad uni = new Universidad();
            Universidad.EClases clase;
            Profesor auxProfesor = null;

            //Act
            clase = Universidad.EClases.SPD;
            auxProfesor = (uni == clase);

            //Assert Exception.
        }

        /// <summary>
        /// Test que valida que se produce la excepción "DniInvalidoException"
        /// cuando se ingresa una cadena de carácteres en el dni.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {
            //Arrange
            Alumno alumno01 = null;

            //Act
            alumno01 = new Alumno(1, "Lalo", "Landa", "DEENEI", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            //Assert Exception.
        }
    }
}
