using FluentAssertions;
using RegistroUsuario.Dominio;

namespace TestesUnitarios;

public class UsuarioTeste
{
    [Fact]
    public void RegistrarUsuario()
    {
        // Arrange

        var dataNascimento = DateTime.Now;
        var certificados = new List<Certificado>()
        {
            Certificado.Criar("1", "123456"),
            Certificado.Criar("2", "123456")
        };
        
        // Act

        var resultado = Usuario.Criar("Kauê"
        , "123456"
        , "1"
        , dataNascimento
        , certificados
        , "1"
        , "1");

        // Assert
        
        resultado.Nome.Should().Be("Kauê");
        resultado.Matricula.Should().Be("123456");
        resultado.Departamento.Should().Be("1");
        resultado.DataNascimento.Should().Be(dataNascimento);
        resultado.Certificados.Should().Contain(certificados);
        resultado.Cargo.Should().Be("1");
        resultado.Especialidade.Should().Be("1");
    }
}