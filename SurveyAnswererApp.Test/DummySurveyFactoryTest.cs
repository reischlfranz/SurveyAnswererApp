using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.Test {
  [TestClass]
  public class DummySurveyFactoryTest {
    private Questionnaire _questionnaire;

    [TestInitialize]
    public void InitTest() {
      _questionnaire = DummySurveyFactory.GetSurvey();
    }

    [TestMethod]
    public void SurveyHasProperties() {
      Assert.IsNotNull(_questionnaire.Description);
      Assert.IsNotNull(_questionnaire.Title);
      Assert.IsTrue(_questionnaire.Id > 0);
    }

    [TestMethod]
    public void SurveyHasQuestions() {
      Assert.IsTrue(_questionnaire.Questions.Count > 0);
      foreach (var question in _questionnaire.Questions) {
        Assert.IsNotNull(question.QuestionType);
        Assert.IsNotNull(question.QuestionText);
        Assert.IsTrue(question.Nr>0);
        Assert.IsTrue(question.Answers.Count>0);
      }
    }
  }
}
