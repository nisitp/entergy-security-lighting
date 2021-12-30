using security_lighting_microsite.models.HttpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace security_lighting_microsite.models {
  public class ContactViewModel {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Phone { get; set; }
    public string BestTimeToCall { get; set; }
    public string AccountType { get; set; }
    public string OpCo { get; set; }

    public async Task GeocodeZipCode() {
      if (string.IsNullOrWhiteSpace(Zip)) {
        throw new ArgumentNullException("A ZIP code must be provided in order to geocode the city/state.");
      }

      // Else
      using (var client = new HttpClient()) {
        client.BaseAddress = new Uri("http://maps.googleapis.com/maps/api/geocode/json");

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // New code:
        HttpResponseMessage response = await client.GetAsync("?sensor=false&address=" + this.Zip);

        if (response.IsSuccessStatusCode) {
          var result = await response.Content.ReadAsStringAsync();
          var geocoding = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleGeocodeHttpModel>(result);

          try {
            this.City = geocoding.results[0].address_components.SingleOrDefault(ac => ac.types.Contains("locality")).short_name;
            this.State = geocoding.results[0].address_components.SingleOrDefault(ac => ac.types.Contains("administrative_area_level_1")).short_name;
          }
          catch {
            this.City = "Unknown";
            this.State = "Unknown";
          }
        }     
      }
    }

    public async Task Send() {
      var message = new MailMessage();

      message.From = new MailAddress("securitylighting@entergy.com", "New Security Lighting Lead");

      message.To.Add(Opco.GetOpcoEmailAddress(this.OpCo));

      message.Subject = string.Format("New Security Lighting lead from {0} {1}", this.FirstName, this.LastName);

      message.Body = string.Format(
        @"Name: {0} {1}\n
          Email: {2}\n
          City, State Zip: {3}, {4}, {5}\n
          Phone: {6}\n
          Best time to call: {7}\n
          Account type: {8}\n");

      await new SmtpClient().SendMailAsync(message);
    }
  }
}