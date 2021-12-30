using System.Web;
using System.Web.Mvc;

namespace security_lighting_microsite {
  public class FilterConfig {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
