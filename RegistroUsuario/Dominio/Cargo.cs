namespace RegistroUsuario.Dominio;

public class Cargo
{
    public Cargo(string nome, string codigo)
    {
        Nome = nome;
        Codigo = codigo;
    }

    public string Nome { get; set; }
    public string Codigo { get; set; }
}