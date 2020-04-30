using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SurveyAnswererApp.Models.Survey {
  public class Questionnaire {
    private long _questionnaireId = 0;
    
    [JsonPropertyName("id")]
    public long Id {
      get => _questionnaireId;
      set {
        if (value < 0) throw new ArgumentException("Value cannot be negative");
        _questionnaireId = value;
      }
    }

    private string _title = "";
    [JsonPropertyName("title")]
    public string Title { 
      get => _title;
      set => _title = value ?? throw new ArgumentNullException("Value cannot be null");
    }

    private string _description = "";
    [JsonPropertyName("desc")]
    public string Description {
      get => _description;
      set => _description = value ?? throw new ArgumentNullException("Value cannot be null");
    }

    [JsonPropertyName("questions")]
    // public Question[] Questions { get; set; }
    public List<Question> Questions{ get; set; } = new List<Question>();

  }
}
