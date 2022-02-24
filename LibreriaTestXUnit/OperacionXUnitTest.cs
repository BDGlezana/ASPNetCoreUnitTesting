using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibreriaTest
{
    public class OperacionXUnitTest
    {
        [Fact]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            int numero1Test = 50;
            int numero2Test = 69;

            //Act - ejecutar
            int resultado = op.SumarNumeros(numero1Test, numero2Test);

            //Assert - aserción

            Assert.Equal(119, resultado);
        }

        [Fact]
        public void IsValorPar_InputNumeroImpar_ReturnFalse()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            int numeroImpar = 7;

            //Act - ejecutar
            bool isPar = op.IsValorPar(numeroImpar);

            //Assert - aserción

            //Assert.Equalzzzz(isPar);
             //Assert.That(isPar, Is.EqualTo(false));
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsValorPar2_InputNumeroImpar_ReturnFalse(int numeroImpar,bool expectedResult)
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            var resultado = op.IsValorPar(numeroImpar);

            Assert.Equal(expectedResult, resultado);
        }

        [Fact]
        public void IsValorPar_InputNumeroPar_ReturnTrue()
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();
            int numeroPar = 10;

            //Act - ejecutar
            bool isPar = op.IsValorPar(numeroPar);

            //Assert - aserción

            //Assert.IsTrue(isPar);
            //Assert.That(isPar, Is.EqualTo(true));
        }


        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
        public void IsValorPar2_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();

            //Act - ejecutar
            bool isPar = op.IsValorPar(numeroPar);

            //Assert - aserción

            Assert.True(isPar);
            //Assert.That(isPar, Is.EqualTo(true));
        }


        [Theory]
        [InlineData(2.2, 1.2)]
        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double decimal1, double decimal2)
        {
            //Arrange - inicializar objetos y variables
            Operacion op = new();

            //Act - ejecutar
            double resultado = op.SumarDecimal(decimal1, decimal2);

            //Assert - aserción

            Assert.Equal(3.4, resultado,0);
        }


        [Fact]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            Operacion op = new();
            List<int> numerosImparesEsperados = new() { 5, 7, 9 };
            List<int> resultados= op.GetListaNumerosImpares(5, 10);

            Assert.Equal(numerosImparesEsperados, resultados);

            Assert.Contains(5, resultados);
            Assert.NotEmpty(resultados);

            Assert.Equal(3, resultados.Count);

            Assert.DoesNotContain(100,resultados);

            Assert.Equal(resultados.OrderBy(u=>u),resultados);


        }


    }
}
