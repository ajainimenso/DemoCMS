using Microsoft.AspNetCore.Mvc;
using SoapHttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Demoapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        public async Task<string> Index()
        {
            try
            {
                var client = new HttpClient();

                // string userName = "2013227";
                // string pass = "thI!W1x4";
                // string xmlcontent = "<?xml version=\"1.0\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"\nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>" + userName + "</ns1:UserName><ns1:Password>" + pass + "</ns1:Password></ns1:SecurityHeader></soap:Header>\n  <soap:Body>\n    <GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</soap:Envelope>\n";

                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("text/xml")); // ACCEPT header
                var request = new HttpRequestMessage(HttpMethod.Post, "https://services.hsp.transunion.com/submissionportal/submissionportal.asmx");
                request.Headers.Add("SOAPAction", "http://services.medconnect.net/submissionportal/GetResponsesBySubmissionId");
                var content = new StringContent("<?xml version=\"1.0\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"\nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>2013227</ns1:UserName><ns1:Password>thI!W1x4</ns1:Password></ns1:SecurityHeader></soap:Header>\n  <soap:Body>\n    <GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</soap:Envelope>\n", null, "text/xml");
                //var content = new StringContent("<?xml version =\"1.0\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"\nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>" + userName + "</ns1:UserName><ns1:Password>" + pass + "</ns1:Password></ns1:SecurityHeader></soap:Header>\n  <soap:Body>\n    <GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</soap:Envelope>\n", null, "text/xml");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
