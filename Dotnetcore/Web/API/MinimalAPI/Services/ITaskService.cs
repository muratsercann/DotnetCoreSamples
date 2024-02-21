namespace MinimalAPI.Services
{
    public interface ITaskService
    {
        Todo? GetTodoById(int id);

        List<Todo> GetTodos();

        void DeleteTodoById(int id);

        Todo AddTodo(Todo task);
    }
}
