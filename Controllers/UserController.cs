using Microsoft.AspNetCore.Mvc;
using Part_3_Lesson_4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part_3_Lesson_4.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepositories userRepositories;
        public UserController(UserRepositories user)
        {
            userRepositories = user;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res=await userRepositories.GEt();
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User newUser)
        {
            await userRepositories.Add(newUser);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
           
            await userRepositories.Ubdate(user);
            return NoContent();
        
        }

        [HttpDelete]
        [Route("{userid}")]
        public async Task<IActionResult> Delet(int id)
        {
            await userRepositories.Delete(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
