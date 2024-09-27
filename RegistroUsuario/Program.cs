// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using RegistroUsuario.Dominio;
using RegistroUsuario.RegrasNegocios;

Console.WriteLine("Controle de Usuário");
Console.WriteLine("-----------------------");
Console.WriteLine("Opções:");
Console.WriteLine("1 - Cadastrar");
Console.WriteLine("2 - Listar");
Console.WriteLine("3 - Consultar");
Console.WriteLine("4 - Editar");
Console.WriteLine("5 - Excluir");
Console.WriteLine("6 - Sair");
Console.WriteLine();

var input = Console.ReadLine();

var usuarioServico = new UsuarioServico();

switch (input)
{
    case "1":
        Console.WriteLine("Digite o Nome:");
        var nome = Console.ReadLine();

        Console.WriteLine("Digite a Matrícula (número):");
        var matricula = Convert.ToInt64(Console.ReadLine());

        Console.WriteLine("Digite a Senha:");
        var senha = Console.ReadLine();

        Console.WriteLine("Digite o Email:");
        var email = Console.ReadLine();

        Console.WriteLine("Digite a Data de Nascimento (dd/MM/yyyy):");
        var dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        
        Console.WriteLine("Quantos certificados você deseja adicionar?");
        int numCertificados = Convert.ToInt32(Console.ReadLine());

        var certificados = new List<Certificado>();

        for (int i = 0; i < numCertificados; i++)
        {
            Console.WriteLine("Digite o Título do Certificado:");
            var titulo = Console.ReadLine();
            
            Console.WriteLine("Digite o Código do Certificado:");
            var codigo = long.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Data de Emissão do Certificado (dd/MM/yyyy):");
            var dataEmissao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            
            Console.WriteLine("Digite a Carga Horária do Certificado:");
            var cargaHoraria = int.Parse(Console.ReadLine());
            
            certificados.Add(new(titulo, codigo, dataEmissao, cargaHoraria));
        }
        
        Console.WriteLine("Digite o Nome do Cargo:");
        var nomeCargo = Console.ReadLine();

        Console.WriteLine("Digite o Código do Cargo:");
        var codigoCargo = Console.ReadLine();

        var cargo = new Cargo(nomeCargo, codigoCargo);
        
        Console.WriteLine("Digite o Nome do Departamento:");
        var nomeDepartamento = Console.ReadLine();

        Console.WriteLine("Digite o Código do Departamento:");
        var codigoDepartamento = Console.ReadLine();
        
        var departamento = new Departamento(nomeDepartamento, codigoDepartamento);
        
        usuarioServico.Salvar(new Usuario(nome, matricula, senha, email, dataNascimento, certificados, cargo, departamento, false));

        break;
    
    case "2":
        
        break;
}