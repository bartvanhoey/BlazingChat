﻿using BlazingChat.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazingChat.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingChat.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly ILogger<UsersController> _logger;
    private readonly BlazingChatContext _context;

    public UsersController(ILogger<UsersController> logger, BlazingChatContext context)
    {
      _context = context;
      _logger = logger;
    }

    [HttpGet("getcontacts")]
    public List<Contact> GetContacts()
    {
      List<User> users = _context.Users.ToList();
      List<Contact> contacts = new List<Contact>();
      foreach (var user in users)
        contacts.Add(new Contact { FirstName = user.FirstName, LastName = user.LastName });
      return contacts;
    }

    [HttpGet("getprofile/{userId:int}")]
    public async Task<User> GetProfile(int userId)
    {
      return await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
    }

    [HttpPut("updateprofile/{userId:int}")]
    public async Task<User> UpdateProfile(int userId, [FromBody] User user)
    {
      var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
      if (userToUpdate != null)
      {
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.EmailAddress = user.EmailAddress;
        await _context.SaveChangesAsync();
      }
      return await Task.FromResult(user);
    }

    [HttpGet("updatetheme")]
    public async Task<User> UpdateTheme(string userId, string value)
    {
      User user = _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefault();
      user.DarkTheme = value == "True" ? 1 : 0;

      await _context.SaveChangesAsync();

      return await Task.FromResult(user);
    }

    [HttpGet("updatenotifications")]
    public async Task<User> UpdateNotifications(string userId, string value)
    {
      User user = _context.Users.Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefault();
      user.Notifications = value == "True" ? 1 : 0;

      await _context.SaveChangesAsync();

      return await Task.FromResult(user);
    }
  }
}
