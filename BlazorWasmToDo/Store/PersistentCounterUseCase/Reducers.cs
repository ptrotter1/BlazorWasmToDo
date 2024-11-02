using BlazorWasmToDo.Services.Models;
using BlazorWasmToDo.Store.PersistentCounterUseCase.Actions;
using CSharpFunctionalExtensions;
using Fluxor;

namespace BlazorWasmToDo.Store.PersistentCounterUseCase;

public static class Reducers
{
    [ReducerMethod]
    public static PersistentCounterState ReduceIncrementCounterAction(PersistentCounterState state, 
        IncrementPersistentCounterAction action) 
        => state with
        {
            ClickCount = state.ClickCount + 1,
            UserName = action.UserName
        };

    [ReducerMethod]
    public static PersistentCounterState ReduceFetchPersistentCounterDataAction(PersistentCounterState state,
        FetchPersistentCounterDataAction action) 
        => state with
        {
            ErrorMessage = string.Empty,
            IsLoading = true
        };

    [ReducerMethod]
    public static PersistentCounterState ReduceFetchPersistentCounterDataSuccessAction(PersistentCounterState state,
        FetchPersistentCounterDataSuccessAction action)
        => MapPersistentCounterDataToState(action.Data)
            .MapError(msg => new PersistentCounterState { ErrorMessage = msg.ToString() })
            .Finally(msg => msg.Value);

    private static Result<PersistentCounterState, Error> MapPersistentCounterDataToState(CounterData counterData)
    {
        try
        {
            return new PersistentCounterState
            {
                ClickCount = counterData.ClickCount,
                UserName = counterData.UserName,
                IsLoading = false,
                ErrorMessage = string.Empty
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Error { Code = "CouldNotMap", Message = e.Message };
        }
    }
    
    [ReducerMethod]
    public static PersistentCounterState ReduceFetchPersistentCounterDataFailureAction(PersistentCounterState state,
        FetchPersistentCounterDataFailureAction action)
        => state with
        {
            ErrorMessage = action.Error.ToString(),
            IsLoading = false
        };
}