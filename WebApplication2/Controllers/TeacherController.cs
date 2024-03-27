using Microsoft.AspNetCore.Mvc;
using Common.Model;
using TeacherServices;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TeacherController: ControllerBase
    {
        private readonly IServices _services;
        public TeacherController(IServices services)
        {
            _services = services;
        }
        /*Services services = new Services();*/
        [HttpPost]
        [Route("AddQuizzes")]
        public async  Task<Quiz> Addquizzes(Quiz Q)
        {
           return await _services.Addquizzes(Q);  
        }
        [HttpGet]
        [Route("GetQuizzes")]
        public async Task<List<Quiz>> Getquizzes()
        {
            return await _services.Getquizzes();

        }
    }
}
