namespace MyChest.Extensions
{
    public static class StringExtensions
    {        /// <summary>
             /// Representa a extensão de métodos para a classe string.
             /// </summary>
             /// 
             /// <summary>
             /// Converte uma string para um inteiro de 32 bits.
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
    }
}
