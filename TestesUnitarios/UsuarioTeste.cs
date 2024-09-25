using FluentAssertions;
using RegistroUsuario;
using RegistroUsuario.Dominio;

namespace TestesUnitarios;

public class UsuarioTeste
{
    [Fact]
    public void RegistrarUsuario_ComCamposObrigatoriosPreenchidos_DeveSalvar()
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

        var usuario = new Usuario("Guilherme"
            , 123456
            , "123456"
            , "email@email.com"
            , dataNascimento
            , certificados
            , cargo
            , departamento);

        // Act

        var resultado = Usuario.Salvar(usuario);

        // Assert

        Utils.Instance.Usuarios.Exists(x => x.Matricula == usuario.Matricula).Should().BeTrue();
        resultado.Should().Be("Cadastrado com sucesso!");
    }

    [Fact]
    public void RegistrarUsuario_ComCamposObrigatoriosNaoPreenchidos_NaoDeveSalvar()
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

        var usuario = new Usuario(null
            , 123456
            , "123456"
            , "email@email.com"
            , dataNascimento
            , certificados
            , cargo
            , departamento);

        
        // Act
        
        var retorno = Usuario.Salvar(usuario);
        
        // Assert
        
        retorno.Should().Be("Um ou mais campos obrigatórios não preenchidos");
        
        
    }
}