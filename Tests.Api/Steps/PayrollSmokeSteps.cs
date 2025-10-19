using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using Reqnroll;
using Microsoft.Extensions.Configuration;

namespace Tests.Api.Steps
{
    [Binding]
    public class PayrollSmokeSteps
    {
        private readonly IConfiguration _cfg;
        private RestResponse? _resp;

        public PayrollSmokeSteps()
        {
            _cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        [Given(@"the payroll API is available")]
        public void GivenThePayrollApiIsAvailable() { }

        [When(@"I GET ""(.*)""")]
        public void WhenIGet(string path)
        {
            var baseUrl = _cfg["BaseUrl"] ?? "http://localhost:9091";
            var client = new RestClient(baseUrl);
            var req = new RestRequest(path, Method.Get);
            _resp = client.Execute(req);
        }

        [Then(@"the response code is (.*)")]
        public void ThenTheResponseCodeIs(int expected)
        {
            Assert.That((int)(_resp?.StatusCode ?? 0), Is.EqualTo(expected));
        }
    }
}


