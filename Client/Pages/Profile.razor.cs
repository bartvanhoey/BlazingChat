using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazingChat.Client.Pages
{
  public class ProfileBase : ComponentBase
  {
    [Inject] public IProfileViewModel Vm { get; set; }

    protected override async Task OnInitializedAsync() => await Vm.GetProfileAsync();

  }
}