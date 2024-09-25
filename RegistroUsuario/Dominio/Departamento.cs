namespace RegistroUsuario.Dominio;

public class Departamento
{
    public string Nome { get; set; }
    public string Codigo { get; set; }

    public static Departamento Criar(string nome, string codigo)
    {
        return new Departamento();
    }
}