using System;
using System.Collections.Generic;
using System.Text;

using Autofac;

namespace Scz.Autofac
{
   public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder,ITypeFinder finder);
        int Order { get; }
    }
}
