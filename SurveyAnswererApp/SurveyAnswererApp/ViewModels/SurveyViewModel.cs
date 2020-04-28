using System;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.ViewModels {
  public class SurveyViewModel : BaseViewModel {

    // private Questionnaire _questionnaire;
    public Questionnaire Questionnaire{ 
      get => App.Instance.Model.CurrentQuestionnaire; 
      set => App.Instance.Model.CurrentQuestionnaire = value ?? throw new ArgumentNullException(); 
    }

    // Note: Assigning (empty) not-null string during declaration prevents
    // App from crashing!
    public string SurveyTitle { get; set; }
    public string SurveyDescription { get; set; }

    public SurveyViewModel() {
      // Get a dummy item for now
      Questionnaire = DummySurveyFactory.GetSurvey();
      RaiseAllPropertiesChanged();

      SurveyTitle = Questionnaire.Title;
      SurveyDescription = Questionnaire.Description;
    }

    public SurveyViewModel(Questionnaire questionnaire) {
      Questionnaire = questionnaire;
      
      SurveyTitle = Questionnaire.Title;
      SurveyDescription = Questionnaire.Description;
    }
    
  }
}
