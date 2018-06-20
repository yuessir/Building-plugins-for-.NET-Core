using System;
using System.Collections.Generic;

namespace WebApiWithPlugins.Biz
{
    public interface ICalculatorProvider
    {
        IDictionary<string, ICalculator> GetCalculators();
        IEnumerable<string> GetNames();
        IEnumerable<Type> GetTypes();
    }
}
