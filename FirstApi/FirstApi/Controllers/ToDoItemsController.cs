using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApi.Data;
using FirstApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        //private readonly MyBaseContext _context;
        private readonly ITodoItemRepository _repo;

        public ToDoItemsController(ITodoItemRepository repo)
        {
            _repo = repo;
        }

        // GET: api/ToDoItems
        [HttpGet]
       // [Authorize]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
        {
            var todos = await _repo.GetTodos();
            return todos.ToList();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
            var toDoItem = await _repo.GetTodoByID(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       // [Authorize(Roles="admin")]
        public async Task<IActionResult> PutToDoItem(long id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            await _repo.UpdateToDoItem(toDoItem);

            try
            {
                await _repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
   //     [Authorize(Roles = "admin")]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            await _repo.AddToDoItem(toDoItem);
            await _repo.Save();

            return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
  //      [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteToDoItem(long id)
        {
            var toDoItem = await _repo.GetTodoByID(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            await _repo.DeleteToDoItem(toDoItem.Id);
            await _repo.Save();

            return NoContent();
        }

        private bool ToDoItemExists(long id)
        {
            return _repo.GetTodoByID(id) is not null;
        }
    }
}
