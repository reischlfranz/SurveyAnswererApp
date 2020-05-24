using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SurveyAnswererApp.Services
{
  class RestReader<T>
  {

    private Uri baseAddress;
    private readonly HttpClient _client = new HttpClient();

    public RestReader(Uri baseAddress)
    {
      this.baseAddress = baseAddress;
      _client.BaseAddress = this.baseAddress;
      
      
    }

    public Task<List<T>> ReadMany()
    {
      return ReadMany(String.Empty);
    }

    public async Task<List<T>> ReadMany(string url)
    {
      try
      {
        Task<Stream> httpGetTask = _client.GetStreamAsync(url);
        var results = JsonSerializer.DeserializeAsync<List<T>>(httpGetTask.GetAwaiter().GetResult());
        return results.GetAwaiter().GetResult();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public async Task<T> ReadSingle(string url)
    {
      try
      {
        Task<Stream> httpGetTask = _client.GetStreamAsync(url);
        var result = JsonSerializer.DeserializeAsync<T>(httpGetTask.GetAwaiter().GetResult())
              .GetAwaiter()
              .GetResult();
        return result;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}