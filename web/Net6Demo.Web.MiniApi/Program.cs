using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Net6Demo.Web.MiniApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TodoService>();

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/todos", TodoEndpoints.GetAllTodos)
    .WithName("GetTodos")
    .WithGroupName("v1");

app.MapGet("/todos/{id}", TodoEndpoints.GetTodoDetail)
    .WithName("GetTodoDetail")
    .WithGroupName("v1");

app.MapPost(
    "/todos",
    async (TodoService service, TodoItem todo) =>
    {
        await service.CreateNewTodo(todo);
        return Results.Created($"/todos/{todo.Id}", todo);
    })
    .ProducesValidationProblem();

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

app.UseSwaggerUI();
await app.RunAsync();
