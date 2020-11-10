using System;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Mobx.Observable;

namespace Skclusive.Mobx.Component
{
    public class ObservableComponentBase : PureComponentBase
    {
        private Reaction _reaction;

        protected RenderFragment _baseRenderFragment;

        public ObservableComponentBase()
        {
            _reaction = new Reaction("Observable", (_1) =>
            {
                _ = InvokeAsync(StateHasChanged);
            },
            (_1, _2) =>
            {
                throw new Exception("Observable component exception");
            }
            );

            _baseRenderFragment = _renderFragment;

            _renderFragment = builder =>
            {
                _reaction.Track(() =>
                {
                    return Actions.AllowStateChanges<object>(false, () =>
                    {
                        _baseRenderFragment(builder);

                        return null;
                    });
                });
            };
        }

        protected override void Dispose()
        {
            _reaction?.Dispose();

            _reaction = null;
        }
    }
}
