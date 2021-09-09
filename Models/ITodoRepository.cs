using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace TodoApp.Models.Repository
{
    public interface ITodoRepository
    {        
        int AddTodo(TodoItem todo);
        Task<IEnumerable<TodoItem>> GetAll();
        TodoItem Find(int id);
        void Delete(int id);
        bool CompleteTodo(int id);
    }
}