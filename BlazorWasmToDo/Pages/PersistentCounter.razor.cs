using BlazorWasmToDo.Store.PersistentCounterUseCase;
using BlazorWasmToDo.Store.PersistentCounterUseCase.Actions;
using Fluxor;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmToDo.Pages;

[UsedImplicitly]
public partial class PersistentCounter
{
    [Inject] 
    private IState<PersistentCounterState> CounterState { get; set; } = default!;
    
    [Inject]
    public IDispatcher Dispatcher { get; set; } = default!;

    private string UserName { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Dispatcher.Dispatch(new FetchPersistentCounterDataAction());
    }

    private void UserNameChangeHandler(ChangeEventArgs obj)
    {
        var userName = obj.Value?.ToString();
        if (userName == null) return;
        UserName = userName;
    }
    
    private void IncrementCount()
    {
        var action = new IncrementPersistentCounterAction 
        { 
            UserName = UserName,
            NextCount = CounterState.Value.ClickCount + 1
        };
        Dispatcher.Dispatch(action);
    }
}