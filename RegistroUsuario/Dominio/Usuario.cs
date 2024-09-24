namespace RegistroUsuario.Dominio;

public class Usuario
{
    public string Nome { get; }
    public string Matricula { get; }
    public string Departamento { get; }
    public DateTime DataNascimento { get; }
    public List<Certificado> Certificados { get; }
    public string Cargo { get; }
    public string Especialidade { get; }

    public static Usuario Criar(string nome, string matricula, string departamento, DateTime dataNascimento, List<Certificado> certificados
        , string cargo, string especialidade)
    {
        return new Usuario();
    }
}