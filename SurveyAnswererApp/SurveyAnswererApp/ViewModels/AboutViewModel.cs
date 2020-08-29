using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  public class AboutViewModel : BaseViewModel
  {
    public AboutViewModel()
    {
      Title = "About";
      OpenWebSeCommand = new Command(async () => await Browser.OpenAsync("https://se.jku.at/"));
      OpenWebJkuCommand = new Command(async () => await Browser.OpenAsync("https://www.jku.at/"));
    }

    public ICommand OpenWebSeCommand { get; }
    public ICommand OpenWebJkuCommand { get; }
  }
}