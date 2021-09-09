using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using TodoApp.Models.Repository;

namespace TodoApp.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _repository;

        public TodoController(ILogger<TodoController> logger, ITodoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repository.GetAll();
            return Ok(list);
        }

        [HttpPatch]
        public IActionResult Complete(int id)
        {
            var ret = _repository.CompleteTodo(id);

            return ret ? Ok() : BadRequest("Erro ao completar Todo");
        }

        [HttpGet]
        public IActionResult GetTodo(int id)
        {
            var todo = _repository.Find(id);

            if (todo == null)
            {
                return BadRequest($"Não foi possível localizar Id:[{id}]");
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoItem todo)
        {
            var ret = _repository.AddTodo(todo);

            if (ret == -1)
            {
                return BadRequest("Erro ao salvar Todo");
            }

            return Ok(_repository.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}
