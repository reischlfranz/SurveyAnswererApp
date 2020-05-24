using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  class SurveySummaryViewModel
  {

    public Questionnaire Questionnaire { get; set; }
    

    public SurveySummaryViewModel(Questionnaire questionnaire) {
      Questionnaire = questionnaire;
    }

  }
}
