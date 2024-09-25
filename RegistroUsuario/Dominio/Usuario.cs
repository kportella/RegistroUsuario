namespace RegistroUsuario.Dominio;

public class Usuario
{
    // private Usuario(string nome, long matricula, string senha, string email, DateTime dataNascimento, List<Certificado> certificados, Cargo cargo, Departamento departamento)
    // {
    //     Nome = nome;
    //     Matricula = matricula;
    //     Senha = senha;
    //     Email = email;
    //     DataNascimento = dataNascimento;
    //     Certificados = certificados;
    //     Cargo = cargo;
    //     Departamento = departamento;
    // }

    public string Nome { get; }
    public long Matricula { get; }
    public string Senha { get; }
    public string Email { get; }
    public DateTime DataNascimento { get; }
    public List<Certificado> Certificados { get; }
    public Cargo Cargo { get; }
    public Departamento Departamento { get; }

    public static Usuario Criar(string nome, long matricula, string senha, string email, DateTime dataNascimento, List<Certificado> certificados
        , Cargo cargo, Departamento departamento)
    {
        // return new Usuario(nome, matricula, senha, email, dataNascimento, certificados, cargo, departamento);
        return new();
    }
}