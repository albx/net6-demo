using Microsoft.AspNetCore.Http;

namespace Net6Demo.Web.MiniApi
{
    public static class TodoEndpoints
    {
        public static IResult GetAllTodos(TodoService services)
        {
            var todos = services.GetItems();
            return Results.Ok(todos);
        }

        public static IResult GetTodoDetail(TodoService service, int id)
        {
            if (id <= 0)
            {
                return Results.BadRequest("Invalid id");
            }

            var todo = service.GetTodoDetail(id);
            if (todo == null) return Results.NotFound();

            return Results.Ok(todo);
        }
    }
}
