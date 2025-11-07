using System.Globalization;
using System.Text;

namespace El_Ahogado.Server.utils
{
    public static class WordUtils
    {
        public static string ConvertToMasked(string word)
        {
            var x = new StringBuilder();
         
            var mask = "";
            foreach(var c in word)
            {

                x.Append("_");
            }
            return x.ToString();

        }

        public static string RemoveAccents(string texto)
        {
            // Normaliza el texto para separar las letras de los acentos
            string normalizado = texto.Normalize(NormalizationForm.FormD);

            // Construye una nueva cadena omitiendo los caracteres de marca (acentos)
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalizado)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Vuelve a la forma normal (sin combinaciones)
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
