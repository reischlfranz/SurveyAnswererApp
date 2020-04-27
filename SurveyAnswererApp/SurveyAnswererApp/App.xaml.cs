using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SurveyAnswererApp.Services;
using SurveyAnswererApp.Views;

namespace SurveyAnswererApp
{
  public partial class App : Application
  {
    private static App _instance;
    public static App Instance
    {
      get { return _instance ?? (_instance = new App()); }
    }
    
    
    public App()
    {
      if(_instance != null) return;
      InitializeComponent();

      DependencyService.Register<MockDataStore>();
      MainPage = new NavigationPage(new MainTabNavPage());
      _instance = this;
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
