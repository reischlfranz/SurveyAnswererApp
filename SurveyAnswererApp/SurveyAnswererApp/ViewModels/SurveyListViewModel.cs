using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  public class SurveyListViewModel : BaseViewModel
  {
    public ObservableCollection<Questionnaire> Surveys { get; set; }

    public SurveyListViewModel()
    {

      // foreach (var survey in Model.Instance.Surveys) {
      //   Surveys.Add(survey);
      // }

      Surveys = Model.Instance.Surveys;

      
    }


    
  }
}
