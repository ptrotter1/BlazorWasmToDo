using BlazorWasmToDo.Store.CounterUseCase.Actions;
using Fluxor;

namespace BlazorWasmToDo.Store.CounterUseCase;

// Reducers should be pure functions
public static class Reducers
{
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
        state with
        {
            ClickCount = state.ClickCount + 1
        };
}