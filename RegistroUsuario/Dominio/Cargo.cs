namespace RegistroUsuario.Dominio;

public class Cargo
{
    public string Nome { get; set; }
    public string Codigo { get; set; }

    public static Cargo Criar(string nome, string codigo)
    {
        return new Cargo();
    }
}