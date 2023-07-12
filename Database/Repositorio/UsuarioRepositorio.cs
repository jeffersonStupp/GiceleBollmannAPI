using ApiCentralPark.Database.Contexto;
using ApiCentralPark.Models;

namespace ApiCentralPark.Database.Repositorio
{
    public class UsuarioRepositorio
    {
        public Usuario Adicionar(Usuario usuario)
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                bancoDeDados.UsuariosDatabase.Add(usuario);
                bancoDeDados.SaveChanges();
                return usuario;
            }
        }

        public Usuario Atualizar(Usuario usuario)
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                bancoDeDados.UsuariosDatabase.Update(usuario);
                bancoDeDados.SaveChanges();
                return usuario;
            }
        }

        public void Excluir(int id)
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                var usuario = bancoDeDados.UsuariosDatabase.Where(u => u.Id == id).FirstOrDefault();

                if (usuario != null)
                {
                    bancoDeDados.Remove(usuario);
                    bancoDeDados.SaveChanges();
                }
            }
        }

        public Usuario ObterPorId(int id)
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                var usuario = bancoDeDados.UsuariosDatabase.Where(u => u.Id == id).FirstOrDefault();

                return usuario;
            }
        }

        public List<Usuario> ObterTodos()
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                var listaUsuarios = bancoDeDados.UsuariosDatabase.ToList();

                return listaUsuarios;
            }
        }

        public bool ExiteUsuario(string email)
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                var usuario = bancoDeDados.UsuariosDatabase.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();
                return usuario != null;
            }
        }

        public Usuario ObterPorNomeOuEmail(string nomeUsuarioOuEmail)
        {
            using (var bancoDeDados = new CentalParkContext())
            {
                var usuario = bancoDeDados.UsuariosDatabase.Where(u => u.NomeUsuario == nomeUsuarioOuEmail
                                                                     || u.Email == nomeUsuarioOuEmail).FirstOrDefault();
                return usuario;
            }
        }
    }
}
