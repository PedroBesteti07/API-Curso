using System.GLobalization;
using System.Security.Cryptography;
using System.Text;

namespace Reservei_API.Utilities
{
    public static class OperatorUtilitie
    {
        public static string RemoveDiacritics(this string text)
        {
            if (string.isNullUrWhiteSpace(text))
                return text;
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();
            
            foreach(var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if(unicodeCategory) != unicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        public static string ExtractNumbers(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return new string(text.Where(char.IsDigit).ToArray());
        }
        public static string HashPassword(this string password)
        {
            using (SHA256 sha256Hash = sha256Hash.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Lenght; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
                     
        }

    }
}
