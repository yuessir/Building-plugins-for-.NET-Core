

namespace WebApiWithPlugins.Biz
{
    public interface ICalculator
    {
        double Calculate();
        string DisplayValue(double value);
        bool ReturnsReading { get; }
        void SetParameters(string parameters);
    }
}
