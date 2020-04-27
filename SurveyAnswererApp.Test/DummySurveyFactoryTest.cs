using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyAnswererApp.Models;
using SurveyAnswererApp.Models.Survey;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;

namespace SurveyAnswererApp.Test {
  [TestClass]
  public class DummySurveyFactoryTest {
    private Questionnaire _questionnaire;

    [TestInitialize]
    public void InitTest() {
      _questionnaire = DummySurveyFactory.GetSurvey();
    }

    [TestMethod]
    public void DummySurveyHasProperties() {
      Assert.IsNotNull(_questionnaire.Description);
      Assert.IsNotNull(_questionnaire.Title);
      Assert.IsTrue(_questionnaire.Id > 0);
    }

    [TestMethod]
    public void DummySurveyHasQuestions() {
      Assert.IsTrue(_questionnaire.Questions.Count > 0);
      foreach (var question in _questionnaire.Questions) {
        Assert.IsNotNull(question.QuestionType);
        Assert.IsNotNull(question.QuestionText);
        Assert.IsTrue(question.Nr>0);
        Assert.IsTrue(question.Answers.Count>0);
      }
    }

    [TestMethod]
    public void IllegalSurveyArguments() {
      Assert.ThrowsException<ArgumentException>(() => _questionnaire.Id = -1);
      Assert.ThrowsException<ArgumentException>(() => _questionnaire.Id = long.MinValue);
    }
    
    
    [TestMethod]
    public void ValidSurveyArguments(){
      try {
        _questionnaire.Id = 0;
        _questionnaire.Id = 1;
        _questionnaire.Id = long.MaxValue;
      }
      catch (Exception e) {
        Assert.Fail("Asserted no Exception but got "+e.Message);
      }
    }
  }
}
