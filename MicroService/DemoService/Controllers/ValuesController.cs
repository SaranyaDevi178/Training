using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoService.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       
        [HttpGet(Name = "GetDate")]
       
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }


    }
}
