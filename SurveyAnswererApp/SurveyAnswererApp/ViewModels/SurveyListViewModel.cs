﻿using System;
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
    public ObservableCollection<Questionnaire> Surveys { get; set; } =new ObservableCollection<Questionnaire>();

    public SurveyListViewModel()
    {
      PopulateSurveyList();
    }

    private void PopulateSurveyList()
    {
      // populate survey list TODO Merge primary model
      //foreach (var s in App.Instance.Model.Surveys)
      //{
      //  Surveys.Add(s);
      //}

      // Populate with dummy data for now
      Surveys.Add(DummySurveyFactory.GetSurvey());
      Surveys.Add(DummySurveyFactory.GetSurvey());
      Surveys.Add(DummySurveyFactory.GetSurvey());
      Surveys.Add(DummySurveyFactory.GetSurvey());
      Surveys.Add(DummySurveyFactory.GetSurvey());

      // TODO Raise property changed?
    }

  }
}
