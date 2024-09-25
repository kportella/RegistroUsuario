using RegistroUsuario.Dominio;

namespace RegistroUsuario.RegrasNegocios;

public interface IUsuario
{
    string Salvar(Usuario usuario);
}