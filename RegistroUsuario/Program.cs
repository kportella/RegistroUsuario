// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using RegistroUsuario;
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

string[] registroOpcoes = {"Nome", "Matricula", "Senha", "Email", "DataNascimento"};
string[] certificadosOpcoes = {"Titulo", "Codigo", "Data Emissão", "Carga Horaria" };
string[] cargoOpcoes = {"Nome", "Codigo"};
string[] departamentoOpcoes = {"Nome", "Codigo"};
string[] geralOpcoes = {"Registro", "Certificados", "Cargo", "Departamento"};

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
        Utils.Instance.Usuarios.ForEach(usuario =>
        {
            Console.WriteLine("\n---- Registro ----");
            Console.WriteLine($"Nome: {usuario.Nome}");
            Console.WriteLine($"Matrícula: {usuario.Matricula}");
            Console.WriteLine($"Senha: {usuario.Senha}");
            Console.WriteLine($"Email: {usuario.Email}");
            Console.WriteLine($"Data de Nascimento: {usuario.DataNascimento.ToString("dd/MM/yyyy")}");

            Console.WriteLine("\n---- Certificados ----");
            foreach (var certificado in usuario.Certificados)
            {
                Console.WriteLine($"Título: {certificado.Titulo}");
                Console.WriteLine($"Código: {certificado.Codigo}");
                Console.WriteLine($"Data de Emissão: {certificado.DataEmissao.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Carga Horária: {certificado.CargaHoraria}");
            }
            
            Console.WriteLine("\n---- Cargo ----");
            Console.WriteLine($"Cargo: {usuario.Cargo.Nome}");
            Console.WriteLine($"Código do Cargo: {usuario.Cargo.Codigo}");
            
            Console.WriteLine("\n---- Departamento ----");
            Console.WriteLine($"Departamento: {usuario.Departamento.Nome}");
            Console.WriteLine($"Código do Departamento: {usuario.Departamento.Codigo}");
        });
        
        break;
    
    case "3":
        Console.WriteLine("Digite a matricula do usuário:");
        var matriculaUsuario = long.Parse(Console.ReadLine());

        var usuarioSelecionado = Utils.Instance.Usuarios.Where(x => x.Matricula == matriculaUsuario).First();
        
        Console.WriteLine("\n---- Registro ----");
        Console.WriteLine($"Nome: {usuarioSelecionado.Nome}");
        Console.WriteLine($"Matrícula: {usuarioSelecionado.Matricula}");
        Console.WriteLine($"Senha: {usuarioSelecionado.Senha}");
        Console.WriteLine($"Email: {usuarioSelecionado.Email}");
        Console.WriteLine($"Data de Nascimento: {usuarioSelecionado.DataNascimento.ToString("dd/MM/yyyy")}");

        Console.WriteLine("\n---- Certificados ----");
        foreach (var certificado in usuarioSelecionado.Certificados)
        {
            Console.WriteLine($"Título: {certificado.Titulo}");
            Console.WriteLine($"Código: {certificado.Codigo}");
            Console.WriteLine($"Data de Emissão: {certificado.DataEmissao.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Carga Horária: {certificado.CargaHoraria}");
        }
            
        Console.WriteLine("\n---- Cargo ----");
        Console.WriteLine($"Cargo: {usuarioSelecionado.Cargo.Nome}");
        Console.WriteLine($"Código do Cargo: {usuarioSelecionado.Cargo.Codigo}");
            
        Console.WriteLine("\n---- Departamento ----");
        Console.WriteLine($"Departamento: {usuarioSelecionado.Departamento.Nome}");
        Console.WriteLine($"Código do Departamento: {usuarioSelecionado.Departamento.Codigo}");
        break;
    
    case "4":
        int selectedIndex = 0;

        string selectedOption = DisplayMenuWithSubmenu(geralOpcoes, registroOpcoes, certificadosOpcoes, cargoOpcoes, departamentoOpcoes);
        
        break;
    
    case "5":
        Console.WriteLine("Digite a matricula do usuário:");
        var matriculaUsuarioDelecao = long.Parse(Console.ReadLine());
        
        var usuarioSelecionadoDelecao = Utils.Instance.Usuarios.Where(x => x.Matricula == matriculaUsuarioDelecao).First();
        Utils.Instance.Usuarios.Remove(usuarioSelecionadoDelecao);
        
        break;
    
    case "6":
        Console.WriteLine("Saindo...");
        return;
    
    default:
        Console.WriteLine("Comando desconhecido.");
        break;
}

static string DisplayMenuWithSubmenu(string[] geralOpcoes, string[] registroOpcoes, string[] certificadosOpcoes, string[] cargoOpcoes, string[] departamentoOpcoes)
{
    // Display the main menu
    int selectedIndex = 0;
    ConsoleKey keyPressed;

    do
    {
        DisplayMenu(geralOpcoes, selectedIndex);
        keyPressed = Console.ReadKey(true).Key;

        // Navigate through the main menu
        if (keyPressed == ConsoleKey.UpArrow)
        {
            selectedIndex = selectedIndex == 0 ? geralOpcoes.Length - 1 : selectedIndex - 1;
        }
        else if (keyPressed == ConsoleKey.DownArrow)
        {
            selectedIndex = selectedIndex == geralOpcoes.Length - 1 ? 0 : selectedIndex + 1;
        }

    } while (keyPressed != ConsoleKey.Enter); // Continue until Enter is pressed

    // Based on the selected main option, display the corresponding submenu
    switch (geralOpcoes[selectedIndex])
    {
        case "Registro":
            return DisplaySubMenu("Registro", registroOpcoes);
        case "Certificados":
            return DisplaySubMenu("Certificados", certificadosOpcoes);
        case "Cargo":
            return DisplaySubMenu("Cargo", cargoOpcoes);
        case "Departamento":
            return DisplaySubMenu("Departamento", departamentoOpcoes);
        default:
            return "Invalid Selection";
    }
}

static string DisplaySubMenu(string title, string[] options)
{
    int selectedIndex = 0;
    ConsoleKey keyPressed;

    do
    {
        Console.Clear(); // Clear console to display the submenu
        Console.WriteLine($"-- {title} Menu --\n");
        DisplayMenu(options, selectedIndex);
        keyPressed = Console.ReadKey(true).Key;

        // Navigate through the submenu
        if (keyPressed == ConsoleKey.UpArrow)
        {
            selectedIndex = selectedIndex == 0 ? options.Length - 1 : selectedIndex - 1;
        }
        else if (keyPressed == ConsoleKey.DownArrow)
        {
            selectedIndex = selectedIndex == options.Length - 1 ? 0 : selectedIndex + 1;
        }

    } while (keyPressed != ConsoleKey.Enter); // Continue until Enter is pressed

    return $"{title}: {options[selectedIndex]}";
}

static void DisplayMenu(string[] options, int selectedIndex)
{
    Console.Clear(); // Clear console to redraw the menu

    for (int i = 0; i < options.Length; i++)
    {
        if (i == selectedIndex)
        {
            // Highlight the selected option
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.WriteLine(options[i]);

        // Reset colors
        Console.ResetColor();
    }
}


