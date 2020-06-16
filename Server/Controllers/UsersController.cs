using BlazingChat.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazingChat.Server.Models;

namespace BlazingChat.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> _logger;
    private readonly BlazingChatContext _context;

    public UsersController(ILogger<UsersController> logger, BlazingChatContext context)
    {
      _context = context;
      _logger = logger;
    }

    [HttpGet]
    public List<Contact> Get()
    {

      List<User> users = _context.Users.ToList();
      List<Contact> contacts = new List<Contact>();

    foreach (var user in users)
    {
        contacts.Add(new Contact { FirstName = user.FirstName, LastName = user.LastName});
    }

return contacts;

    }
  }
}
