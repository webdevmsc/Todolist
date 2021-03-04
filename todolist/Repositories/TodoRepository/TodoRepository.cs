using todolist.Database;
using todolist.Models.Todo;

namespace todolist.Repositories.TodoRepository
{
    public class TodoRepository : RepositoryBase<TodoItem>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}