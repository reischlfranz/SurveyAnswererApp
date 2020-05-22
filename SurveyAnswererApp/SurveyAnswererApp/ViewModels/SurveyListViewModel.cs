using System.Collections.ObjectModel;
using System.Linq;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.ViewModels
{
  public class SurveyListViewModel : BaseViewModel
  {
    private ObservableCollection<Questionnaire> _surveys;

    public ObservableCollection<Questionnaire> Surveys {
      get {
        // Update the list to reflect only 
        var tempList = _surveys.Where(s => s.SurveyMeta.IsDismissed == false).ToList();
        _surveys = new ObservableCollection<Questionnaire>(tempList);
        return _surveys;
      } 
      set => _surveys = value;
    }

    public SurveyListViewModel()
    {

      // foreach (var survey in Model.Instance.Surveys) {
      //   Surveys.Add(survey);
      // }

      Surveys = Model.Instance.Surveys;

      Model.Instance.Wrapper();


    }


    
  }
}
