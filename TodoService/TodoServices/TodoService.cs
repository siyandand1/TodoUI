using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using TodoService.TodoServices.TodoVM;

namespace TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly string apiUrl = "https://637b7c7b6f4024eac20efbc7.mockapi.io/ToDo";

        public async Task<TodoVM> getTaskById(int id)
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

        public async Task<List<TodoVM>> getTodos()
        {
            List<TodoVM>  todos = new List<TodoVM>();
            try
            {
                var tasks = await apiUrl.GetJsonAsync<List<Task>>();
                foreach (var task in tasks)
                {
                    TodoVM temp = new TodoVM();
                    temp.Id = task.Id;
                    temp.Title = task.Title;
                    temp.Description = task.Description;
                    temp.Created = DateTime.Parse(task.CreatedAt, null, DateTimeStyles.RoundtripKind);
                    temp.Completed = task.Completed ? "Done" : "Not Done";

                    todos.Add(temp);    
                }
                return todos;
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
