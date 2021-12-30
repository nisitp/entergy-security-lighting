using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace security_lighting_microsite.models {
  public class Opco {
    public static string GetOpcoTLA(string OpcoName) {
      switch (OpcoName.ToLower()) {
        case "texas":
          return "ETI";

        case "mississippi":
          return "EMI";

        case "gulf-states-louisiana":
          return "EGSL";

        case "louisiana":
          return "ELL";

        case "arkansas":
          return "EAI";

        case "new-orleans":
          return "ENO";
        
        default:
          return null;
      }
    }

    public static string GetOpcoEmailAddress(string OpCoName) {
      switch (OpCoName) {
        case "texas":
          return "Texas Address";

        case "mississippi":
          return "Mississippi Address";

        // Etc

        default:
          return "Default Address";
      }
    }
  }
}