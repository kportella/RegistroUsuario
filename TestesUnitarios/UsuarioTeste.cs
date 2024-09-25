using FluentAssertions;
using RegistroUsuario;
using RegistroUsuario.Dominio;
using RegistroUsuario.RegrasNegocios;

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
            , departamento
            , false);

        // Act

        var resultado = new UsuarioServico().Salvar(usuario);

        // Assert

        Utils.Instance.Usuarios.Exists(x => x.Matricula == usuario.Matricula).Should().BeTrue();
        resultado.Should().Be("Cadastrado com sucesso!");
    }

    [Theory]
    [InlineData("Guilherme", "123456", "email@email.com", 0)]
    [InlineData("Guilherme", "123456", null, 123456)]
    [InlineData("Guilherme", null, "email@email.com", 123456)]
    [InlineData(null, "123456", "email@email.com", 123456)]
    public void RegistrarUsuario_ComCamposObrigatoriosNaoPreenchidos_NaoDeveSalvar(string nome, string senha, string email, int matricula)
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

        var usuario = new Usuario(nome
            , matricula
            , senha
            , email
            , dataNascimento
            , certificados
            , cargo
            , departamento
            , false);

        
        // Act
        
        var retorno = new UsuarioServico().Salvar(usuario);
        
        // Assert
        
        retorno.Should().Be("Um ou mais campos obrigatórios não preenchidos");
        Utils.Instance.Usuarios.Exists(x => x.Matricula == usuario.Matricula).Should().BeFalse();
    }

    [Fact]
    public void CongelamentoUsuario_QuandoUsuarioCongelar_DeveRetornarUsuarioCongelado()
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
            , departamento
            , false);
        
        var usuarioServico = new UsuarioServico();
        usuarioServico.Salvar(usuario);
        
        // Act

        var retorno = usuarioServico.CongelarUsuario(usuario.Matricula);

        // Assert
        
        Utils.Instance.Usuarios.Find(x => x.Matricula == usuario.Matricula)!.Congelado.Should().BeTrue();
        retorno.Should().Be("Usuário congelado com sucesso!");
    }

    [Fact]
    public void RegistrarUsuario_MatriculaJaCadastrado_NaoDeveSalvar()
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
            , departamento
            , false);
        
        var usuarioServico = new UsuarioServico();
        usuarioServico.Salvar(usuario);
        
        // Act
        
        var resultado = usuarioServico.Salvar(usuario);
        
        // Assert

        resultado.Should().Be("Matricula já existente.");
    }

    [Fact]
    public void RegistrarUsuario_DataDeNascimentoDataFutura_NaoDeveSalvar()
    {
        // Arrange
        
        var dataNascimento = DateTime.Now.AddDays(1);
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
            , departamento
            , false);
        
        // Act
        
        var resultado = new UsuarioServico().Salvar(usuario);
        
        // Assert
        
        Utils.Instance.Usuarios.Exists(x => x.Matricula == usuario.Matricula).Should().BeFalse();
        resultado.Should().Be("Data de nascimento inválida.");
    }
}