namespace ToDoAPI.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using System.Collections.Generic;
  using System.Linq;
  using Models;

  [Route("api/[controller]")]
  [ApiController]
  public sealed class ToDoItemController : ControllerBase
  {
    private static readonly HashSet<ToDoItemModel> _toDoItems = new(new[]
    {
      new ToDoItemModel { Id = 1, Description = "First description", IsCompleted = true },
      new ToDoItemModel { Id = 2, Description = "Second description", IsCompleted = false },
      new ToDoItemModel { Id = 3, Description = "Third description", IsCompleted = false },
      new ToDoItemModel { Id = 4, Description = "Fourth description", IsCompleted = false },
    });

    // GET: api/ToDoItem
    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemModel>> GetAll()
    {
      return Ok(_toDoItems.OrderBy(item => item.Id));
    }

    // GET: api/ToDoItem/5
    [HttpGet("{id}")]
    public ActionResult<ToDoItemModel> Get(int id)
    {
      var toDoItemModel = _toDoItems.FirstOrDefault(item => item.Id == id);
      if (toDoItemModel is null)
      {
        return NotFound();
      }

      return toDoItemModel;
    }

    // POST: api/ToDoItem
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<ToDoItemModel> Create(ToDoItemModel toDoItemModel)
    {
      toDoItemModel.Id = _toDoItems.Any() ? _toDoItems.Max(item => item.Id) + 1 : 0;
      _toDoItems.Add(toDoItemModel);

      return Ok();
    }

    // PUT: api/ToDoItem
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    public ActionResult<ToDoItemModel> Update(ToDoItemModel toDoItemModel)
    {
      var updateModel = _toDoItems.FirstOrDefault(item => item.Id == toDoItemModel.Id);
      if (updateModel is null)
      {
        return NotFound();
      }

      _toDoItems.Remove(updateModel);
      _toDoItems.Add(toDoItemModel);

      return Ok();
    }

    // DELETE: api/ToDoItem/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var toDoItemModel = _toDoItems.FirstOrDefault(item => item.Id == id);
      if (toDoItemModel is null)
      {
        return NotFound();
      }

      _ = _toDoItems.RemoveWhere(item => item.Id == id);

      return Ok();
    }
  }
}
