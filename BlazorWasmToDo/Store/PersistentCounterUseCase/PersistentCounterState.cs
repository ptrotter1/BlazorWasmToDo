using Fluxor;
using JetBrains.Annotations;

namespace BlazorWasmToDo.Store.PersistentCounterUseCase;

[UsedImplicitly]
[FeatureState]
public record PersistentCounterState
{
    public int ClickCount { get; init; }
    public bool IsLoading { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string ErrorMessage { get; init; } = string.Empty;
}