namespace MyChest.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converte uma string para um int32 bits.
        /// </summary>
        /// <param name="text">Parâmetro esperado para converter em int</param>
        /// <returns>Retorna o valor "text" convertido em int</returns>
        public static int ConvertToInt32(this string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                return Convert.ToInt32(text);
            }
            return 0;
        }

        /// <summary>
        /// Verifica se a string passada pode ser convertida para int32 bits
        /// </summary>
        /// <param name="text">Valor string passado como parâmetro de verificação</param>
        /// <returns>Retorna true caso a string puder ser convertida caso contrario retorna false</returns>
        public static bool TestConvertToInt32(this string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (int.TryParse(text , out int num))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se a string passada pode ser convertida para DateOnly
        /// </summary>
        /// <param name="date">Valor string passado como parâmetro de verificação</param>
        /// <returns>Retorna true caso a string puder ser convertida caso contrario retorna false</returns>
        public static bool TestConvertToDateOnly(this string date)
        {
            if (DateOnly.TryParse(date, out var s))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retorna a string contida entre 2 do caractere especificado.
        /// </summary>
        /// <param name="text">String que será feita a procura</param>
        /// <param name="character">caracter selecioando para procurar entre</param>
        /// <returns>Retorna o valor que foi encontrado</returns>
        public static string GetStringBetweenCharacter(this string text, char character)
        {
            int startIndex = text.IndexOf(character) + 1;
            int finalIndex = text.LastIndexOf(character);

            if (startIndex > 0 && finalIndex > startIndex)
            {
                return text.Substring(startIndex, finalIndex - startIndex);
            }
            return string.Empty;
        }
    }
}
