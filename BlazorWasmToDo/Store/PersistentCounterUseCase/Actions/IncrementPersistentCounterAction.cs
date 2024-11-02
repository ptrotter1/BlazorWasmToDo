namespace BlazorWasmToDo.Store.PersistentCounterUseCase.Actions;

public record IncrementPersistentCounterAction
{
    public string UserName { get; init; } = string.Empty;
    public int NextCount { get; init; }
};