using System.Collections.Generic;

namespace SurveyAnswererApp.Models.Survey {
  public class Question {
    public long Nr { get; set; }
    public QuestionType QuestionType { get; set; }
    public string QuestionText { get; set; }
    public List<Answer> Answers { get; set; }

    public Question() {
      Answers = new List<Answer>();
    }
  }
}
