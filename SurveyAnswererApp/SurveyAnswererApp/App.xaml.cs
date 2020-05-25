using System;
using SurveyAnswererApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SurveyAnswererApp.Services;
using SurveyAnswererApp.Views;

namespace SurveyAnswererApp
{
  public partial class App : Application
  {
    private static App _instance;
    public static App Instance {
      get { return _instance; }
    }

    public Model Model{ get; } = Model.Instance;
    public INavigation Navigation { get; set; }

    public App()
    {
      Device.SetFlags(new string[] { "RadioButton_Experimental" });
      if (_instance != null) return;
      InitializeComponent();
      
      DependencyService.Register<MockDataStore>();
      MainPage = new NavigationPage(new MainTabNavPage());
      Navigation = MainPage.Navigation;
      _instance = this;
    }

    public void SetMainPage(Page newMainPage) {
      MainPage = newMainPage;
      Navigation = MainPage.Navigation;
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
