using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace security_lighting_microsite.models {
  public class Fixture {
    public string Type { get; set; }
    public string[] Features { get; set; }
    public string Summary { get; set; }    
    public string Specsheet { get; set; }
    public string[] Applications { get; set; }
    public Variation[] Variations { get; set; }

    public class Variation {
      public string Fixture { get; set; }
      public Illumination Illumination { get; set; }
      public List<string> Availability { get; set; }
    }

    public class Illumination {
      public int? Diameter { get; set; }
      public int? Width { get; set; }
      public int? Depth { get; set; }
    }

    public static List<Fixture> GetFixtures(string OpCoCode = null) {
      var json = File.ReadAllText(HttpContext.Current.Server.MapPath("~/app_data/fixtures.json"));

      IEnumerable<Fixture> fixtures = JsonConvert.DeserializeObject<List<Fixture>>(json);

      if (!string.IsNullOrWhiteSpace(OpCoCode)) {
        fixtures = fixtures.Where(f => f.Variations.Any(v => v.Availability.Contains(OpCoCode)));
      }

      return fixtures.ToList();
    }

    public static Fixture GetFixture(string OpCoCode, string FixtureType) {
      FixtureType = FixtureType.Replace('-', ' ');

      return GetFixtures(OpCoCode).Find(f => String.Equals(f.Type, FixtureType, StringComparison.InvariantCultureIgnoreCase));
    }
  }

}