using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoService.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string GetToken()
        {

            return DateTime.Now.ToString();
        }
    }


}

