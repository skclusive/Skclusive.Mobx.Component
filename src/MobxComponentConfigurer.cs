using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Mobx.Observable;

namespace Skclusive.Mobx.Component
{
    public class MobxComponentConfigurer : IComponentConfigurer
    {
        public (IDisposable, RenderFragment) Configure(RenderFragment renderFragment, Func<Task> renderer)
        {
            var reaction = new Reaction("Observable", (_1) =>
            {
                _ = renderer();
            },
            (ex, _) =>
            {
                throw new Exception("Observable component exception", ex);
            });

            RenderFragment newRenderFragment = builder =>
            {
                reaction.Track(() =>
                {
                    return Actions.AllowStateChanges<object>(false, () =>
                    {
                        renderFragment(builder);

                        return null;
                    });
                });
            };

            return (reaction, newRenderFragment);
        }
    }
}
