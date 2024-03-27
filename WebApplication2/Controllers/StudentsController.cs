/*using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        //StudentLogic studentLogic = new StudentLogic();
        private readonly IStudentLogic _studentLogic;

        public StudentsController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }

        [HttpGet("{rollNo}")]
        public ActionResult<string> GetStudentName(int rollNo)
        {
            var studentName = _studentLogic.GetStudentNameByRollNo(rollNo);

            if (studentName == null)
            {
                return NotFound();
            }

            return Ok(studentName);
        }

        [HttpGet]
        [Route("GetStudentsList")]
        public ActionResult<string[]> GetStudentsList()
        {
            var students = _studentLogic.GetStudentsList();
            return Ok(students);
        }
    }
}
*/