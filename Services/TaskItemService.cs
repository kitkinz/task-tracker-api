using Microsoft.EntityFrameworkCore;
using TaskTrackerAPI.Data;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services;

public class TaskItemService
{
    private readonly AppDbContext _dbContext;
    static List<TaskItem> TaskItems { get; set; }
    // static int taskId = 2;

    static TaskItemService()
    {
        TaskItems = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Clean room", Description = "Sweep the floor", IsCompleted = false }
        };
    }

    public TaskItemService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get all tasks
    public async Task<IEnumerable<TaskItem>> GetAll() => await _dbContext.TaskItems.ToListAsync();

    // Returns a task by ID, or null if not found
    public async Task<TaskItem?> Get(int id)
    {
        return await _dbContext.TaskItems.FindAsync(id);
    }

    // Add a task (cloud)
    public async Task<TaskItem> AddTaskItem(TaskItem taskItem)
    {
        _dbContext.TaskItems.Add(taskItem);
        await _dbContext.SaveChangesAsync();

        return taskItem;
    }

    // Delete a task
    public async Task<bool> DeleteTaskItem(int id)
    {
        var result = await _dbContext.TaskItems.Where(item => item.Id == id).ExecuteDeleteAsync();
        return result > 0;
    }

    // Update a task
    public async Task<TaskItem?> UpdateTaskItem(TaskItem taskItem)
    {
        _dbContext.TaskItems.Update(taskItem);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0 ? taskItem : null;
    }
}