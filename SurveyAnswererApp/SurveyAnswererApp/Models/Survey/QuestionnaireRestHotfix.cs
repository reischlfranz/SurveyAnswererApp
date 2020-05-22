using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SurveyAnswererApp.Models.Survey {
  public class QuestionnaireRestHotfix {
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("desc")] public string Description { get; set; }

    [JsonPropertyName("questions")] public long Questions { get; set; }
  }
}
