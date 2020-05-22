using System;
using System.Text.Json.Serialization;

namespace SurveyAnswererApp.Models.Survey {
  public class Answer {

    [JsonPropertyName("answer")]
    public string AnswerText {
      get => _answerText; 
      set => _answerText = value ?? throw new ArgumentNullException("Value cannot be null");
    }
    private string _answerText = "";
    
    [JsonPropertyName("value")]
    public string Value { get; set; }    
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("min")]
    public string Min { get; set; }
    [JsonPropertyName("max")]
    public string Max { get; set; }
  }
}
