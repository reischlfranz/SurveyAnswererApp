using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class QuestionnaireSummaryPage : ContentPage
  {
    public QuestionnaireSummaryPage()
    {
      InitializeComponent();
    }

    private async void SendSurveyButton_OnClicked(object sender, EventArgs e)
    {
      //App.Instance.MainPage = new NavigationPage(new MainTabNavPage());
      Page successPage = new QuestionnaireSendSuccessPage();

      App.Instance.MainPage = new NavigationPage(successPage);
      //await Navigation.PushAsync(successPage);
      //Navigation.InsertPageBefore(new MainTabNavPage(), successPage);
    }
  }
}