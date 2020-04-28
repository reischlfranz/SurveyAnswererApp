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

    public SurveyDetailViewModel()
    {
      OpenSurveyCommand = new Command((e) => ExecuteOpenSurveyCommand(e, EventArgs.Empty));
    }

    private void ExecuteOpenSurveyCommand(object sender, EventArgs args)
    {
      //throw new NotImplementedException();
      App.Instance.MainPage = new NavigationPage(new QuestionnairePage());

    }
  }
}
