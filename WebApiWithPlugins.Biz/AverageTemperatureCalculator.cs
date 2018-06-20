
namespace WebApiWithPlugins.Biz
{
    [Calculator(Name = "Average temperature", Order = 1000)]
    public class AverageTemperatureCalculator : ICalculator
    {
        public AverageTemperatureCalculator()
        {
        }

        public bool ReturnsReading
        {
            get { return true; }
        }

        public double Calculate()
        {
            return 30.0f;
        }

        public string DisplayValue(double value)
        {
            return value.ToString();
        }

        public void SetParameters(string parameters)
        {
        }
    }
}
