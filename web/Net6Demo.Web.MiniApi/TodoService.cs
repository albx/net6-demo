using System.Linq;

namespace Net6Demo.Web.MiniApi
{
    public class TodoService
    {
        private static List<TodoItem> _todos = new();

        private static int _lastId = 0;

        public IEnumerable<TodoItem> GetItems() => _todos.ToArray();

        public Task CreateNewTodo(TodoItem todo)
        {
            todo.Id = ++_lastId;

            _todos.Add(todo);
            return Task.CompletedTask;
        }

        public Task CompleteTodo(int todoId)
        {
            var item = _todos.FirstOrDefault(t => t.Id == todoId);
            if (item == null) throw new ApplicationException();

            item.Completed = true;

            return Task.CompletedTask;
        }

        public TodoItem? GetTodoDetail(int todoId) => _todos.FirstOrDefault(t => t.Id == todoId);
    }
}
