using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoService.TodoServices.TodoVM;

namespace TodoServices
{
    public interface ITodoService
    {
        Task<List<TodoVM>> getTodos();

        Task<TodoVM> getTaskById(int id);

    }
}
