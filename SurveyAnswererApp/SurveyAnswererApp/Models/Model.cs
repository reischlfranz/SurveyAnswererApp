using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.Models {
  public class Model {

    public Questionnaire CurrentQuestionnaire{ get; set; } 
    
    public ObservableCollection<Questionnaire> Surveys { get; } = new ObservableCollection<Questionnaire>();
    
    public static Model Instance { get; } = new Model();

    private Model() {
      
      ReadRestSurvey();
      
      for (int i = 0; i < 4; i++) {
        Surveys.Add(DummySurveyFactory.GetSurvey());
      }
      
    }

    private async Task ReadRestSurvey() {
      var _client = new HttpClient();
      _client.BaseAddress = new Uri("http://www.birnbaua.at/jku/");
      try {
        Task<Stream> httpGetTask = _client.GetStreamAsync("questionnaires");
        var surveys = await JsonSerializer.DeserializeAsync<List<Questionnaire>>(await httpGetTask);
        foreach (var survey in surveys) {
          Surveys.Add(await ReadSurvey(survey.Id));
        }
      }
      catch (Exception e) {
        Console.WriteLine(e);
        throw;
      }
    }

    private async Task<Questionnaire> ReadSurvey(long id) {
      var _client = new HttpClient();
      _client.BaseAddress = new Uri("http://www.birnbaua.at/jku/");
      try {
        Task<Stream> httpGetTask = _client.GetStreamAsync("questionnaires/" + id);

        var survey = await JsonSerializer.DeserializeAsync<Questionnaire>(await httpGetTask);
        return survey;
      }
      catch (Exception e) {
        Console.WriteLine(e);
        throw;
        return null;
      }
    }
    
    
  }
}
