using System;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Model;

namespace ToDoApi.Data
{
    public class TodoContext:DbContext
    {

        public DbSet<ToDo> ToDos { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=todo.db;");

        //}
    }
}

