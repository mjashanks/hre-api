using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hre.Api.Database;
using System.IO;
using Hre.Api.Extensions;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.FileProviders;

namespace Hre.Api.Controllers
{
    [Route("")]
    public class StaticFilesController : Controller
    {

        private byte[] GetResource(string key)
        {
            var assembly = GetType().GetTypeInfo().Assembly;           

            var resourceStream = assembly.GetManifestResourceStream("hre-api.StaticFiles." + key);
            using (var reader = new BinaryReader(resourceStream))
            {
                return reader.ReadBytes((int) resourceStream.Length);
            }            
        }

        [HttpGet]
        public IActionResult GetIndex(string file)
        {
            return File(GetResource("index.html"), "text/html");
        }

        [HttpGet("{file}")]
        public IActionResult GetRootFile(string file)
        {
            return File(GetResource(file), file.AsContentType());
        }

        [HttpGet("scripts/{file}")]
        public IActionResult GetScript(string file)
        {
            return File(GetResource("Scripts."+ file), file.AsContentType());
        }
    }
}