using APITest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APITest.Hooks
{
    [Binding]
    internal class Hooks
    {
        public Hooks() 
        {
        }


        [BeforeTestRun]
        public static void TestRun()
        {
            //to do
            ConfigReader.InitConfigSetting();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //to do
        }

        [BeforeScenario]
        public void TestInitalize()
        {
            //to do
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //to do
        }


        [AfterStep]
        public void InsertReportingSteps()
        {
            //to do
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //to do
        }
    }
}
