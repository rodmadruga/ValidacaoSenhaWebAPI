using Microsoft.AspNetCore.Mvc;
using ValidacaoSenhaWebAPI.Controllers;
using Xunit;

namespace ValidacaoSenhaTest
{
    public class SenhaControllerUnitTest
    {
        [Fact]
        public void TestSenhaValida()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("a123456789Z@");

            Assert.NotNull(result);
            Assert.Equal(true, ((ObjectResult)result).Value);
            Assert.Equal(200, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public void TestSenhaVazia()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("");

            Assert.NotNull(result);
            Assert.Equal("Necessário possuir nove ou mais caracteres", ((ObjectResult)result).Value);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public void TestSenhaSemDigito()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("aBcdefghij@");

            Assert.NotNull(result);
            Assert.Equal("Necessário possuir ao menos 1 dígito", ((ObjectResult)result).Value);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public void TestSenhaSemLetraMinuscula()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("A123456789Z@");

            Assert.NotNull(result);
            Assert.Equal("Necessário possuir ao menos 1 letra minúscula", ((ObjectResult)result).Value);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public void TestSenhaSemLetraMaiuscula()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("a123456789z@");

            Assert.NotNull(result);
            Assert.Equal("Necessário possuir ao menos 1 letra maiúscula", ((ObjectResult)result).Value);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public void TestSenhaSemCaractereEspecial()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("a123456789ZY");

            Assert.NotNull(result);
            Assert.Equal("Necessário possuir ao menos 1 caractere especial", ((ObjectResult)result).Value);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public void TestSenhaComCaracteresRepetidos()
        {
            var controller = new SenhaController();
            var result = (ActionResult)controller.Validar("aa123456789Z@");

            Assert.NotNull(result);
            Assert.Equal("Não pode possuir caracteres repetidos dentro do conjunto", ((ObjectResult)result).Value);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }
    }
}