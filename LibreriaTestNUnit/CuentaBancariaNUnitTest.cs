using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTest
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        
        private CuentaBancaria cuentaBancaria;

        [SetUp]
        public void Setup()
        {
            cuentaBancaria = new CuentaBancaria(new LoggerFake());
        }

        [Test]
        public void Deposito_Input100LoggerFake_ReturnsTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());
            var resultado = cuentaBancaria.Deposito(100);
            Assert.IsTrue(resultado);  
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));

        }

        [Test]
        public void Deposito_Input100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);
            var resultado = cuentaBancaria.Deposito(100);
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));

        }

        [Test]
        [TestCase(200,100)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.Is<int>(x=>x>0))).Returns(true);
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.IsTrue(resultado);

        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);
            Assert.IsFalse(resultado);

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";


            loggerGeneralMock.Setup(u=>u.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            var resultado = loggerGeneralMock.Object.MessageConReturnString("hoLA munDo");

            Assert.That(resultado, Is.EqualTo(textoPrueba));
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";

            loggerGeneral.Setup(u => u.MessageConOutParametroBooleano(It.IsAny<string>(),out textoPrueba)).Returns(true);

            string parametroOut= "";
            var resultado = loggerGeneral.Object.MessageConOutParametroBooleano("John", out parametroOut);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoRef_ReturnTRue() {
            
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Cliente cliente = new();
            Cliente clienteNousado = new();

            loggerGeneralMock.Setup(u=>u.MessageConObjetoReferenciaBooleano(ref cliente)).Returns(true);

            Assert.IsTrue(loggerGeneralMock.Object.MessageConObjetoReferenciaBooleano(ref cliente));
            Assert.IsFalse(loggerGeneralMock.Object.MessageConObjetoReferenciaBooleano(ref clienteNousado));
        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue() {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            loggerGeneralMock.Setup(u => u.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(u => u.PrioridadLogger).Returns(10);

            loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.That(loggerGeneralMock.Object.TipoLogger, Is.EqualTo("warning"));
            Assert.That(loggerGeneralMock.Object.PrioridadLogger, Is.EqualTo(10));

            //Callbacks
            int contador = 5;
            string textoTemporal = "hola";
            loggerGeneralMock.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true)
                .Callback(()=> contador++);

            loggerGeneralMock.Object.LogDatabase("adios");

            Assert.That(contador, Is.EqualTo(6));
        }
        [Test]
        public void CuentaBancariaLoggerGeneral_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);

            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));

            //verificar cuantas veces el mock esta llamando a mock-message
            loggerGeneralMock.Verify(u => u.Message(It.IsAny<string>()),Times.Exactly(3));
            loggerGeneralMock.Verify(u => u.Message("Es otro texto2"),Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(u => u.PrioridadLogger=100, Times.Once);
            loggerGeneralMock.VerifyGet(u => u.PrioridadLogger, Times.Once);
        }
    }
}
