using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiWithPlugins.Biz
{
    [Calculator(Name = "Dummy calculator", Order = 1000)]
    public class DummyCalculator: ICalculator
    {
        public double Calculate()
        {
            return 180.0f;
        }

        public string DisplayValue(double value)
        {
           return "Dummy calculator";
        }

        public bool ReturnsReading { get { return false; } }
        public void SetParameters(string parameters)
        {
            throw new NotImplementedException();
        }
    }
}
