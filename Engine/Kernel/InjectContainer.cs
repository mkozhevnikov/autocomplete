using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace Engine.Kernel
{
    class InjectContainer {
        
        private static StandardKernel _instance;

        public static void Init(NinjectModule config) {
            _instance = new StandardKernel(config);
        }

        public static StandardKernel Instance {
            get { return _instance ?? (_instance = new StandardKernel(new TrieStorageModule())); }
        }
    }
}
