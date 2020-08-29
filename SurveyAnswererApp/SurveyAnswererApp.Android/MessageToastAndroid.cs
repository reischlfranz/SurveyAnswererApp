using Android.App;
using Android.Widget;
using SurveyAnswererApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MessageToastAndroid))]

namespace SurveyAnswererApp.Droid {
  public class MessageToastAndroid : IMessageToast {
    public void LongAlert(string message) {
      Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
    }

    public void ShortAlert(string message) {
      Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
    }
  }
}
