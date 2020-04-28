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
    public int CurrentPage { get; set; }

   
    public QuestionnairePage(Questionnaire questionnaire) {
      this.BindingContext = new SurveyViewModel(questionnaire);
      InitializeComponent();
      CurrentPage = 1;
      CurrentPageLabel.Text = CurrentPage.ToString();
    }

    private void BackButton_OnClicked(object sender, EventArgs e)
    {
      if (CurrentPage <= 1)
      {
        CurrentPage = 1;
        return;
      }

      CurrentPage--;
      CurrentPageLabel.Text = CurrentPage.ToString();
    }

    private void NextButton_OnClicked(object sender, EventArgs e)
    {
      CurrentPage++;
      CurrentPageLabel.Text = CurrentPage.ToString();
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
      bool doSend;
      doSend = await DisplayAlert("Send?", "Are you done answering this survey?", "Yes", "No");

      if (doSend)
      {
        await Navigation.PushAsync(new QuestionnaireSummaryPage());
        return;
      }
    }
  }
}