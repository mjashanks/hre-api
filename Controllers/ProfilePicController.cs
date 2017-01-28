using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hre.Api.Database;
using System.IO;

namespace Hre.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProfilePicController : Controller
    {       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var conn = await SqlConnectionFactory.Create())
            {
                var profilePic = await conn.GetProfilePic(id);
                return File(profilePic.Pic, "image/jpeg");
            }
        }
/*
        [HttpPost("{id}")]
        public async Task Post(int id, [FromBody]byte[] pic)
        {
            using (var conn = await SqlConnectionFactory.Create())
            {
                await conn.SetProfilePic(id, pic);
            }
        }*/

        [HttpPost("{id}")]
        public async Task Post(int id)
        {
            var httpRequest = HttpContext.Request;

            var file = httpRequest.Form.Files[0];
            var stream = file.OpenReadStream();
            var picByt = new byte[stream.Length];

            using (BinaryReader br = new BinaryReader(stream))
            {
                picByt = br.ReadBytes((int)stream.Length);
            }

            using (var conn = await SqlConnectionFactory.Create())
            {
                await conn.SetProfilePic(id, picByt);
            }
        }

    }
}
