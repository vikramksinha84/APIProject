using APITest.TestData;
using APITest.Utilities;
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
    internal class BankSystemStepDefinitioms
    {
        private Settings _settings;
        EmployeeObject? payload=null;
        //Using Context injection to intilize and hsre the data
        public BankSystemStepDefinitioms(Settings settings)
        {
            _settings = settings;
            _settings.RestClient = _settings.Lib?.PerformRequest(Settings.BankBaseUrl);
        }

        [Given(@"User Perform POST endpoint ""([^""]*)"" to create new account with above details")]
        public void GivenUserPerformPOSTEndpointToCreateNewAccountWithAboveDetails(string uri)
        {
            //Deserialize json Data
            payload = _settings.Lib?.PerseJson<EmployeeObject>(_settings.Lib.GetTestDataPath("BankSystemData"));
            //SerializeJson payload to pass as bodey fpr POst
            var requestdata = _settings.Lib?.SerializeJson(payload);
            //Request for POst
            _settings.Request = _settings.Lib?.GetRequest(uri, Method.Post);
            //Perform POst with body requestdata
            _settings.Lib?.AddPostRequestBody(_settings.Request, requestdata);
            //Getting Response as Model Object
            _settings.Response = _settings.RestClient.Execute<EmployeeObject>(_settings.Request);
        }

        [When(@"user the response code is (.*)")]
        public void WhenUserTheResponseCodeIs(int status)
        {
            Assert.True(((int?)_settings.Response?.StatusCode).Equals(status), "Expected Status Code is:- " + 7 + " But Found:- " + (int?)_settings.Response?.StatusCode);
        }

        [Then(@"Verify no error is returned")]
        public void ThenVerifyNoErrorIsReturned()
        {
            string? sreult = _settings.Lib?.GetResponseObject(_settings.Response, "Errors");
            Assert.True(String.IsNullOrEmpty(sreult), "ErrorIs Returned");
        }

        [Then(@"Verify the success '([^']*)' message")]
        public void ThenVerifyTheSuccessMessage(string SuccessMessage)
        {
            string? sreult = _settings.Lib?.GetResponseObject(_settings.Response, "Message");
             _settings.Lib?.AssetTrue(sreult, SuccessMessage);
        }

        [Then(@"Verify the account details are correctly returned in the JSON response")]
        public void ThenVerifyTheAccountDetailsAreCorrectlyReturnedInTheJSONResponse()
        {
            _settings.Lib?.AssetTrue(_settings.Response.As<EmployeeObject>().AccountName, payload?.AccountName);
            _settings.Lib?.AssetTrue(_settings.Response.As<EmployeeObject>().Address, payload?.Address);
        }

        [Given(@"User Perform PUT endpoint ""([^""]*)"" to an account with amount ""([^""]*)""")]
        public void GivenUserPerformPUTEndpointToAnAccountWithAmount(string uri, string jsonfile)
        {
            payload = _settings.Lib?.PerseJson<EmployeeObject>(_settings.Lib.GetTestDataPath(jsonfile));
            //SerializeJson payload to pass as bodey fpr POst
            var requestdata = _settings.Lib?.SerializeJson(payload);
            //Request for Put
            _settings.Request = _settings.Lib?.GetRequest(uri, Method.Put);
            //Perform POst with body requestdata
            _settings.Lib?.AddPostRequestBody(_settings.Request, requestdata);
            //Getting Response as Model Object
            _settings.Response = _settings.RestClient.Execute<EmployeeObject>(_settings.Request);
        }

        [Then(@"Verify the account details are correctly updated as (.*) in the JSON response")]
        public void ThenVerifyTheAccountDetailsAreCorrectlyUpdatedAsInTheJSONResponse(int ExpactedNewBalance)
        {
            Assert.True(_settings.Response.As<EmployeeObject>().NewBalance.Equals(ExpactedNewBalance));
        }

        [Given(@"User Perform DELETE endpoint ""([^""]*)"" to delete an account ""([^""]*)""")]
        public void GivenUserPerformDELETEEndpointToDeleteAnAccount(string uri, string acoountId)
        {
            _settings.Request = _settings.Lib?.GetRequest(uri, Method.Delete);
            _settings.Request.AddUrlSegment("accountID", acoountId);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

    }
}
