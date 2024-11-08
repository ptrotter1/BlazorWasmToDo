using BlazorWasmToDo.Store.CounterUseCase;
using BlazorWasmToDo.Store.CounterUseCase.Actions;
using Fluxor;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmToDo.Components;

[UsedImplicitly]
public partial class Counter
{
    [Inject] 
    private IState<CounterState> CounterState { get; set; } = default!;

    [Inject] 
    public IDispatcher Dispatcher { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
    
    private void IncrementCount()
    {
        var action = new IncrementCounterAction();
        Dispatcher.Dispatch(action);
    }
}

