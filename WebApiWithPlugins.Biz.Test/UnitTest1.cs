using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiWithPlugins.Biz.Test
{
    [TestClass]
    public class UnitTest1
    {
       
        public ICalculator _ucenterService;
        public IServiceProvider _serviceProvider;
        public int serviceCount;
        public UnitTest1()
        {
            IServiceCollection services = new ServiceCollection();
          
            services.AddSingleton<ICalculatorProvider, CalculatorProvider>();
            services.AddCalculators();
            serviceCount = services.Count;
            _serviceProvider = services.BuildServiceProvider();

        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(serviceCount,3);
            Assert.IsNotNull(_serviceProvider);
            _ucenterService = _serviceProvider.GetService<DummyCalculator>();
            Assert.IsInstanceOfType(_ucenterService, typeof(DummyCalculator));
            _ucenterService = _serviceProvider.GetService<AverageTemperatureCalculator>();
            Assert.IsInstanceOfType(_ucenterService, typeof(AverageTemperatureCalculator));
        }

    }
}
