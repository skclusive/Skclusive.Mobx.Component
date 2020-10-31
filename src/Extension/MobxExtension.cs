using Microsoft.Extensions.DependencyInjection;
using Skclusive.Extensions.DependencyInjection;
using Skclusive.Core.Component;

namespace Skclusive.Mobx.Component
{
    public static class MobxExtension
    {
        public static void TryAddMobxServices(this IServiceCollection services, ICoreConfig coreConfig)
        {
            services.TryAddScopedEnumerable<IComponentConfigurer, MobxComponentConfigurer>();

            services.TryAddCoreServices(coreConfig);
        }
    }
}
