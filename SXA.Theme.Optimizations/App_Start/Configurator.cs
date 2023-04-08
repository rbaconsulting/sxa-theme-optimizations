using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using SXA.Theme.Optimizations.Interfaces;
using SXA.Theme.Optimizations.Services;

namespace SXA.Theme.Optimizations.App_Start
{
    public class Configurator : IServicesConfigurator
    {
		public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IScriptOptimizer, ScriptOptimizer>();
		}
    }
}