namespace MyChest.Interfaces
{
    interface IData <T>
    {
        /// <summary>
        /// Pesquisa todos os dados do tipo T no banco de dados
        /// </summary>
        /// <returns>Retorna a lista de todos os dados</returns>
        List<T> GetAllData();

        /// <summary>
        /// Pesquisa um dado do tipo T pelo ID
        /// </summary>
        /// <param name="id">Retorna o obj do tipo T pesquisado</param>
        /// <returns></returns>
        T GetById(int id);
    }
}
