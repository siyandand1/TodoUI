using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoService.TodoServices.TodoVM
{
    public class TodoVM
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Completed { get; set; }
    }
}
