using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net6Demo.Web.MiniApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TodoService>();

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet(
    "/todos", 
    (Func<TodoService, IEnumerable<TodoItem>>)(([FromServices]service) => service.GetItems()));

app.MapGet(
    "/todos/{id}",
    (Func<TodoService, int, TodoItem>)(([FromServices] service, id) => service.GetTodoDetail(id)));

app.MapPost(
    "/todos",
    (Func<TodoService, TodoItem, Task<TodoItem>>)(async ([FromServices]service, [FromBody]todo) =>
    {
        await service.CreateNewTodo(todo);
        return todo;
    }));

app.MapPut(
    "/todos/{id}",
    (Func<TodoService, int, Task>)(async ([FromServices] service, id) =>
    {
        await service.CompleteTodo(id);
    }));

await app.RunAsync();
