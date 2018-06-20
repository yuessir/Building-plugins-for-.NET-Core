using Microsoft.Extensions.DependencyInjection;

namespace WebApiWithPlugins.Biz
{
    public static class CalculatorExtensions
    {
        public static void AddCalculators(this IServiceCollection services)
        {
            foreach(var calcType in CalculatorsLoader.CalculatorTypes)
            {
                services.AddTransient(calcType);
            }
        }
    }
}
