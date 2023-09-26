using GiceleBollmannAPI.Database.Contexto;
using GiceleBollmannAPI.Models;

namespace GiceleBollmannAPI.Database.Repositorio
{
    public class UsuarioRepositorio
    {
        public Usuario Adicionar(Usuario usuario)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                bancoDeDados.USUARIOS.Add(usuario);
                bancoDeDados.SaveChanges();
                return usuario;
            }
        }

        public Usuario Atualizar(Usuario usuario)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                bancoDeDados.USUARIOS.Update(usuario);
                bancoDeDados.SaveChanges();
                return usuario;
            }
        }

        public void Excluir(int id)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.Id == id).FirstOrDefault();

                if (usuario != null)
                {
                    bancoDeDados.Remove(usuario);
                    bancoDeDados.SaveChanges();
                }
            }
        }

        public Usuario ObterPorId(int id)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.Id == id).FirstOrDefault();

                return usuario;
            }
        }

        public List<Usuario> ObterTodos()
        {
            using (var bancoDeDados = new GBcontexto())
            {
                var listaUsuarios = bancoDeDados.USUARIOS.ToList();

                return listaUsuarios;
            }
        }

        public bool ExiteUsuario(string email)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();
                return usuario != null;
            }
        }

        public Usuario ObterPorUserNameOuEmail(string nomeUsuarioOuEmail)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.UserName == nomeUsuarioOuEmail
                                                                     || u.Email == nomeUsuarioOuEmail).FirstOrDefault();
                
                return usuario;
            }
        }
    }
}
