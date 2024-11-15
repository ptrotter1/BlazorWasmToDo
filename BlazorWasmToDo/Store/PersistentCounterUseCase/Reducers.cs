using BlazorWasmToDo.Store.PersistentCounterUseCase.Actions;
using Fluxor;

namespace BlazorWasmToDo.Store.PersistentCounterUseCase;

public static class Reducers
{
    [ReducerMethod]
    public static PersistentCounterState ReduceIncrementCounterAction(PersistentCounterState state, 
        IncrementPersistentCounterAction action) 
        => state with
        {
            IsSaving = true,
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
        => state with
        {
            ClickCount = action.Data.ClickCount,
            UserName = action.Data.UserName,
            IsLoading = false,
            ErrorMessage = string.Empty
        };
    
    [ReducerMethod]
    public static PersistentCounterState ReduceFetchPersistentCounterDataFailureAction(PersistentCounterState state,
        FetchPersistentCounterDataFailureAction action)
        => state with
        {
            ErrorMessage = action.Error.ToString(),
            IsLoading = false
        };

    [ReducerMethod]
    public static PersistentCounterState ReduceSavePersistentCounterDataSuccessAction(PersistentCounterState state,
        SavePersistentCounterDataSuccessAction action)
        => state with
        {
            IsSaving = false
        };

    [ReducerMethod]
    public static PersistentCounterState ReduceSavePersistentCounterDataFailureAction(PersistentCounterState state,
        SavePersistentCounterDataFailureAction action)
        => state with
        {
            IsSaving = false,
            ErrorMessage = action.Error.ToString()
        };
}