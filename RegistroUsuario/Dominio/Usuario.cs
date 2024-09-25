namespace RegistroUsuario.Dominio;

public class Usuario
{
    public Usuario(string nome, long matricula, string senha, string email, DateTime dataNascimento, List<Certificado> certificados, Cargo cargo, Departamento departamento)
    {
        Nome = nome;
        Matricula = matricula;
        Senha = senha;
        Email = email;
        DataNascimento = dataNascimento;
        Certificados = certificados;
        Cargo = cargo;
        Departamento = departamento;
    }

    public string Nome { get; }
    public long Matricula { get; }
    public string Senha { get; }
    public string Email { get; }
    public DateTime DataNascimento { get; }
    public List<Certificado> Certificados { get; }
    public Cargo Cargo { get; }
    public Departamento Departamento { get; }
    
    public static string Salvar(Usuario usuario)
    {
        if (!ValidarPreenchimento(usuario))
            return "Um ou mais campos obrigatórios não preenchidos";
        
        Utils.Instance.Usuarios.Add(usuario);
        return "Cadastrado com sucesso!";
    }

    private static bool ValidarPreenchimento(Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nome)) return false;
        if (string.IsNullOrEmpty(usuario.Senha)) return false;
        if (string.IsNullOrEmpty(usuario.Email)) return false;
        if (usuario.Matricula == 0) return false;

        return true;
    }
}