namespace RegistroUsuario.Dominio;

public class Certificado
{
    public Certificado(string titulo, long codigo, DateTime dataEmissao, int cargaHoraria)
    {
        Titulo = titulo;
        Codigo = codigo;
        DataEmissao = dataEmissao;
        CargaHoraria = cargaHoraria;
    }

    public string Titulo { get; set; }
    public long Codigo { get; set; }
    public DateTime DataEmissao { get; set; }
    public int CargaHoraria { get; set; }
}