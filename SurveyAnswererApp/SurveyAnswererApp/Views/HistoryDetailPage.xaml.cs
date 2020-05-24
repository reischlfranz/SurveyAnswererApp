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
  public partial class HistoryDetailPage : ContentPage
  {
    public HistoryDetailPage(Questionnaire questionnaire)
    {
      BindingContext = new HistoryDetailViewModel(questionnaire);
      InitializeComponent();
    }
  }
}