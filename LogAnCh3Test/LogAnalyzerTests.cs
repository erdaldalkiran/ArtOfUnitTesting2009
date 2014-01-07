using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnCh3Test
{
    using Autofac;
    using Autofac.Core;

    using LogAnCh3;

    using NUnit.Framework;

    [TestFixture]
    public class LogAnalyzerTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StubFileExtensionManager>().As<IFileExtensionManager>().InstancePerLifetimeScope();
            builder.RegisterType<LogAnalyzer>().AsSelf();
            _container = builder.Build();

        }

        [Test]
        public void IsValidFileName_ValidName_ReturnsTrue()
        {
            using (var lifeTimeScope = _container.BeginLifetimeScope())
            {
                var logAnalyzer = lifeTimeScope.Resolve<LogAnalyzer>();
                Assert.IsTrue(logAnalyzer.IsValidFileName("whatever.slf"), "Always returns true");
            }
            
            //var logAnalyzer = _container.Resolve<LogAnalyzer>();
            //Assert.IsTrue(logAnalyzer.IsValidFileName("whatever.slf"), "Always returns true");
        }
    }
}
