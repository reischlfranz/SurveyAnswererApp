using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAnswererApp.Models.Survey
{
  public class SurveyMeta
  {
    // When is first read over REST
    public DateTime FirstRetrievalTime { get; set; }

    // Has been started to be answered
    public bool IsStarted { get; set; }

    // Has been sent, so hide from view
    public DateTime SentDate { get; set; }

    // Has been completed - Can be / has been sent
    public bool IsCompleted { get; set; }
    
    // Has been dismissed - Do not show in list anymore
    public bool IsDismissed { get; set; }

    public SurveyMeta()
    {
      
    }
  }
}
