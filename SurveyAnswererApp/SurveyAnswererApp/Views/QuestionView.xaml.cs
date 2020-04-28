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
  public partial class QuestionView : ContentView {

    public QuestionView() {
      InitializeComponent();
      
      
      //this.TestAnswerViewCell.Content = new AnswerMultipleChoiceView();

      //var x = this.AnswerDataLayout.BindingContext;
      foreach (var v in this.AnswerDataLayout.Children)
      {
        Console.Out.WriteLine("####################################");
        Console.Out.WriteLine("QuestionView::CTOR");
        Console.Out.WriteLine("####################################");
        Console.Out.WriteLine(v.GetType().FullName);
      }
    }    
    
    //public Question Question{ get; set; }
    
    //public object QuestionObject{ get; set; }
    
    
    //private long _questionId;
    //public long QuestionId {
    //  get => _questionId;
    //  set {
    //    _questionId = value;
    //    Question = App.Instance.Model.CurrentQuestionnaire.GetQuestionById(QuestionId);
    //  }
    //}

    // public object QuestionASDF {
    //   get => ((QuestionViewModel) BindingContext).Question;
    //   set {
    //     Console.Out.WriteLine("QuestionView.xaml.cs::Question.Property.Set");
    //     if(value !=null)
    //       Console.Out.WriteLine("Not null");
    //           // ((QuestionViewModel) BindingContext).Question = (Question) value;
    //                 
    //   }
    // }




    //public QuestionView(object question):this() {
    //  Question = (Question) question;
    //}
          
  }
  
  
}

