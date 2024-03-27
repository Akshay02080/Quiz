using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherRepository;

namespace TeacherServices
{
    public class Services:IServices
    {
        private readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }
        /*Repository repository = new Repository();*/

        public async Task<Quiz> Addquizzes(Quiz Q)
        {
            return await _repository.Addquizzes(Q);
        }
        public async Task<List<Quiz>> Getquizzes()
        {
            return await _repository.Getquizzes();
        }
    }
}
