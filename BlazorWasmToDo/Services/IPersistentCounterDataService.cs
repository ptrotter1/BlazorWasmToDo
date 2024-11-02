using BlazorWasmToDo.Services.Models;
using CSharpFunctionalExtensions;

namespace BlazorWasmToDo.Services;

public interface IPersistentCounterDataService
{
    Task<Result<CounterData, Error>> GetPersistentCounterData();
    Task<UnitResult<Error>> SavePersistentCounterData(CounterData data);
}