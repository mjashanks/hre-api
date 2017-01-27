using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hre.Api.Database;
using Hre.Api.Models;

namespace Hre.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<List<User>> Get()
        {
            using(var conn = await SqlConnectionFactory.Create())
            {
                return await conn.GetAllUsers();
            }
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            using (var conn = await SqlConnectionFactory.Create())
            {
                return await conn.GetUser(id);                    
            }
        }

        [HttpPost("{id}")]
        public async Task Post(int id, [FromBody]User user)
        {
            using (var conn = await SqlConnectionFactory.Create())
            {
                user.Id = id;
                await conn.UpdateUser(user);
            }
        }

    }
}
