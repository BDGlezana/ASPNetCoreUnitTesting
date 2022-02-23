using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTest
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            int numero1Test = 50;
            int numero2Test = 69;

            //Act - ejecutar
            int resultado = op.SumarNumeros(numero1Test, numero2Test);

            //Assert - aserción

            Assert.AreEqual(119, resultado);
        }

        [Test]
        public void IsValorPar_InputNumeroImpar_ReturnFalse()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            int numeroImpar = 7;

            //Act - ejecutar
            bool isPar = op.IsValorPar(numeroImpar);

            //Assert - aserción

            Assert.IsFalse(isPar);
            Assert.That(isPar, Is.EqualTo(false));
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsValorPar2_InputNumeroImpar_ReturnFalse(int numeroImpar)
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();

            //Act - ejecutar
            return op.IsValorPar(numeroImpar);
        }

        [Test]
        public void IsValorPar_InputNumeroPar_ReturnTrue()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            int numeroPar = 10;

            //Act - ejecutar
            bool isPar = op.IsValorPar(numeroPar);

            //Assert - aserción

            Assert.IsTrue(isPar);
            Assert.That(isPar, Is.EqualTo(true));
        }


        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(20)]
        public void IsValorPar2_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();

            //Act - ejecutar
            bool isPar = op.IsValorPar(numeroPar);

            //Assert - aserción

            Assert.IsTrue(isPar);
            Assert.That(isPar, Is.EqualTo(true));
        }


        [Test]
        [TestCase(2.2, 1.2)]
        [TestCase(2.23, 1.24)]
        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double decimal1, double decimal2)
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();

            //Act - ejecutar
            double resultado = op.SumarDecimal(decimal1, decimal2);

            //Assert - aserción

            Assert.AreEqual(3.4, resultado, 0.1);
        }


        [Test]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            Operacion op = new();
            List<int> numerosImparesEsperados = new() { 5, 7, 9 };
            List<int> resultados= op.GetListaNumerosImpares(5, 10);

            Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));

            Assert.AreEqual(numerosImparesEsperados, resultados);

            Assert.That(resultados, Does.Contain(5));
            Assert.Contains(5, resultados);
            Assert.That(resultados, Is.Not.Empty);

            Assert.That(resultados.Count, Is.EqualTo(3));

            Assert.That(resultados, Has.No.Member(100));

            Assert.That(resultados, Is.Ordered.Ascending);
            Assert.That(resultados, Is.Ordered);
            Assert.That(resultados, Is.Unique);


        }


    }
}
