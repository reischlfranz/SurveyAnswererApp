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
  public partial class QuestionnairePage : ContentPage
  {
  
    public QuestionnairePage(Questionnaire questionnaire) {
      this.BindingContext = new SurveyViewModel(questionnaire);
      InitializeComponent();
    }

    private async void ExitSurveyButton_OnClicked(object sender, EventArgs e)
    {
      bool doExit;
      doExit = await DisplayAlert("Exit?", "Do you really want to stop taking this survey?", "Yes", "No");

      if (doExit)
      {
        App.Instance.MainPage = new NavigationPage(new MainTabNavPage());
        return;
      }
    }

    private async void DoneSurveyButton_OnClicked(object sender, EventArgs e)
    {
      //bool doSend;
      //doSend = await DisplayAlert("Send?", "Are you done answering this survey?", "Yes", "No");
      //if (!doSend) return;
      ((SurveyViewModel) BindingContext).SendCommand.Execute(this);
    }
  }
}