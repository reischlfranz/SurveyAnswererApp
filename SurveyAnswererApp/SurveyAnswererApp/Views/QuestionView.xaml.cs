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

      var test = this;

      Console.Out.WriteLine(test.GetType().FullName);

    }

    protected override void OnBindingContextChanged()
    {
      if (BindingContext.GetType().Equals(typeof(Question)))
      {
        var question = (Question)BindingContext;
        // Change BindingContext from implicit Binding to Question to explicit ViewModel
        BindingContext = new QuestionViewModel(){Question = question};
        ((QuestionViewModel) BindingContext).AddAnswerViews(this.AnswerDataLayout);
      }
      base.OnBindingContextChanged();
      //var test = this;
      //var t1 = BindingContext;
      //Console.Out.WriteLine("");

      //AnswerDataLayout.Children.Insert(0, new Label(){Text = ((Question) BindingContext).QuestionType.ToString()});




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

