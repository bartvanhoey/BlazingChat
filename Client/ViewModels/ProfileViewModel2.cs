using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.Client.ViewModels
{
  public class ProfileViewModel2 : IProfileViewModel
  {
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Message { get; set; }

    public static implicit operator ProfileViewModel2(User user)
    {
      return new ProfileViewModel2
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        EmailAddress = user.EmailAddress,
        UserId = user.UserId
      };
    }


    public static implicit operator User(ProfileViewModel2 ProfileViewModel2)
    {
      return new User
      {
        FirstName = ProfileViewModel2.FirstName,
        LastName = ProfileViewModel2.LastName,
        EmailAddress = ProfileViewModel2.EmailAddress,
        UserId = ProfileViewModel2.UserId
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