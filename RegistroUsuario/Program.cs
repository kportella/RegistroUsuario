// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using RegistroUsuario.RegrasNegocios;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IUsuario, UsuarioServico>();

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

switch (input)
{
    
}