using Common.Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;


namespace TeacherRepository
{
    public interface IRepository { 
     
        public Task<Quiz> Addquizzes(Quiz Q);
        public Task<List<Quiz>> Getquizzes();

    }
    public class Repository:IRepository
    {


        /* public List<Quiz> que = new List<Quiz>();*/
        private readonly Microsoft.Azure.Cosmos.Container _container;
        public Repository(Microsoft.Azure.Cosmos.Container container)
        {
            _container = container;
        }
        public async Task<Quiz> Addquizzes(Quiz Q)
        {

            /*que.Add(Q);
            return que;*/

            ItemResponse<Quiz> response = await _container.CreateItemAsync(Q);
            return response.Resource;

        }
        /*public List<Quiz> Getquizzes()
        {
            return new List<Quiz>(que);
        }*/
        public async Task<List<Quiz>> Getquizzes()
        {
            List<Quiz> quizzes = new List<Quiz>();

            // Query to get all items from the container
            using (FeedIterator<Quiz> resultSetIterator = _container.GetItemQueryIterator<Quiz>("SELECT * FROM c"))
            {
                while (resultSetIterator.HasMoreResults)
                {
                    Microsoft.Azure.Cosmos.FeedResponse<Quiz> response = await resultSetIterator.ReadNextAsync();
                    quizzes.AddRange(response);
                }
            }

            return quizzes;
        }

    }
}
