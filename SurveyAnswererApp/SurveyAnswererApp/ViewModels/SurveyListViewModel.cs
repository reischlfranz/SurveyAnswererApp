using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  public class SurveyListViewModel : BaseViewModel
  {
    private ObservableCollection<Questionnaire> _surveys;
    public ObservableCollection<Questionnaire> Surveys {
      get {
        // Update the list to reflect only 
        var tempList = Model.Instance.Surveys.Where(s => s.SurveyMeta.IsDismissed == false).ToList();
        return new ObservableCollection<Questionnaire>(tempList);
      } 
      set => _surveys = value;
    }

    private void SurveyCollectionChanged(object sender, NotifyCollectionChangedEventArgs args) {

      Console.Out.WriteLine("  >>> >>> >>> # Collection updated!!! # <<< <<< <<< ");
      RaisePropertyChanged();
    }

    public ObservableCollection<Questionnaire> AvailableSurveys{ get; set; }

    public SurveyListViewModel()
    {

      // foreach (var survey in Model.Instance.Surveys) {
      //   Surveys.Add(survey);
      // }

      // Surveys = Model.Instance.Surveys;
      AvailableSurveys = new ObservableCollection<Questionnaire>(
            from item in (Model.Instance.Surveys) 
            where !item.SurveyMeta.IsCompleted && !item.SurveyMeta.IsDismissed  
            orderby item.Id 
            select item);

      Model.Instance.Surveys.CollectionChanged += this.SurveyCollectionChanged;
      AvailableSurveys.CollectionChanged += this.SurveyCollectionChanged;
      Model.Instance.Wrapper();
      RaisePropertyChanged();


    }


    
  }
}
