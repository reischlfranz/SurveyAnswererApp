using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SurveyDetailPage : ContentPage
  {
    public SurveyDetailPage(Questionnaire questionnaire)
    {
      BindingContext = new SurveyDetailViewModel(){Questionnaire = questionnaire};
      InitializeComponent();
    }

    private void TakeSurveyButton_OnClicked(object sender, EventArgs e)
    {
      App.Instance.MainPage = new NavigationPage(new QuestionnairePage());
    }
  }
}