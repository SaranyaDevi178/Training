using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Addingservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        public static List<DemoClass> obj = new List<DemoClass>();
        [HttpPost (Name = "PostData")]
        
        public IActionResult PostData(DemoClass objs)
        {
            obj.Add(new DemoClass()
            {
                Id = objs.Id,
                Name = objs.Name,
                Address = objs.Address
            });
            return Ok("Added");
        }

        [HttpPut (Name ="PutData")]
        public IActionResult putData(int id,string name)
            {

            bool IsExist = obj.Contains(obj.Find(X => X.Id.Equals(id)));

            if (!IsExist)
            {
                return BadRequest("incorrect data");
            }
            try
            {
                if (IsExist)
                {

                    obj.Find(x => x.Id.Equals(id)).Name = name;

                    return Ok("modified");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("modified");

            
        }

        [HttpGet(Name = "GetData")]
      
        public IEnumerable<DemoClass> GetData()
        {
            return obj;
        }
    }
}
