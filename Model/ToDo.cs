using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Model
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string? ToDoName { get; set; }
    }
}

