using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Skclusive.Mobx.Component
{
    public class Observable : ObservableComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            ChildContent?.Invoke(builder);
        }
    }
}
