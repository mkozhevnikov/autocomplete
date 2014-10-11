namespace Engine.Storage
{
    public interface IPrefixStorage {
        
        void Add(string wordLine);

        string[] Lookup(string prefix, int count = 10);
    }
}
