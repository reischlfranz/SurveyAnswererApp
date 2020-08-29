using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SurveyAnswererApp.Models.Survey;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HistoryListPage : ContentPage
  {
    public ObservableCollection<string> Items { get; set; }

    public HistoryListPage()
    {
      InitializeComponent();
    }

  }
}
