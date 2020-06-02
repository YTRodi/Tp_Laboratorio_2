using System;
using Clases_Instanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testeos
{
    [TestClass]
    public class TestUniversidad
    {
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
