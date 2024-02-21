using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;
using MinimalAPI.Services;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection (DI)
builder.Services.AddSingleton<ITaskService>(new InMemoryService());

var app = builder.Build();

#region Middlewares

//Redirection
app.UseRewriter(new RewriteOptions().AddRedirect("tasks/(.*)", "todos/$1"));
app.UseRewriter(new RewriteOptions().AddRedirect("tasks", "todos"));

//Custom Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}]");
    await next(context);
    Console.WriteLine($"[{context.Request.Method} {context.Request.Path} {DateTime.UtcNow}]");
});


#endregion #region Middlewares


#region Endpoints for CRUD Operations


var todos = new List<Todo>() { new Todo(1, "Todo 1", DateTime.Today.Date, false) };
app.MapGet("/", () => "Hello World!");

//Get All Todos
app.MapGet("/todos", (ITaskService service) => service.GetTodos());

//Get the todo with id 
app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound>(ITaskService service, int id) =>
{
    var targetTodo = service.GetTodoById(id);
    return targetTodo is null
    ? TypedResults.NotFound()
    : TypedResults.Ok(targetTodo);
});

//Create new Todo
app.MapPost("/todos", (Todo task, ITaskService service) =>
   {
       service.AddTodo(task);
       return TypedResults.Created("/todos/{id}", task);
   }
).AddEndpointFilter(async (context, next) =>
{
    var taskArgument = context.GetArgument<Todo>(0);
    var errors = new Dictionary<string, string[]>();
    if (taskArgument.DueDate < DateTime.UtcNow)
    {
        errors.Add(nameof(taskArgument.DueDate), ["Cannot have due date in the past"]);
    }

    if (taskArgument.IsCompleted)
    {
        errors.Add(nameof(taskArgument.IsCompleted), ["Cannot add completed todo"]);
    }
    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
    }

    return await next(context);
});

//Delete the todo item with id
app.MapDelete("/todos/{id}", (int id, ITaskService service) =>
{
    service.DeleteTodoById(id);
    return TypedResults.NoContent();
});

#endregion Endpoints

app.Run();

public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted);