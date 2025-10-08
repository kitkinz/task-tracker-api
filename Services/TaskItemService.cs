using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services;

public class TaskItemService
{
    static List<TaskItem> TaskItems { get; set; }
    static int taskId = 2;

    static TaskItemService()
    {
        TaskItems = new List<TaskItem>
        {
            new TaskItem {Id = 1, Title = "Clean room", Description = "Sweep the floor", IsCompleted = false }
        };
    }

    // Get all tasks
    public static List<TaskItem> GetAll() => TaskItems;

    // Returns a task by ID, or null if not found
    public static TaskItem? Get(int id) => TaskItems.FirstOrDefault(taskItem => taskItem.Id == id);

    // Add a task
    public static int AddTaskItem(TaskItem taskItem)
    {
        taskItem.Id = taskId++;
        TaskItems.Add(taskItem);
        return taskItem.Id;
    }

    // Delete a task
    public static void DeleteTaskItem(int id)
    {
        var taskItem = Get(id);
        if (taskItem is null)
        {
            return;
        }
        TaskItems.Remove(taskItem);
    }

    // Update a task
    public static void UpdateTaskItem(TaskItem taskItem)
    {
        int idx = TaskItems.FindIndex(task => task.Id == taskItem.Id);

        if (idx == -1)
        {
            return;
        }

        TaskItems[idx] = taskItem; 
    }
}