namespace RegistroUsuario.Dominio;

public class Cargo
{
    private Cargo(string nome, string codigo)
    {
        Nome = nome;
        Codigo = codigo;
    }

    public string Nome { get; set; }
    public string Codigo { get; set; }

    public static Cargo Criar(string nome, string codigo)
    {
        return new Cargo(nome, codigo);
    }
}