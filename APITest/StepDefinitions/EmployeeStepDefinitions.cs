using APITest.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.StepDefinitions
{
    [Binding]
    internal class EmployeeStepDefinitions
    {
        private Settings _settings;
        //Using Context injection to intilize and hsre the data
        public EmployeeStepDefinitions(Settings settings)
        {
            _settings = settings;
            _settings.RestClient = _settings.Lib?.PerformRequest(Settings.EmployeeBaseUrl);
        }

        [Given(@"user perform the GET operation for emdpoit ""([^""]*)""")]
        public void GivenUserPerformTheGETOperationForEmdpoit(string uri)
        {
            _settings.Request = _settings.Lib?.GetRequest(uri, Method.Get);
        }

        [When(@"User executes the GET request for authscheduler")]
        public void WhenUserExecutesTheGETRequestForAuthscheduler()
        {
            _settings.Response = _settings.RestClient.Execute(_settings.Request);      
        }

        [Then(@"user should get (.*) status code")]
        public void ThenUserShouldGetStatusCode(int p0)
        {
            string? sreult = _settings.Lib?.GetResponseObject(_settings.Response, "status");
            _settings.Lib?.AssetTrue(sreult, "success");
        }

    }
}
