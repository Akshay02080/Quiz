using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace TeacherServices
{
    public interface IServices
    {
        public Task<Quiz> Addquizzes(Quiz Q);
        public Task<List<Quiz>> Getquizzes();
    }
}
