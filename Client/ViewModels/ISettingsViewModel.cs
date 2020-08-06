using System.Threading.Tasks;

namespace  BlazingChat.Client.ViewModels
{   
    public interface ISettingsViewModel
    {
         public bool Notifications { get; set; }
         public bool DarkTheme { get; set; }

         public Task SaveAsync();
         public Task GetProfileAsync();
    }
}