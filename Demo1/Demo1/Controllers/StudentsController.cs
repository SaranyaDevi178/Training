using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static  List<Students> stud = new List<Students>();
       
         public static List<Department> dep = DepartmentController.dep;
       

        [HttpPost]
        public IActionResult PostStudrecord(int id,string name,int depeid)
        {
            bool IsExist = dep.Any(x => x.DepartmentId == depeid);
            if (IsExist)
            {
                stud.Add(new Students
                {
                    StudId = id,
                    StudName = name,
                    Depid = depeid

                });

            }
            else
            {
                return BadRequest("Incorrect data");
            }
            return Ok("Added");
        }

        [HttpGet]
        public IEnumerable<Students> Getdata()
        {
            return stud;
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            bool IsExist = stud.Contains(stud.Find(studs => studs.StudId.Equals(id)));
            if (IsExist)
            {
                stud.Remove(stud.Find(studs => studs.StudId.Equals(id)));
                return Ok("deleted");
            }
            else
            {
                return BadRequest("Request Not processed");
            }
        }

        [HttpPut]
        public IActionResult ModifingRecord(int id,  string name)
        {
            bool IsExist = stud.Contains(stud.Find(studs => studs.StudId.Equals(id)));

            if(!IsExist)
            {
                return BadRequest("incorrect data");
            }
            try
            {
                if (IsExist)
                {
                   
                    stud.Find (studs => studs.StudId.Equals(id)).StudName = name;

                    return Ok("modified");
                }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok("modified");
           
        }


    }
}
