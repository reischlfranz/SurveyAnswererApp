using System.Collections.ObjectModel;
using System.Linq;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;

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

    public HistoryListViewModel() {
      HistoryHistorySurveys = Model.Instance.Surveys; 
    }

    
    
  }
}
