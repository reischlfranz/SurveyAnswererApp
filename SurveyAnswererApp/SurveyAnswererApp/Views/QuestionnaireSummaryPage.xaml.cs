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
  public partial class QuestionnaireSummaryPage : ContentPage
  {
    public QuestionnaireSummaryPage(Questionnaire questionnaire)
    {
      this.BindingContext = new SurveySummaryViewModel(questionnaire);
      InitializeComponent();
    }

    private async void SendSurveyButton_OnClicked(object sender, EventArgs e)
    {
      Page successPage = new QuestionnaireSendSuccessPage();

      App.Instance.SetMainPage(new NavigationPage(successPage));
      //await Navigation.PushAsync(successPage);
      //Navigation.InsertPageBefore(new MainTabNavPage(), successPage);
    }
  }
}