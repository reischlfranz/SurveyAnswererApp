using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  class SurveyDetailViewModel
  {

    public Questionnaire Questionnaire { get; set; }

    public ICommand OpenSurveyCommand { get; set; }
    public ICommand DismissCommand { get; set; }

    public string CreatedDate { get => DateTime.Now.ToString(); }

    public SurveyDetailViewModel(Questionnaire questionnaire) {
      Questionnaire = questionnaire;
      OpenSurveyCommand = new Command((e) => ExecuteOpenSurveyCommand(e, EventArgs.Empty));
      DismissCommand = new Command((e) => ExecuteDismissCommand(e, EventArgs.Empty));
    }

    private void ExecuteOpenSurveyCommand(object sender, EventArgs args)
    {
      App.Instance.SetMainPage(new NavigationPage(new QuestionnairePage(Questionnaire)));
      

    }
    private async void ExecuteDismissCommand(object sender, EventArgs args)
    {
      bool doDismiss;
      doDismiss = await ((Page)sender).DisplayAlert("Are you sure?", "Permanently dismiss this survey? It will not be shown again!", "Yes", "No");

      if (doDismiss)
      {
        // TODO Dismiss the survey
        Questionnaire.SurveyMeta.IsDismissed = true;

        await ((Page)sender).Navigation.PopAsync();
        
        return;
      }      
    }
  }
}
