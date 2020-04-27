using System;
using System.Collections.Generic;

namespace SurveyAnswererApp.Models.Survey {
  public class Questionnaire {
    private long _questionnaireId = 0;
    public long Id {
      get => _questionnaireId;
      set {
        if (value < 0) throw new ArgumentException("Value cannot be negative");
        _questionnaireId = value;
      }
    }

    private string _title = "";
    public string Title { 
      get => _title;
      set => _title = value ?? throw new ArgumentNullException("Value cannot be null");
    }

    private string _description = "";

    public string Description {
      get => _description;
      set => _description = value ?? throw new ArgumentNullException("Value cannot be null");
    }

    public List<Question> Questions{ get; } = new List<Question>();

  }
}
