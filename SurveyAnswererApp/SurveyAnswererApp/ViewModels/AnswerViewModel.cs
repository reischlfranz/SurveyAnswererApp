using System;
using System.Collections.Generic;
using System.Text;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.ViewModels
{
  class AnswerViewModel : BaseViewModel
  {
    private QuestionViewModel _questionViewModel;
    public Answer Answer { get; set; }

    public bool YesNoAnswerYesSelection { get; set; }
    public bool YesNoAnswerNoSelection { get; set; }

    public bool SingleChoiceAnswerSelection { get; set; }

    public string FreeFormAnswerText { get; set; }

    public int RatingAnswerValue { get; set; }
    public int NumberAnswerValue { get; set; }

    public AnswerViewModel(QuestionViewModel questionViewModel)
    {
      _questionViewModel = questionViewModel;

    }






  }
}
