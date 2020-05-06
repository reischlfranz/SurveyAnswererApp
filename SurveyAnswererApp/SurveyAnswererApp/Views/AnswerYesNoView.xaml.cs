using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyAnswererApp.Models.Survey;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AnswerYesNoView : ContentView, IAnswerView
  {
    public Answer Answer { get; set; }

    public AnswerYesNoView(Answer answer)
    {
      BindingContext = this;
      Answer = answer;
      InitializeComponent();
    }


    private void YesButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
      if (((CheckBox)sender).IsChecked)
      {
        // noButton.IsChecked = false;
      }
      Answer.Value = "Yes";
    }

    private void NoButton_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
      if (((CheckBox)sender).IsChecked)
      {
        // yesButton.IsChecked = false;
      }
      Answer.Value = "No";
    }

  }
}

