using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoServices
{
    public interface ITodoService
    {
        Task<List<Task>> getTodos();

        Task<Task> getTaskById(int id);

    }
}
