using System.Threading.Tasks;
using BlazingChat.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazingChat.Client.Pages
{
  public class SettingsBase : ComponentBase
  {
    [Inject] public ISettingsViewModel Vm { get; set; }

    protected override async Task OnInitializedAsync() => await Vm.GetProfileAsync();
  }
}