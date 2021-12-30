using security_lighting_microsite.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace security_lighting_microsite.Controllers {
  public class HomeController : Controller {
    [Route("{OpCo?}")]
    public ActionResult Index(string OpCo) {
      ViewBag.OpCo = !String.IsNullOrWhiteSpace(OpCo) ? OpCo.ToLower() : null;

      return View();
    }

    [Route("{OpCo}/fixtures")]
    public ActionResult Fixtures(string OpCo) {
      var OpCoCode = Opco.GetOpcoTLA(OpCo);

      return Json(models.Fixture.GetFixtures(OpCoCode), JsonRequestBehavior.AllowGet);
    }

    [Route("{OpCo}/fixture/{FixtureType}/summary", Name="FixtureSummary")]
    public ActionResult FixtureSummary(string OpCo, string FixtureType) {
      ViewBag.OpCo = OpCo;

      var OpCoCode = Opco.GetOpcoTLA(OpCo);

      var model = models.Fixture.GetFixture(OpCoCode, FixtureType);

      return View("_fixtureSummary", model);
    }

    [Route("{OpCo}/fixture/{FixtureType}")]
    public ActionResult Fixture(string OpCo, string FixtureType) {
      ViewBag.OpCo = OpCo;
      ViewBag.OpCoCode = Opco.GetOpcoTLA(OpCo);

      var model = models.Fixture.GetFixture(ViewBag.OpCoCode, FixtureType);

      return View(model);
    }
  }
}