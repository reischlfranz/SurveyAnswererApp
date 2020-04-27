using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyAnswererApp.Models.Survey;

namespace SurveyAnswererApp.Test {
  [TestClass]
  public class QuestionnaireTest {
      private Questionnaire _questionnaire;
      private Question _question;
      private Answer _answer;

      [TestInitialize]
      public void InitTest() {
        _questionnaire = new Questionnaire();
        _question = new Question();
        _answer = new Answer();
      }

      [TestMethod]
      public void IllegalSurveyArguments() {
        Assert.ThrowsException<ArgumentException>(() => _question.Nr = -1);
        Assert.ThrowsException<ArgumentException>(() => _question.Nr = long.MinValue);
        
        // for later use
        // Assert.ThrowsException<ArgumentException>(() => _answer.Id = -1);
        // Assert.ThrowsException<ArgumentException>(() => _answer.Id = long.MinValue);

        Assert.ThrowsException<ArgumentNullException>(() => _questionnaire.Title = null);
        Assert.ThrowsException<ArgumentNullException>(() => _questionnaire.Description = null);
        Assert.ThrowsException<ArgumentNullException>(() => _question.QuestionText = null);
        Assert.ThrowsException<ArgumentNullException>(() => _answer.AnswerText = null);
      }

      [TestMethod]
      public void ListsAreEmptyAndNotNull() {
        Assert.IsNotNull(_questionnaire.Questions);
        Assert.IsNotNull(_question.Answers);
        Assert.AreEqual(0, _questionnaire.Questions.Count);
        Assert.AreEqual(0, _question.Answers.Count);
      }
    
    
      [TestMethod]
      public void ValidSurveyArguments(){
        try {
          _question.Nr = 0;
          _question.Nr = 1;
          _question.Nr = long.MaxValue;
          
          // for later use
          // _answer.Id = 0;
          // _answer.Id = 1;
          // _answer.Id = long.MaxValue;

          _questionnaire.Title = string.Empty;
          _questionnaire.Title = "Non-Empty String";
          _questionnaire.Description = string.Empty;
          _questionnaire.Description = "Non-Empty String";
          _question.QuestionText = string.Empty;
          _question.QuestionText = "Non-Empty String";
          _answer.AnswerText = string.Empty;
          _answer.AnswerText = "Non-Empty String";
          
        }
        catch (Exception e) {
          Assert.Fail("Asserted no Exception but got "+e.Message);
        }
      }

      [TestMethod]
      public void CanAddDirectly() {
        _question.Answers.Add(_answer);
        _questionnaire.Questions.Add(_question);
      }
    }
}
