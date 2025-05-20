using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.data;
using api.Mappers;
using api.Models;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context){
            _context = context;
       }

       [HttpGet]
       public  IActionResult GetUsers(){
        
        var users = _context.Users.ToList().Select(u=>u.ToUserDto());
        return Ok(users);
       }

       [HttpGet("{id}")]

       public IActionResult GetUserById([FromRoute] int id){
        var user = _context.Users.Find(id);
        if(user == null){
            return NotFound();
        }
        return Ok(user.ToUserDto());
       }

       [HttpPost]
       public IActionResult CreateUser([FromBody] User user)
       {
           _context.Users.Add(user);
           _context.SaveChanges();
           return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
       }

       [HttpPut("{id}")]
       public IActionResult UpdateUser([FromRoute] int id, [FromBody] User user)
       {
           var existingUser = _context.Users.Find(id);
           if (existingUser == null)
           {
               return NotFound();
           }
           existingUser.Name = user.Name;
           existingUser.Age = user.Age;
           existingUser.Email = user.Email;
           _context.SaveChanges();
           return Ok(existingUser);
       }
    }}
