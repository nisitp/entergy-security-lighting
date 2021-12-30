using System.Web;
using System.Web.Optimization;

namespace security_lighting_microsite {
  public class BundleConfig {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles) {
      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/scripts/lib/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/scripts/respond.js",
                "~/scripts/lib/jquery.ba-throttle-debounce.min.js",
                "~/scripts/lib/isInViewport.min.js",
                "~/scripts/lib/easings.js",
                "~/scripts/lib/bootstrap/dropdown.js"));

      bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/scripts/site.js",
                "~/scripts/pages/index.js",
                "~/scripts/pages/fixture.js"
        ));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/styles/lib/bootstrap/bootstrap.css",
                "~/styles/site.css"));
    }
  }
}
