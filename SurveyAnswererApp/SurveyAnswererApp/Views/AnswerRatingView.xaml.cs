﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyAnswererApp.Models.Survey;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AnswerRatingView : ContentView, IAnswerView {
    public AnswerRatingView(Answer answer)
    {
      BindingContext = this;
      Answer = answer;
      InitializeComponent();
    }

    public Answer Answer { get; set; }
  }
}

