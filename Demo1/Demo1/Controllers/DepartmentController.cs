using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public static List<Department> dep = new List<Department>();
        

        [HttpPost]
        public IActionResult PostDeprecord(int did, string dname)
        {
            dep.Add(new Department
            {
                 DepartmentId = did,    
                 DepartmentName = dname
               
            });
         
            return Ok("Added");
        }

        [HttpPost]
        [Route("postJson")]
        public IActionResult PostsDeprecord([FromBody] Department deps)
        
        {
            bool IsExist= dep.Any(z=>z.DepartmentId.Equals(deps.DepartmentId));
            if(IsExist)
            {
                return BadRequest("Incorrect");
            }
            try
            {
                
                dep.Add(new Department
                {
                    DepartmentId = deps.DepartmentId,
                    DepartmentName = deps.DepartmentName

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Added");
        }


        [HttpGet]
        public IEnumerable<Department> GetDepadata()
        {
            return dep;
        }
        [HttpDelete]
        public IActionResult deletedepid(int id)
        {
            bool IsExist = dep.Contains(dep.Find(studs => studs.DepartmentId.Equals(id)));
            if (IsExist == true)
            {
                dep.Remove(dep.Find(studs => studs.DepartmentId.Equals(id)));
                return Ok("deleted");
            }
            else
            {
                return BadRequest("Request Not processed");
            }
        }

        [HttpPut]
        public IActionResult ModifingdepRecord(int id, string name)
        {
            bool IsExist = dep.Contains(dep.Find(studs => studs.DepartmentId.Equals(id)));
            if(!IsExist)
            {
                return BadRequest("Incorrect data");
            }
            try
            {
                if (IsExist == true)
                {

                    dep.Find(studs => studs.DepartmentId.Equals(id)).DepartmentName= name;

                    return Ok("modified");
                }

               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("modified");

        }


    }
}
    

