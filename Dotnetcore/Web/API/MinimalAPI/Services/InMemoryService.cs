using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace MinimalAPI.Services
{
    public class InMemoryService : ITaskService
    {
        private readonly List<Todo> _todos = [];

        public InMemoryService()
        {
            if (_todos.Count == 0)
            {
                SeedData();
            }

        }

        private void SeedData()
        {
            for (int i = 0; i < 10; i++)
            {
                _todos.Add(new Todo(
                        i + 1,
                        $"Task {i + 1}",
                        DateTime.UtcNow.AddDays(i + 5),
                        false)
                );
            }
        }
        public Todo AddTodo(Todo task)
        {
            _todos.Add(task);
            return task;
        }

        public void DeleteTodoById(int id)
        {
            _todos.RemoveAll(task => task.Id == id);
        }

        public Todo? GetTodoById(int id)
        {
            return _todos.SingleOrDefault(t => t.Id == id);
        }

        public List<Todo> GetTodos()
        {
            return _todos;
        }
    }
}
