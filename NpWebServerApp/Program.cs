var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{id?}", (int? id) => 
{
    if (id is null)
        return Results.BadRequest(new { Message = "Incorrect Id" });
    else if (id != 10)
        return Results.NotFound(new { Message = $"Employee with id {id} not found" });
    else
        return Results.Json(new Employee() { Id = 10, Name = "Bobby", Age = 25 });
});

app.Run();

class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
