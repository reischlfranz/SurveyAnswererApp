using System;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.Models {

  public class DummySurveyFactory {

    public static Questionnaire GetSurvey() {

      var rand = new Random();
      var survey = new Questionnaire();

      survey.Title = GetRandomString(10);
      survey.Description = GetRandomString(200);
      
      survey.Id = rand.Next(5)*20+100;

      for (var i = 0; i < rand.Next(10)+5; i++) {
        var q = new Question() {
              QuestionType = (QuestionType)rand.Next(Enum.GetValues(typeof(QuestionType)).Length),
              Id = survey.Id + i,
              QuestionText = GetRandomString(75)
        };
        for (var j = 0; j < rand.Next(6)+1; j++) {
          var a = new Answer() {
                AnswerText = GetRandomString(8+rand.Next(20)),
                Id = (long) q.Id * 10 + j
          };
          q.Answers.Add(a);
        }
        survey.Questions.Add(q);

      }
      
      return survey;
    }

    private static string GetRandomString(int length) {
      
      var randomStringChars = new char[length];
      var rand = new Random();
      for(var i = 0; i < length; i++) {
        randomStringChars[i] = (char)(rand.Next(26) + 'a');
      }

      randomStringChars[0] = Char.ToUpper(randomStringChars[0]);
      return new string(randomStringChars);
    }


  }
}
