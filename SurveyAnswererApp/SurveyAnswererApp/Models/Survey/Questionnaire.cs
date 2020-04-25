using System.Collections.Generic;

namespace SurveyAnswererApp.Models.Survey {
  public class Questionnaire {
    public long Id{ get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Question> Questions{ get; private set; }
  }
}
