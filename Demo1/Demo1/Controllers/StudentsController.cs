using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static  List<Students> stud = new List<Students>();


        [HttpPost]
        public IActionResult PostStudrecord(int id,string name, string department)
        {
            stud.Add(new Students
            {
                StudId = id,
               StudName = name,
                Department = department
            });
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
            if (IsExist == true)
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
        public IActionResult ModifingRecord(int id,  string name,string department)
        {
            bool IsExist = stud.Contains(stud.Find(studs => studs.StudId.Equals(id)));

            try
            {
                if (IsExist==true)
                {
                   
                    stud.Find (studs => studs.StudId.Equals(id)).StudName = name;

                    return Ok("modified");
                }
                
                else
                {
                    return BadRequest("Incorrect data");
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
