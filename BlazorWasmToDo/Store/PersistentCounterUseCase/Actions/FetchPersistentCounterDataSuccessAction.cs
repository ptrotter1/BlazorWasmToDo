using BlazorWasmToDo.Services.Models;

namespace BlazorWasmToDo.Store.PersistentCounterUseCase.Actions;

public record FetchPersistentCounterDataSuccessAction(CounterData Data);