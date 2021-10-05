using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
    (TodoService services) =>
    {
        var todos = services.GetItems();
        return Results.Ok(todos);
    });

app.MapGet(
    "/todos/{id}",
    (TodoService service, int id) =>
    {
        if (id <= 0)
        {
            return Results.BadRequest("Invalid id");
        }

        var todo = service.GetTodoDetail(id);
        if (todo == null) return Results.NotFound();

        return Results.Ok(todo);
    });

app.MapPost(
    "/todos",
    async (TodoService service, TodoItem todo) =>
    {
        if (string.IsNullOrWhiteSpace(todo.Title))
        {
            return Results.BadRequest("Invalid data");
        }

        await service.CreateNewTodo(todo);
        return Results.Created($"/todos/{todo.Id}", todo);
    }).RequireAuthorization();

app.MapPut(
    "/todos/{id}",
    async (TodoService service, int id) =>
    {
        if (id <= 0)
        {
            return Results.BadRequest("Invalid id");
        }

        await service.CompleteTodo(id);
        return Results.NoContent();
    });

await app.RunAsync();
