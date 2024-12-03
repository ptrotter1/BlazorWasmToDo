using System.ComponentModel.DataAnnotations;
using BlazorWasmToDo.Attributes;

namespace BlazorWasmToDo.Pages.ToDo.Models;

public class ToDoFormModel
{
    [Required]
    [Length(1, 10, ErrorMessage = "Title must be between 1 and 10 characters")]
    public string Text { get; set; } = string.Empty;
    
    [Required]
    [FutureDateTimeOffset]
    public DateTimeOffset? DueDate { get; set; }
}