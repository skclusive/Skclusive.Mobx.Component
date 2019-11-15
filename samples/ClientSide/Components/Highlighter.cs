using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;

namespace ClientSide.Components
{
    public class Highlighter : PureComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private int renderCount = 0;

        private bool IsEven => renderCount % 2 == 0;

        private string Highlight => $"highlight highlight-{(IsEven ? "even" : "odd")}";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            renderCount++;

            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", Highlight);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
