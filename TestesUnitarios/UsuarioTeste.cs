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
            Certificado.Criar("1", 123456, DateTime.Now, 10),
            Certificado.Criar("1", 123456, DateTime.Now, 10),
        };

        var cargo = Cargo.Criar("1", "Nome cargo");
        var departamento = Departamento.Criar("1", "Nome departamento");
        
        // Act

        var resultado = Usuario.Criar("Kauê"
        , 123456
        , "123456"
        , "email@email.com"
        , dataNascimento
        , certificados
        , cargo
        , departamento);

        // Assert
        
        resultado.Nome.Should().Be("Kauê");
        resultado.Matricula.Should().Be(123456);
        resultado.Senha.Should().Be("123456");
        resultado.Email.Should().Be("email@email.com");
        resultado.DataNascimento.Should().Be(dataNascimento);
        resultado.Departamento.Should().Be("1");
        resultado.Certificados.Should().Contain(certificados);
        resultado.Cargo.Should().Be("1");
        resultado.Departamento.Should().Be("1");
    }
}