using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
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

    public ICommand ListItemSelectCommand;

    public HistoryListViewModel() {
      HistoryHistorySurveys = Model.Instance.Surveys;
      ListItemSelectCommand = new Command(
            e => ExecuteListItemSelectCommand(e, EventArgs.Empty), 
            e => CanExecuteListItemSelectCommand());
    }

    private bool CanExecuteListItemSelectCommand() {
      return true;
    }

    private async void ExecuteListItemSelectCommand(object sender, EventArgs args) {
      if(sender.GetType() != typeof(Questionnaire)) { return; }

      var itemSelected = (Questionnaire) sender;
      
      Console.Out.WriteLine("Item selected: ");
    }
          
    
    
  }
}
