﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  public class QuestionViewModel : BaseViewModel
  {
    public Question Question { get; set; }

    public bool YesNoAnswerYesSelection;
    public bool YesNoAnswerNoSelection;

    internal List<AnswerViewModel> AnswerViewModels = new List<AnswerViewModel>();

    public ICommand ValueEnteredCommand;


    internal void UpdateSingleChoiceSelection(AnswerViewModel sender)
    {
      if (Question.QuestionType == QuestionType.SINGLE_CHOICE)
      {
        foreach (var answerViewModel in AnswerViewModels)
        {
          if (answerViewModel != sender)
          {
            answerViewModel.SingleChoiceAnswerSelection = false;
          }
        }

      }
    }


    public void AddAnswerViews(StackLayout answerDataLayout)
    {
      foreach (var answer in Question.Answers)
      {
        var answerView = GetAnswerView(answer);
        answerDataLayout.Children.Insert(answerDataLayout.Children.Count, (View) answerView);
      }
    }

    private IAnswerView GetAnswerView(Answer answer)
    {
      var answerViewModel = new AnswerViewModel(this)
      {
        Answer = answer
      };
      switch (Question.QuestionType)
      {
        case QuestionType.YES_NO:
          return new AnswerYesNoView(answer) {BindingContext = answerViewModel};
          break; 
        case QuestionType.SINGLE_CHOICE:
          return new AnswerSingleChoiceView(answer) {BindingContext = answerViewModel};
          break;
        case QuestionType.MULTIPLE_CHOICE:
          return new AnswerMultipleChoiceView(answer) {BindingContext = answerViewModel};
          break;
        case QuestionType.RATING:
          return new AnswerRatingView(answer) {BindingContext = answerViewModel};
          break;
        case QuestionType.NUMBER:
        return new AnswerNumberView(answer){BindingContext = answerViewModel};
        break;
        case QuestionType.OPEN:
          return new AnswerTextEntryView(answer) {BindingContext = answerViewModel};
          break;
        default:
          throw new NotImplementedException();
      }
    }
  }
}