using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly string apiUrl = "https://637b7c7b6f4024eac20efbc7.mockapi.io/ToDo";

        public async Task<Task> getTaskById(int id)
        {
            try
            {
                var task = await getTodos();
                return task.FirstOrDefault(s => s.Id == id.ToString());
            }
            catch (FlurlHttpException ex)
            {
                // Handle error
                
                return null;
            }
        }

        public async Task<List<Task>> getTodos()
        {
            try
            {
                var tasks = await apiUrl.GetJsonAsync<List<Task>>();
                return tasks;
            }
            catch (FlurlHttpException ex)
            {
                // Handle error
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
