using Domain.Entidades;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Test
{
    public class CaixaEletronicoTeste
    {
        [Theory(DisplayName = "Saque da quantidade exata de cédulas")]
        [Trait("Category", "Saque")]
        [InlineData(187)]
        public void Teste_Saca_Quantidade_Exata_De_Cedulas(int valorSaque)
        {
            // Given
            var cedulasCofre = new List<Cedula>();
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(100, 1));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(50, 1));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(20, 1));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(10, 1));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(5, 1));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(2, 1));
            var caixaEletronico = new Caixa(cedulasCofre);

            // When
            var cedulas = caixaEletronico.Saca(valorSaque);
            var valorTotalCedulas = cedulas.Sum(c => c.Valor);

            // Then
            Assert.Equal(valorSaque, valorTotalCedulas);
        }

        [Theory(DisplayName = "Saque de cedulas")]
        [Trait("Category", "Saque")]
        [InlineData(260)]
        public void Teste_Saca_Cedulas(int valorSaque)
        {
            // Given
            var cedulasCofre = new List<Cedula>();
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(100, 3));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(50, 3));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(20, 3));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(10, 3));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(5, 3));
            cedulasCofre.AddRange(Cedula.Factor.CreateMany(2, 3));
            var caixaEletronico = new Caixa(cedulasCofre);

            // When
            var cedulas = caixaEletronico.Saca(valorSaque);
            var valorTotalCedulas = cedulas.Sum(c => c.Valor);

            // Then
            Assert.Equal(valorSaque, valorTotalCedulas);
        }
    }
}
