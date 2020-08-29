using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  public class HistoryListViewModel : BaseViewModel
  {
    private ObservableCollection<Questionnaire> _historySurveys;

    public ObservableCollection<Questionnaire> HistoryHistorySurveys {
      get {
        
        return _historySurveys;
      }
      set {
        // Update the list to reflect only 
        var tempList = value.Where(s => s.SurveyMeta.IsCompleted).ToList();
        _historySurveys = new ObservableCollection<Questionnaire>(tempList);
      }
    }

    public ICommand SurveySelectedCommand { get; private set; }

    public HistoryListViewModel() {
      HistoryHistorySurveys = Model.Instance.Surveys;
      SurveySelectedCommand = new Command(
            e => ExecuteSurveySelectedCommand(e, EventArgs.Empty));
    }

    private async void ExecuteSurveySelectedCommand(object sender, EventArgs args) {
      if (sender == null)
        return;

      Questionnaire selectedQuestionnaire = (Questionnaire)sender;

      await App.Instance.Navigation.PushAsync(new HistoryDetailPage(selectedQuestionnaire));

    }
          
    
    
  }
}
