using Google.Protobuf.WellKnownTypes;

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
        public static bool TestConvertToDateOnly(this string date)
        {
            if (DateOnly.TryParse(date, out var s))
            {
                return true;
            }
            return false;
        }
    }
}
