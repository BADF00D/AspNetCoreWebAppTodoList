using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAppTodoList.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AspNetCoreWebAppTodoList
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITodoContext>().ImplementedBy<TodoContext>().LifestyleSingleton());
            container.Register(Component.For<IVoltageContext>().ImplementedBy<VoltageContext>().LifestyleSingleton());
        }
    }
}
