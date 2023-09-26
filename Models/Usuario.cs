namespace GiceleBollmannAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string Tipo { get; set; } //'administrador' ou 'usuario'
    }
}
