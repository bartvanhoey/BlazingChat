using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels
{
    public class ContactsViewModel : IContactsViewModel
    {
        //properties
        public List<Contact> Contacts { get; set; }
        private HttpClient _httpClient;

        //methods
        public ContactsViewModel()
        {
        }
        public ContactsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task GetContacts()
        {
            List<User> users = await _httpClient.GetFromJsonAsync<List<User>>("user/getcontacts");
            LoadCurrentObject(users);
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>("contacts/getvisiblecontacts?startIndex=0&count=10");
            LoadCurrentObject(users);
            return Contacts;

        }

        // public async Task<List<Contact>> GetVisibleContactsOnly(int startIndex, int numberOfUsers)
        // {
        //     var users = await _httpClient.GetFromJsonAsync<List<User>>($"user/getonlyvisiblecontacts?startIndex={startIndex}&count={numberOfUsers}");
        //     LoadCurrentObject(users);
        //     return Contacts;
        // }

        public async Task<int> GetContactsCount() => await _httpClient.GetFromJsonAsync<int>($"contacts/getcontactscount");


        public async Task<List<Contact>> GetVisibleContacts(int startIndex, int count)
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>($"contacts/getvisiblecontacts?startIndex={startIndex}&count={count}");

            LoadCurrentObject(users);
            return Contacts;
        }

        private void LoadCurrentObject(List<User> users)
        {
            Contacts = new List<Contact>();
            foreach (var user in users) Contacts.Add(user);
        }


    }
}
