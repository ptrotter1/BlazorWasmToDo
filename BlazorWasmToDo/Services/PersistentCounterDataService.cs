using Blazored.LocalStorage;
using BlazorWasmToDo.Services.Models;
using CSharpFunctionalExtensions;

namespace BlazorWasmToDo.Services;

public class PersistentCounterDataService : IPersistentCounterDataService
{
    private readonly ILocalStorageService _localStorageService;
    
    public PersistentCounterDataService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<Result<CounterData, Error>> GetPersistentCounterData()
    {
        CounterData data;
        try
        {
            // Simulate a network delay
            await Task.Delay(500);
            data = await _localStorageService.GetItemAsync<CounterData>("MyKey") ?? 
                   new CounterData();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Error { Code = "CouldNotRetrieve", Message = ex.Message };
        }

        return data;
    }

    public async Task<UnitResult<Error>> SavePersistentCounterData(CounterData data)
    {
        try
        {
            // Simulate a network delay
            await Task.Delay(250);
            
            // Test throwing an Exception
            //throw new Exception("Something went wrong");
            
            await _localStorageService.SetItemAsync("MyKey", data);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Error { Code = "CouldNotSave", Message = ex.Message };
        }

        return UnitResult.Success<Error>();
    }
}