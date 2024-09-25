namespace RegistroUsuario.Dominio;

public class Certificado
{
    public string Titulo { get; set; }
    public long Codigo { get; set; }
    public DateTime DataEmissao { get; set; }
    public int CargaHoraria { get; set; }

    public static Certificado Criar(string titulo, long codigo, DateTime dataEmissao, int cargaHoraria)
    {
        return new Certificado();
    }
}