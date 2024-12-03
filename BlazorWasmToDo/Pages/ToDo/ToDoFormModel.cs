using System.ComponentModel.DataAnnotations;

namespace BlazorWasmToDo.Pages.ToDo;

public class ToDoFormModel
{
    public string Text { get; set; } = string.Empty;
    
    public DateTimeOffset? DueDate { get; set; }
}