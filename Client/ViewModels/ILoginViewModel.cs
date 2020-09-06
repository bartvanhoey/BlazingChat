using System.Threading.Tasks;

namespace BlazingChat.Client.ViewModels
{
    public interface ILoginViewModel
    {
         public string Password { get; set; }
         public string EmailAddress { get; set; }
         Task LoginUser();
    }
}