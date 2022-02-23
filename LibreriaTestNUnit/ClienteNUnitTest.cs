using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaTest
{
    [TestFixture]
    public class ClienteNUnitTest
    {

        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_NombreApellido_ReturnNombreCompleto()
        {
            //arrange
            //Cliente cliente = new();

            //act
            cliente.CrearNombreCompleto("John", "Doe");

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(cliente.ClientNombre, Is.EqualTo("John Doe"));
                Assert.AreEqual(cliente.ClientNombre, "John Doe");
                Assert.That(cliente.ClientNombre, Does.Contain("Doe"));
                Assert.That(cliente.ClientNombre, Does.Contain("doe").IgnoreCase);
                Assert.That(cliente.ClientNombre, Does.StartWith("John"));
                Assert.That(cliente.ClientNombre, Does.EndWith("Doe"));
            });

           
        }

        [Test]
        public void ClientNombre_NoValues_returnsNull()
        {
            //Cliente cliente = new();

            //client.CrearNombreCompleto("John", "Doe");
            Assert.IsNull(cliente.ClientNombre);
        }

        [Test]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;

            Assert.That(descuento, Is.InRange(5, 24));
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            cliente.CrearNombreCompleto("John", "");
            Assert.IsNotNull(cliente.ClientNombre);
            Assert.IsFalse(string.IsNullOrEmpty(cliente.ClientNombre));
        }

        [Test]
        public void ClientNombre_InputNombreBlanco_ThrowsException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() =>
            {
                cliente.CrearNombreCompleto("", "Doe");
            });
            Assert.AreEqual("El nombre esta en blanco", exceptionDetalle.Message);
            Assert.That(() =>
            cliente.CrearNombreCompleto("", "Doe"), Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco")
            );

            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Doe"));
            Assert.That(() =>
                cliente.CrearNombreCompleto("","Doe"),Throws.ArgumentException
            );
        }

        [Test]
        public void GetClienteDetalle_CrearClienteMenos500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 150;
            var resultado = cliente.GetClienteDetalle();

            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteMas500TotalOrder_ReturnsClientePremium()
        {
            cliente.OrderTotal = 700;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }

    }
} 
