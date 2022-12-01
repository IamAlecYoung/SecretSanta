using Microsoft.AspNetCore.Components;
using SecretSanta.Core.Domain.Contexts;

namespace SecretSanta.Web.State
{
    public partial class CascadingAppState
    {
        [Inject]
        public Core.Domain.Contexts.SantaContext db { get; set; }
        
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}