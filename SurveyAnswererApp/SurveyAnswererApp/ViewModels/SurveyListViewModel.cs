using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels
{
  public class SurveyListViewModel : BaseViewModel {
    
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
      if(sender == null) return;
      UpdateAvailableSurveys();

      RaisePropertyChanged();
    }

    public void UpdateAvailableSurveys()
    {
      object sender;
      var parentSurveys = Model.Instance.Surveys;


      foreach (var q in parentSurveys)
      {
        if (!AvailableSurveys.Contains(q) &&
            !q.SurveyMeta.IsCompleted &&
            !q.SurveyMeta.IsDismissed)
        {
          // Execute on UI thread; BindableLayout is not as forgiving as ListView
          Device.BeginInvokeOnMainThread(() => AvailableSurveys.Add(q));
        }
      }

      foreach (var q in AvailableSurveys)
      {
        if (!parentSurveys.Contains(q) ||
            q.SurveyMeta.IsCompleted ||
            q.SurveyMeta.IsDismissed)
        {
          Device.BeginInvokeOnMainThread(() => AvailableSurveys.Remove(q));
        }
      }
    }

    public ObservableCollection<Questionnaire> AvailableSurveys{ get; set; }

    public ICommand SurveySelectedCommand { get; private set; }

    public SurveyListViewModel()
    {

      // foreach (var survey in Model.Instance.Surveys) {
      //   Surveys.Add(survey);
      // }

      //Surveys = Model.Instance.Surveys;
      AvailableSurveys = new ObservableCollection<Questionnaire>(
            from item in (Model.Instance.Surveys)
            where !item.SurveyMeta.IsCompleted && !item.SurveyMeta.IsDismissed
            orderby item.Id
            select item);

      UpdateAvailableSurveys();
      Model.Instance.Surveys.CollectionChanged += this.SurveyCollectionChanged;
      Model.Instance.Wrapper();

      SurveySelectedCommand = new Command(e => ExecuteSurveySelectedCommand(e, EventArgs.Empty));

    }

    private async void ExecuteSurveySelectedCommand(object sender, EventArgs e)
    {
      if (sender == null)
        return;

      Questionnaire selectedQuestionnaire = (Questionnaire)sender;

      await App.Instance.Navigation.PushAsync(new SurveyDetailPage(selectedQuestionnaire));

    }
     

  }
}
