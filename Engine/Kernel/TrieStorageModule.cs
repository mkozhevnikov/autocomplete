using Engine.Storage;
using Ninject.Modules;

namespace Engine.Kernel {

    class TrieStorageModule : NinjectModule
    {
        public override void Load() {
            Bind<IPrefixStorage>().To<CacheTrieStorage>();
        }
    }
}