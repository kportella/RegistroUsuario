using RegistroUsuario.Dominio;

namespace RegistroUsuario.RegrasNegocios;

public class UsuarioServico : IUsuario
{
    public string Salvar(Usuario usuario)
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

    public string CongelarUsuario(long matricula)
    {
        var usuario = Utils.Instance.Usuarios.Find(usuario => usuario.Matricula == matricula);
        
        Utils.Instance.Usuarios.Remove(usuario);
        
        usuario.Congelado = true;
        
        Utils.Instance.Usuarios.Add(usuario);

        return "Usuário congelado com sucesso!";
    }
}