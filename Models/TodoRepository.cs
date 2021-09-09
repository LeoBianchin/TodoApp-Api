using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace TodoApp.Models.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public int AddTodo(TodoItem todo)
        {
            if (_context.TodoItem.Where(t => t.Id == todo.Id).Any())
            {
                return -1;
            }

            _context.TodoItem.Add(todo);
            return _context.SaveChanges();
        }

        public bool CompleteTodo(int id)
        {
            var todo = _context.TodoItem.Where(t => t.Id == id).FirstOrDefault();

            if(todo == null)
            {
                return false;
            }

            todo.IsCompleted = true;
            _context.TodoItem.Update(todo);
            _context.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            var todo = _context.TodoItem.Where(t => t.Id == id).FirstOrDefault();

            if(todo == null)
            {
                return;
            }

            _context.TodoItem.Remove(todo);
            _context.SaveChanges();
        }

        public TodoItem Find(int id)
        {
            return _context.TodoItem.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            var list = await _context.TodoItem.ToListAsync();
            return list.AsEnumerable(); 
        }
    }

}