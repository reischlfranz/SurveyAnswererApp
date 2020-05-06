using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Plugin.InputKit.Shared.Controls;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.ViewModels
{
  class AnswerViewModel : BaseViewModel
  {
    private QuestionViewModel _questionViewModel;

    private Answer _answer;
    public Answer Answer
    {
      get => _answer;
      set
      {
        _answer = value;
        // Read previously saved Answer properties
        ReadSavedAnswer();
      }
    }

    private int _yesNoAnswerSelection = -1;
    public int YesNoAnswerSelection
    {
      get => _yesNoAnswerSelection;
      set
      {
        _yesNoAnswerSelection = value;
        Answer.Value = value == 0 ? "Yes" : "No";
      }
    }

    private bool _multipleChoiceAnswerSelection;
    public bool MultipleChoiceAnswerSelection
    {
      get => _multipleChoiceAnswerSelection;
      set
      {
        _multipleChoiceAnswerSelection = value;
        Answer.Value = value.ToString();
      }
    }

    private bool _singleChoiceAnswerSelection;
    public bool SingleChoiceAnswerSelection
    {
      get => _singleChoiceAnswerSelection;
      set
      {

        _singleChoiceAnswerSelection = value;
        Answer.Value = value.ToString();
        if (value)
        {
          _questionViewModel.UpdateSingleChoiceSelection(this);
        }
        RaiseAllPropertiesChanged();
      }
    }
    // Hotfix: Binding value to RadioButton.IsChecked does not work.
    // Keeping reference to manipulate manually
    public RadioButton SingleChoiceSelectionRadioButton { get; set; }

    private int _numberAnswerValue;
    public int NumberAnswerValue
    {
      get => _numberAnswerValue;
      set
      {
        _numberAnswerValue = value;
        Answer.Value = value.ToString();
      }
    }

    private int _ratingAnswerValue;
    public int RatingAnswerValue
    {
      get => _ratingAnswerValue;
      set
      {
        _ratingAnswerValue = value;
        Answer.Value = value.ToString();

      }
    }

    private string _freeFormAnswerText;
    public string FreeFormAnswerText
    {
      get => _freeFormAnswerText;
      set
      {
        _freeFormAnswerText = value;
        Answer.Value = value;
      }
    }

    public ICommand SingleChoiceAnswerChangedCommand;

    private async void ExecuteSingleChoiceAnswerChangedCommand(object o, EventArgs empty)
    {
      SingleChoiceAnswerSelection = true;
      // _questionViewModel.UpdateSingleChoiceSelection(this);
    }

    private bool CanExecuteSingleChoiceAnswerChangedCommand()
    {
      return true;
    }

    public AnswerViewModel(QuestionViewModel questionViewModel)
    {
      _questionViewModel = questionViewModel;
      _questionViewModel.AnswerViewModels.Add(this);

      SingleChoiceAnswerChangedCommand = new Command(
        e => ExecuteSingleChoiceAnswerChangedCommand(e, EventArgs.Empty), 
        e=>CanExecuteSingleChoiceAnswerChangedCommand()
      );

    }

    private void ReadSavedAnswer()
    {
      if(Answer == null) return;
      switch (_questionViewModel.Question.QuestionType)
      {
        case QuestionType.OPEN:
          FreeFormAnswerText = Answer.Value;
          break;
        case QuestionType.YES_NO:
          if (Answer.Value == "Yes") YesNoAnswerSelection = 0;
          else if (Answer.Value == "No") YesNoAnswerSelection = 1;
          else YesNoAnswerSelection = -1;
          break;
        case QuestionType.SINGLE_CHOICE:
          if (Answer.Value == true.ToString()) SingleChoiceAnswerSelection = true;
          break;
        case QuestionType.MULTIPLE_CHOICE:
          if (Answer.Value == true.ToString()) MultipleChoiceAnswerSelection = true;
          break;
        case QuestionType.NUMBER:
          int.TryParse(Answer.Value, out _numberAnswerValue);
          break;
        case QuestionType.RATING:
          int.TryParse(Answer.Value, out _ratingAnswerValue);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}
