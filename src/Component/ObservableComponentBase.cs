using System;
using Microsoft.AspNetCore.Components;
using Skclusive.Mobx.Observable;

namespace Skclusive.Mobx.Component
{
    public class ObservableComponentBase : PureComponentBase, IDisposable
    {
        private Reaction _reaction;

        protected RenderFragment _baseRenderFragment;

        public ObservableComponentBase()
        {
            _reaction = new Reaction("Observable", (_1) =>
            {
                StateHasChanged();
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

        protected virtual void Dispose()
        {
        }

        void IDisposable.Dispose()
        {
            _reaction?.Dispose();

            _reaction = null;

            Dispose();
        }
    }
}
