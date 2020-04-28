using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SurveyAnswererApp.Models.Survey;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SurveyAnswererApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SurveyListPage : ContentPage
  {
    public ObservableCollection<string> Items { get; set; }

    public SurveyListPage()
    {
      InitializeComponent();

    }

    async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      if (e.Item == null)
        return;

      // await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

      ListView selection = (ListView) sender;
      Questionnaire selectedQuestionnaire = (Questionnaire) selection.SelectedItem;


      await Navigation.PushAsync(new SurveyDetailPage(selectedQuestionnaire));

      //Deselect Item
      ((ListView)sender).SelectedItem = null;
    }
  }
}
