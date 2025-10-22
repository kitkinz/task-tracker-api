using System.ComponentModel.DataAnnotations;

namespace TaskTrackerAPI.Models;

public class TaskItem
{
    public int Id { get; set; }
    [StringLength(50)]
    public required string Title { get; set; } = "";
    [StringLength(100)]
    public string Description { get; set; } = "";
    public bool IsCompleted { get; set; } = false;
}