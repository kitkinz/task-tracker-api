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
    public async Task<IEnumerable<TaskItem>> GetTaskItems()
    {
        var results = await _taskItemService.GetAll();
        return results;
    }

    [HttpGet("{id}")]
    public async Task<TaskItem> GetTaskItem(int id)
    {
        var item = await _taskItemService.Get(id);

        if (item is null)
        {
            throw new Exception("Task not found.");
        }

        return item;
    }

    [HttpPost]
    public async Task<TaskItem> AddTaskItem(TaskItem taskItem)
    {
        var item = await _taskItemService.AddTaskItem(taskItem);
        return item;
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteTaskItem(int id)
    {
        var result = await _taskItemService.DeleteTaskItem(id);
        Console.WriteLine(result ? "Task successfully deleted." : "Failed to delete Task.");

        return result;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult?> UpdateTaskItem(TaskItem taskItem, int id)
    {
        taskItem.Id = id;

        await _taskItemService.UpdateTaskItem(taskItem);
        return NoContent();
    }
}