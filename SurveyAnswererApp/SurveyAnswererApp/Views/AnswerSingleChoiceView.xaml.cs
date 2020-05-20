using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.InputKit.Shared.Controls;
using RadioButton = Plugin.InputKit.Shared.Controls.RadioButton;
using SurveyAnswererApp.Models.Survey;
using SurveyAnswererApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AnswerSingleChoiceView : ContentView, IAnswerView {
    public AnswerSingleChoiceView(Answer answer)
    {
      BindingContext = this;
      Answer = answer;
      InitializeComponent();
    }

    public Answer Answer { get; set; }

    #region HotfixRadioButton
    // Hotfix: Binding value to RadioButton.IsChecked does not work. Updating manually.
    protected override void OnBindingContextChanged()
    {
      if (BindingContext.GetType().Equals(typeof(AnswerViewModel)))
      {
        this.SingleChoiceSelection.IsChecked = ((AnswerViewModel) BindingContext).SingleChoiceAnswerSelection;
        ((AnswerViewModel)BindingContext).SingleChoiceSelectionRadioButton = this.SingleChoiceSelection;
      }
      base.OnBindingContextChanged();
    }

    private void SingleChoiceSelection_OnClicked(object sender, EventArgs e)
    {
      if (((RadioButton)sender).IsChecked)
      {
        ((AnswerViewModel)BindingContext).SingleChoiceAnswerSelection = true;
      }

    } 
    #endregion
  }
}

