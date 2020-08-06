using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.Client.ViewModels
{
  public class ContactsViewModel : IContactsViewModel
  {
    public List<Contact> Contacts { get; set; }
    private HttpClient _httpClient;

    public ContactsViewModel()
    {
    }
    public ContactsViewModel(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public async Task GetContactsAsync()
    {
      List<User> users = await _httpClient.GetFromJsonAsync<List<User>>("api/users/getcontacts");
      LoadCurrentObject(users);
    }

    private void LoadCurrentObject(List<User> users)
    {
      Contacts = new List<Contact>();
      foreach (User user in users)
      {
        Contacts.Add(user);
      }
    }
  }
}