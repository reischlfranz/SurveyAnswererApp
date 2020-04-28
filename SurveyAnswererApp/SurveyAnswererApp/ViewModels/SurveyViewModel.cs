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

    public string SurveyTitle { get; set; }
    public string SurveyDescription { get; set; }

    public SurveyViewModel(Questionnaire questionnaire) {
      Questionnaire = questionnaire;
      
      SurveyTitle = Questionnaire.Title;
      SurveyDescription = Questionnaire.Description;
    }
    
  }
}
