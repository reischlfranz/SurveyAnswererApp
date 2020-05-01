using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;

namespace SurveyAnswererApp.ViewModels {
  public class SurveyViewModel : BaseViewModel {

    private const int ITEMS_PER_PAGE = 2;

    public int CurrentPageIndex
    {
      get => _currentPageIndex;
      set {
        _currentPageIndex = value;
        RaiseAllPropertiesChanged();

        // Let the buttons' IsEnabled be updated
        RefreshCanExecutes();
      }
    }
    private int _currentPageIndex;

    // Commands
    public ICommand NextPageCommand { get; private set; }
    public ICommand LastPageCommand { get; private set; }
    public ICommand SendCommand { get; private set; }




    // private Questionnaire _questionnaire;
    public Questionnaire Questionnaire{ 
      get => App.Instance.Model.CurrentQuestionnaire; 
      set => App.Instance.Model.CurrentQuestionnaire = value ?? throw new ArgumentNullException(); 
    }

    public ObservableCollection<Question> Questions { get; }  = new ObservableCollection<Question>();

    public string SurveyTitle { get; set; }
    public string SurveyDescription { get; set; }

    // Constructor
    public SurveyViewModel(Questionnaire questionnaire) {
      
      Questionnaire = questionnaire;
      NextPageCommand = new Command(e => ExecuteNextPageCommand(e, EventArgs.Empty), e => CanExecuteNextPageCommand());
      LastPageCommand = new Command(e => ExecuteLastPageCommand(e, EventArgs.Empty), e => CanExecuteLastPageCommand());
      SendCommand = new Command(e => ExecuteSendCommand(e, EventArgs.Empty));
      
      SurveyTitle = Questionnaire.Title;
      SurveyDescription = Questionnaire.Description;

      // Populate first page
      ExecuteLastPageCommand(null, null);

    }


    private bool CanExecuteNextPageCommand()
    {
      if (Questions == null) return false;
      return CurrentPageIndex + ITEMS_PER_PAGE < (Questionnaire.Questions.Count);
    }


    private bool CanExecuteLastPageCommand()
    {
      if (Questions == null) return false;
      return CurrentPageIndex > 0;
    }


    private async void ExecuteNextPageCommand(object sender, EventArgs empty)
    {
      if (CurrentPageIndex + ITEMS_PER_PAGE > Questionnaire.Questions.Count) return;
      Questions.Clear();
      CurrentPageIndex += ITEMS_PER_PAGE;
      for (int i = CurrentPageIndex; i < (CurrentPageIndex + ITEMS_PER_PAGE) && i < Questionnaire.Questions.Count - 1; i++)
      {
        Questions.Add(Questionnaire.Questions[i]);
      }
      //PropertyChanged(this,new PropertyChangedEventArgs("In"));
    }

    private async void ExecuteLastPageCommand(object sender, EventArgs empty)
    {
      CurrentPageIndex -= ITEMS_PER_PAGE;
      if (CurrentPageIndex < 0) CurrentPageIndex = 0;
      Questions.Clear();
      for (int i = CurrentPageIndex; i < CurrentPageIndex + ITEMS_PER_PAGE && i < Questionnaire.Questions.Count - 1; i++)
      {
        Questions.Add(Questionnaire.Questions[i]);
      }
    }

    private async void ExecuteSendCommand(object sender, EventArgs empty)
    {

      bool doSend;
      doSend = await ((Page)sender).DisplayAlert("Send?", "Are you done answering this survey?", "Yes", "No");

      if (doSend)
      {
        await ((Page)sender).Navigation.PushAsync(new QuestionnaireSummaryPage());
        return;
      }
    }

    private void RefreshCanExecutes()
    {
      (NextPageCommand as Command).ChangeCanExecute();
      (LastPageCommand as Command).ChangeCanExecute();
      (SendCommand as Command).ChangeCanExecute();
    }


  }
}
