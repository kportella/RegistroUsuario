namespace RegistroUsuario.Dominio;

public class Certificado
{
    public string Identificacao { get; set; }
    public string NumeroCertificado { get; set; }

    public static Certificado Criar(string identificacao, string numeroCertificado)
    {
        return new Certificado();
    }
}