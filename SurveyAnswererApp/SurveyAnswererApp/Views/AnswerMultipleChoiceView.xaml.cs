using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AnswerMultipleChoiceView : ContentView, IAnswerView {
    public AnswerMultipleChoiceView(Answer answer)
    {
      BindingContext = this;
      Answer = answer;
      InitializeComponent();
    }

    public Answer Answer { get; set; }

    private void MultipleChoiceSelection_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
      //((AnswerViewModel) BindingContext);
      throw new NotImplementedException();

    }
  }
}

