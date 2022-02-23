using LibreriaTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTestMSTest
{
    [TestClass]
    public  class OperacionMSTest
    {
        [TestMethod]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new Operacion();
            int numero1Test = 50;
            int numero2Test = 69;

            //Act - ejecutar
            int resultado = op.SumarNumeros(numero1Test, numero2Test);

            //Assert - porcentaje de aserción

            Assert.AreEqual(119, resultado);
        }
    }
}
