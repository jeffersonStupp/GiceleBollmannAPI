using System.Globalization;
using System.Text.RegularExpressions;

namespace ApiCentralPark.Database.Repositorio.Helpers
{
    public class Helper
    {


        public static string RemoverCaracteres(string nome)
        {
            return nome = Regex.Replace(nome, @"[^a-zA-Z0-9\s]", "");
        }

        public static string TitleCase(string nome)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return nome = textInfo.ToTitleCase(nome);
        }

        public static bool EmailValido(string email)
        {
            try
            {
                var endemail = new System.Net.Mail.MailAddress(email);
                return endemail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string FormatarTelefone(string telefone)
        {
            return telefone = telefone.Insert(0, "(").Insert(3, ")").Insert(9, "-");
        }


    }
}
