using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.Client.ViewModels
{
  public class ProfileViewModel : IProfileViewModel
  {
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Message { get; set; }

    public static implicit operator ProfileViewModel(User user)
    {
      return new ProfileViewModel
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        EmailAddress = user.EmailAddress,
        UserId = user.UserId
      };
    }


    public static implicit operator User(ProfileViewModel profileViewModel)
    {
      return new User
      {
        FirstName = profileViewModel.FirstName,
        LastName = profileViewModel.LastName,
        EmailAddress = profileViewModel.EmailAddress,
        UserId = profileViewModel.UserId
      };
    }

    public void UpdateProfile()
    {
    //   User user = Vm;
    //   HttpResponseMessage httpResponseMessage = await HttpClient.PutAsJsonAsync($"api/users/{10}", user);
      this.Message = "Profile updated successfully";
    }

    public void GetProfile()
    {
      //Vm = await HttpClient.GetFromJsonAsync<User>($"api/users/{10}");
      this.Message = "Profile loaded successfully";
    }
  }
}