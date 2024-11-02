using Fluxor;
using JetBrains.Annotations;

namespace BlazorWasmToDo.Store.CounterUseCase;

[UsedImplicitly]
[FeatureState]
public record CounterState
{
    public int ClickCount { get; init; }
}