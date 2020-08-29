using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Services;
using Xamarin.Forms;

namespace SurveyAnswererApp.Models {
  public class Model {

    public Questionnaire CurrentQuestionnaire{ get; set; } 
    
    public ObservableCollection<Questionnaire> Surveys { get; } = new ObservableCollection<Questionnaire>();
    
    public static Model Instance { get; } = new Model();

    private Model() {
      DependencyService.Get<IMessageToast>().ShortAlert("Model created");

      for (int i = 0; i < 4; i++) {
        Surveys.Add(DummySurveyFactory.GetSurvey());
      }

      // Add history
      for (int i = 0; i < 2; i++) {
        var historySurvey = DummySurveyFactory.GetSurvey();
        historySurvey.SurveyMeta.IsCompleted = true;
        historySurvey.SurveyMeta.SentDate = DateTime.Now;
        historySurvey.SurveyMeta.FirstRetrievalTime = DateTime.Now.Subtract(TimeSpan.FromDays(2));
        Surveys.Add(historySurvey);
      }
    }

    public void UpdateFromRest()
    {
      Thread readThread = new Thread(() => ReadFromRest());
      readThread.Start();      
    }


    private async void ReadFromRest() {
      Xamarin.Forms.Device.BeginInvokeOnMainThread(()=> DependencyService.Get<IMessageToast>().LongAlert("Reading REST... please wait"));
      try {
        var surveyHotFixRestReader = new RestReader<QuestionnaireRestHotfix>(
              new Uri("http://www.birnbaua.at/jku/questionnaires/"));
        var surveyRestReader = new RestReader<Questionnaire>(
              new Uri("http://www.birnbaua.at/jku/questionnaires/"));
        var surveys = surveyHotFixRestReader.ReadMany("").Result;
        foreach (var survey in surveys) {
          var ns = surveyRestReader.ReadSingle(survey.Id.ToString()).Result;

          // Retrieval date
          ns.SurveyMeta.FirstRetrievalTime = DateTime.Now;

          // TODO Skip if already in cache and ns.SurveyMeta.IsCompleted

          foreach (var question in ns.Questions) {
            if (question.QuestionType == QuestionType.YES_NO) {
              // Yes/No hotfix
              question.QuestionType = QuestionType.SINGLE_CHOICE;
            }
          }

          if (!Surveys.Any(s => s.Id == ns.Id)) {
            Surveys.Add(ns);
          }

          Thread.Sleep(500); // Add a delay for visual feedback
          Xamarin.Forms.Device.BeginInvokeOnMainThread(()=> DependencyService.Get<IMessageToast>().ShortAlert("REST update complete 💪"));
        }
      }

      catch (Exception e) {
        Xamarin.Forms.Device.BeginInvokeOnMainThread(()=> DependencyService.Get<IMessageToast>().LongAlert("REST connection failed :("));
        Console.Error.WriteLine(e.Message);
      }
    }
  }
}
