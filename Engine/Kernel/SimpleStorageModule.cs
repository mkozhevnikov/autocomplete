using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Storage;
using Ninject.Modules;

namespace Engine.Kernel
{
    class SimpleStorageModule : NinjectModule
    {
        public override void Load() {
            Bind<IPrefixStorage>().To<DictionaryStorage>();
        }
    }
}
