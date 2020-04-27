using System;

namespace SurveyAnswererApp.Models.Survey {
  public class Answer {

    public string AnswerText {
      get => _answerText; 
      set => _answerText = value ?? throw new ArgumentNullException("Value cannot be null");
    }
    private string _answerText = "";
    
    public string Value { get; set; }
    public string Min { get; set; }
    public string Max { get; set; }
  }
}
