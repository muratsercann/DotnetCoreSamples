using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


#region Endpoints for CRUD Operations
var todos = new List<Todo>() { new Todo(1, "Todo 1", DateTime.Today.Date, false) };
app.MapGet("/", () => "Hello World!");

//Get All Todos
app.MapGet("/todos", () => todos);

//Get the todo with id 
app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int id) =>
{
    var targetTodo = todos.SingleOrDefault(t => t.Id == id);
    return targetTodo is null
    ? TypedResults.NotFound()
    : TypedResults.Ok(targetTodo);
});

//Create new Todo
app.MapPost("/todos", (Todo task) =>
   {
       todos.Add(task);
       return TypedResults.Created("/todos/{id}", task);
   }
);

//Delete the todo item with id
app.MapDelete("/todos/{id}", (int id) =>
{
    todos.RemoveAll(t => t.Id == id);
    return TypedResults.NoContent();
});

#endregion Endpoints

app.Run();

public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted);