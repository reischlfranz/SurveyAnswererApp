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
  public partial class AnswerFactoryView : ContentView {
    public AnswerFactoryView() {
      try {
        Question c = new Question();
        
        
        
        Console.Out.WriteLine("");
      }
      catch (Exception e) {
        Console.WriteLine(e);
        throw;
      }
      InitializeComponent();
    }
  }
}

