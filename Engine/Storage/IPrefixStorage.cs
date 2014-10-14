namespace Engine.Storage
{
    public interface IPrefixStorage {
        
        /// <summary>
        /// Добавление слова в хранилище
        /// </summary>
        void Add(string word);

        /// <summary>
        /// Поиск слов
        /// </summary>
        /// <param name="prefix">Префикс слова</param>
        /// <param name="count">Максимальное количество возвращаемых слов</param>
        /// <returns>Слова, начинающиеся с префикса</returns>
        string[] Lookup(string prefix, int count = 10);
    }
}
