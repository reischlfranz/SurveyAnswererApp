using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SurveyAnswererApp.Models;
using SurveyAnswererApp.Services;

namespace SurveyAnswererApp.ViewModels
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

    bool isBusy = false;
    public bool IsBusy
    {
      get { return isBusy; }
      set { SetProperty(ref isBusy, value); }
    }

    string title = string.Empty;
    public string Title
    {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName]string propertyName = "",
        Action onChanged = null)
    {
      if (EqualityComparer<T>.Default.Equals(backingStore, value))
        return false;

      backingStore = value;
      onChanged?.Invoke();
      OnPropertyChanged(propertyName);
      return true;
    }

    #region PropertyRaisingStuffs
    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    protected void RaiseAllPropertiesChanged()
    {
      // By convention, an empty string indicates all properties are invalid.
      PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
    }

    protected void RaisePropertyChanged<T>(Expression<Func<T>> propExpr)
    {
      var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
      this.RaisePropertyChanged(prop.Name);
    }

    protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }



    #endregion

    #region INotifyPropertyChanged
    //public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      var changed = PropertyChanged;
      if (changed == null)
        return;

      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}
