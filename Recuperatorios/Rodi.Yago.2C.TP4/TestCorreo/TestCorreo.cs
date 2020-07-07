using System;
using EntidadesHechas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCorreo
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        public void TListPaquetesInstanciada()
        {
            //Arrange
            Correo c;

            //Act
            c = new Correo();

            //Assert
            Assert.IsNotNull(c.Paquetes);
        }


        [TestMethod]
        [ExpectedException(typeof(TrackingIDException))]
        public void TPaqueteRepetido()
        {
            //Arrange
            Correo c = new Correo();
            Paquete p01 = new Paquete("Arkahm al 1500", "12345678");
            Paquete p02 = new Paquete("Metrópolis al 2000", "12345678");

            //Act
            c += p01;
            c += p02;
        }
    }
}
