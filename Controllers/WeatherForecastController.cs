using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Demoapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        //withoutdynamic 
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




        //for dynamic 
//        public async Task<string> Index()
//        {
//            try
//            {
               
//        string username = "2013227";
//        string password = "thI!W1x4";
//        string xml = @"<?xml version=""1.0""?>
//    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
//        xmlns:ns1=""http://services.medconnect.net/submissionportal"">
//        <soap:Header>
//            <ns1:SecurityHeader>
//                <ns1:UserName>{0}</ns1:UserName>
//                <ns1:Password>{1}</ns1:Password>
//            </ns1:SecurityHeader>
//        </soap:Header>
//        <soap:Body>
//            <GetResponsesBySubmissionId xmlns=""http://services.medconnect.net/submissionportal"">
//                <submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>
//                <responseFormat>EDI</responseFormat>
//                <overrideSent>true</overrideSent>
//            </GetResponsesBySubmissionId>
//        </soap:Body>
//    </soap:Envelope>";

//        var client = new HttpClient();
//        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
//var request = new HttpRequestMessage(HttpMethod.Post, "https://services.hsp.transunion.com/submissionportal/submissionportal.asmx");
//        request.Headers.Add("SOAPAction", "http://services.medconnect.net/submissionportal/GetResponsesBySubmissionId");
//var content = new StringContent(string.Format(xml, username, password), Encoding.UTF8, "text/xml");
//        request.Content = content;

//var response = await client.SendAsync(request);
//        response.EnsureSuccessStatusCode();
//return await response.Content.ReadAsStringAsync();
//    }
//            catch (Exception e)
//            {

//                throw e;
//            }
//        }



















        //    public async Task<string> Index()
        //    {
        //    try
        //    {
        //    var soapClient = new SoapClient();
        //    //var request = new HttpRequestMessage(HttpMethod.Post, "https://services.hsp.transunion.com/submissionportal/submissionportal.asmx");
        //    //request.Headers.Add("SOAPAction", "http://services.medconnect.net/submissionportal/GetResponsesBySubmissionId");
        //    var content = new StringContent("<?xml version=\"1.0\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" \nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>2013227</ns1:UserName><ns1:Password>thI!W1x4</ns1:Password></ns1:SecurityHeader></soap:Header>\n<soap:Body>\n<GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</ soap:Envelope >\n", null, "text/xml");
        //    //request.Content = content;
        //    var ns = XNamespace.Get("https://services.hsp.transunion.com/");
        //    var response =await soapClient.PostAsync(new Uri("http://services.medconnect.net/submissionportal/GetResponsesBySubmissionId"),SoapVersion.Soap11, body: content);
        //    // var response = await client.PostAsync("Uri",'',"");
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsStringAsync();

        //    }

        //catch (Exception e)
        //        {
        //            throw e;
        //        }

        //    }

        //public async Task<string> Index()
        //{
        //    try
        //    {
        //        var soapClient = new SoapClient();
        //        //  var request = new HttpRequestMessage(HttpMethod.Post, "https://services.hsp.transunion.com/submissionportal/submissionportal.asmx");
        //        //  request.Headers.Add("SOAPAction", "http://services.medconnect.net/submissionportal/GetResponsesBySubmissionId");
        //        // var content = new StringContent("<?xml version=\"1.0\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" \nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>2013227</ns1:UserName><ns1:Password>thI!W1x4</ns1:Password></ns1:SecurityHeader></soap:Header>\n<soap:Body>\n<GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</ soap:Envelope >\n", null, "text/xml");
        //        // request.Content = content;
        //        //   String rawXml =@"<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" \nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>2013227</ns1:UserName><ns1:Password>thI!W1x4</ns1:Password></ns1:SecurityHeader></soap:Header>\n<soap:Body>\n<GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</ soap:Envelope >\n", null, "text/xml");


        //        var ns = XNamespace.Get("http://services.hsp.transunion.com/submissionportal/submissionportal.asmx");
        //        var content = new StringContent("<?xml version=\"1.0\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" \nxmlns:ns1=\"http://services.medconnect.net/submissionportal\">\n<soap:Header><ns1:SecurityHeader><ns1:UserName>2013227</ns1:UserName><ns1:Password>thI!W1x4</ns1:Password></ns1:SecurityHeader></soap:Header>\n<soap:Body>\n<GetResponsesBySubmissionId xmlns=\"http://services.medconnect.net/submissionportal\">\n<submissionId>2f97c99c-1c51-419e-8b9f-8abfe70fd7b7</submissionId>\n<responseFormat>EDI</responseFormat>\n<overrideSent>true</overrideSent>\n</GetResponsesBySubmissionId>\n</soap:Body>\n</ soap:Envelope >\n", null, "text/xml");
        //        var response = await soapClient.PostAsync(new Uri("http://services.medconnect.net/submissionportal/GetResponsesBySubmissionId"), SoapVersion.Soap11, body: new XElement(ns.GetName("2")));
        //       // response.EnsureSuccessStatusCode();
        //        return await response.Content.ReadAsStringAsync();





        //        //var soapClient = new SoapClient();
        //        //    var ns = XNamespace.Get("http://helio.spdf.gsfc.nasa.gov/");

        //        //    var result =
        //        //        await soapClient.PostAsync(
        //        //            new Uri("http://sscweb.gsfc.nasa.gov:80/WS/helio/1/HeliocentricTrajectoriesService"),
        //        //            SoapVersion.Soap11,
        //        //            body: new XElement(ns.GetName("getAllObjects")));

        //        // result.StatusCode.Should().Be(HttpStatusCode.OK);
        //        //return result;

        //    }
        //   catch (Exception e)
        //    {
        //        throw e;
        //    }

        //}



    }
}

    