using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqlLite")));


// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.MapGet("api/todo", async (TodoContext db) => {

    var items = await db.ToDos.ToListAsync();

    return Results.Ok(items);

});

app.MapGet("/", () => "Hello World!");

app.MapGet("api/todo/{id}", async (TodoContext db, int id) => {

    var items = await db.ToDos.Where(i=>i.Id==id).ToListAsync();

    return Results.Ok(items);

});

app.MapPost("api/todo", async (TodoContext db, ToDo item) =>
{
    
    await db.ToDos.AddAsync(item);
    await db.SaveChangesAsync();
    return Results.Created($"api/todo/{item.Id}", item);


});




app.Run();


