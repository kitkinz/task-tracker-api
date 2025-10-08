using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Services;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class TaskItemController : ControllerBase
{
    private readonly TaskItemService _taskItemService;
    public TaskItemController(TaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    [HttpGet]
    public IEnumerable<TaskItem> GetTaskItems()
    {
        var results = TaskItemService.GetAll();
        return results;
    }

    [HttpGet("{id}")]
    public TaskItem GetTaskItem(int id)
    {
        var item = TaskItemService.Get(id);

        if (item is null)
        {
            throw new Exception("Task not found.");
        }

        return item;
    }

    [HttpPost]
    public int AddTaskItem(TaskItem taskItem)
    {
        var itemId = TaskItemService.AddTaskItem(taskItem);
        return itemId;
    }

    [HttpDelete("{id}")]
    public void DeleteTaskItem(int id)
    {
        TaskItemService.DeleteTaskItem(id);
        Console.WriteLine("Task successfully deleted.");
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateTaskItem(TaskItem taskItem, int id)
    {
        taskItem.Id = id;

        TaskItemService.UpdateTaskItem(taskItem);
        return NoContent();
    }
}