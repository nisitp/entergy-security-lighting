using security_lighting_microsite.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace security_lighting_microsite.Controllers {
  [RoutePrefix("contact")]
  public class ContactController : Controller {
    [HttpPost]
    [Route("send")]
    public async Task<ActionResult> Send(ContactViewModel Model) {
      await Model.GeocodeZipCode();

      return Json(Model, JsonRequestBehavior.AllowGet);
    }
  }
}