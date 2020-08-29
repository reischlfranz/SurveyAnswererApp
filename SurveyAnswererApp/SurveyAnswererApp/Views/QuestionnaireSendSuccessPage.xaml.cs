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
  public partial class QuestionnaireSendSuccessPage : ContentPage
  {
    public QuestionnaireSendSuccessPage()
    {
      InitializeComponent();
    }

    private void BackToMainButton_OnClicked(object sender, EventArgs e)
    {
      App.Instance.SetMainPage(new NavigationPage(new MainTabNavPage()));
    }
  }
}