﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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

      Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

      MyListView.ItemsSource = Items;
    }

    async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      if (e.Item == null)
        return;

      // await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
      await Navigation.PushAsync(new SurveyDetailPage());

      //Deselect Item
      ((ListView)sender).SelectedItem = null;
    }
  }
}
