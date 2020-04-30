using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SurveyAnswererApp.Models.Survey {
  public class Question {

    private long _questionId = 0;
    [JsonPropertyName("nr")]
    public long Nr {
      get => _questionId;
      set {
        if (value < 0) throw new ArgumentException("Value cannot be negative");
        _questionId = value;
      }
    }

    // Used as a crutch to fill an Enum via JSON
    [JsonPropertyName("type")]
    public string QuestionTypeJsonWrapper {
      get => QuestionType.ToString();
      set {
        QuestionType qt;
        if (Enum.TryParse(value, true, out qt)) {
          QuestionType = qt;
        }
      }
    }
    
    public QuestionType QuestionType { get; set; }

    private string _questionText = "";

    [JsonPropertyName("question")]
    public string QuestionText {
      get => _questionText;
      set => _questionText = value ?? throw new ArgumentNullException("Value cannot be null");
    }

    [JsonPropertyName("answers")]
    public List<Answer> Answers { get; set;  } = new List<Answer>();
  }
}
