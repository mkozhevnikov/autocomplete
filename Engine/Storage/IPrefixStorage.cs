namespace Engine.Storage
{
    public interface IPrefixStorage {
        
        void Add(string word);

        string[] Lookup(string prefix, int count = 10);
    }
}
