using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Services;

namespace SurveyAnswererApp.Models {
  public class Model {

    public Questionnaire CurrentQuestionnaire{ get; set; } 
    
    public ObservableCollection<Questionnaire> Surveys { get; } = new ObservableCollection<Questionnaire>();
    
    public static Model Instance { get; } = new Model();

    private Model() {

      for (int i = 0; i < 4; i++) {
        Surveys.Add(DummySurveyFactory.GetSurvey());
      }

    }

    public void Wrapper()
    {
      Thread readThread = new Thread(() => ReadFromRest());
      readThread.Start();      
    }


    private async void ReadFromRest()
    {
      Thread.Sleep(5000);
      var surveyHotFixRestReader = new RestReader<QuestionnaireRestHotfix>(
          new Uri("http://www.birnbaua.at/jku/questionnaires/"));
      var surveyRestReader = new RestReader<Questionnaire>(
          new Uri("http://www.birnbaua.at/jku/questionnaires/"));
      var surveys = surveyHotFixRestReader.ReadMany("").Result;
      foreach (var survey in surveys)
      {
        var ns = surveyRestReader.ReadSingle(survey.Id.ToString()).Result;
        ns.SurveyMeta.FirstRetrievalTime = DateTime.Now;

        foreach (var question in ns.Questions) {
          if (question.QuestionType == QuestionType.YES_NO) {
            // Yes/No hotfix
            question.QuestionType = QuestionType.SINGLE_CHOICE;
          }
        }

        if (!Surveys.Any(s => s.Id == ns.Id))
        {
          Surveys.Add(ns);
        }

        Thread.Sleep(2000); // Add a delay for visual feedback

      }
    }

  }
}
