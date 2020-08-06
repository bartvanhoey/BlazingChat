using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingChat.Client.ViewModels
{
  public interface IContactsViewModel
  {
    public List<Contact> Contacts { get; set; }
    public Task GetContactsAsync();
  }
}