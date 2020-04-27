using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveyAnswererApp.Models.Survey {
  public class Question {

    private long _questionId = 0;
    public long Nr {
      get => _questionId;
      set {
        if (value < 0) throw new ArgumentException("Value cannot be negative");
        _questionId = value;
      }
    }

    public QuestionType QuestionType { get; set; }

    private string _questionText = "";

    public string QuestionText {
      get => _questionText;
      set => _questionText = value ?? throw new ArgumentNullException("Value cannot be null");
    }

    public List<Answer> Answers { get; } = new List<Answer>();
  }
}
