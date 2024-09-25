using RegistroUsuario.Dominio;

namespace RegistroUsuario;

public class Utils
{
    private static Utils _instance;

    private Utils()
    {
        Usuarios = new List<Usuario>();
        Cargos = new List<Cargo>();
        Departamentos = new List<Departamento>();
        Certificados = new List<Certificado>();
    }

    public static Utils Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Utils();
            } 
            return _instance;
        }
    }
    public  List<Usuario> Usuarios { get; set; }
    public  List<Cargo> Cargos { get; set; }
    public  List<Departamento> Departamentos { get; set; }
    public  List<Certificado> Certificados { get; set; }
}