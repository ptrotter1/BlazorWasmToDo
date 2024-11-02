using BlazorWasmToDo.Services;
using BlazorWasmToDo.Services.Models;
using BlazorWasmToDo.Store.CounterUseCase;
using BlazorWasmToDo.Store.PersistentCounterUseCase.Actions;
using CSharpFunctionalExtensions;
using Fluxor;

namespace BlazorWasmToDo.Store.PersistentCounterUseCase;

public class Effects
{
    private readonly IPersistentCounterDataService _persistentCounterDataService;

    public Effects(IPersistentCounterDataService persistentCounterDataService)
    {
        _persistentCounterDataService = persistentCounterDataService;
    }
    
    [EffectMethod]
    public async Task HandleFetchPersistentCounterDataAction(FetchPersistentCounterDataAction action, IDispatcher dispatcher)
    {
        await _persistentCounterDataService.GetPersistentCounterData()
            .Tap(data => dispatcher.Dispatch(new FetchPersistentCounterDataSuccessAction(data)))
            .TapError(error => dispatcher.Dispatch(new FetchPersistentCounterDataFailureAction(error)));
    }

    [EffectMethod]
    public async Task HandleIncrementPersistentCounterAction(IncrementPersistentCounterAction action,
        IDispatcher dispatcher)
    {
        await MapActionToCounterData(action)
            .Tap(data => _persistentCounterDataService.SavePersistentCounterData(data))
            .MapError(error => new SavePersistentCounterDataFailureAction(error));
    }

    private static Result<CounterData, Error> MapActionToCounterData(IncrementPersistentCounterAction action)
    {
        try
        {
            return new CounterData
            {
                ClickCount = action.NextCount,
                UserName = action.UserName
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Error { Code = "CouldNotMap", Message = e.Message };
        }
    }
}