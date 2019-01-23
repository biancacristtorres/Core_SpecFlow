using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Core_SpecFlow.Comuns
{
   [Binding]
    public class Hooks
    {

        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentReports extent;
        public static KlovReporter klov;
        

        #region Teste
        [BeforeTestRun]
        public static void InitializeReport()
        {
             
           if (ConfigurationManager.AppSettings["Klov"].ToString()  == "true")
            {
                var htmlReporter = new ExtentHtmlReporter(@"C:\Users\sayoan.oliveira\Documents\SpecFlowBasicSolAluno\SpecFlow.Basic\Logs\extendReport.html");

                extent = new ExtentReports();

                klov = new KlovReporter();
                klov.InitMongoDbConnection("ABHNTBNSI2964", 27017);
                klov.ProjectName = "SpecFlow Test";

                klov.KlovUrl = "http://abhntbnsi2964:899";
                klov.ReportName = "Base2 SpecFlow" + DateTime.Now.ToString();

                extent.AttachReporter(htmlReporter, klov);

            }



            


        }



        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            if (ConfigurationManager.AppSettings["Klov"].ToString() == "true")
            {
                extent.Flush();
            }
            
        }

        #endregion Teste


        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            if (ConfigurationManager.AppSettings["Klov"].ToString() == "true")
            {
                featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            }
        }


        [BeforeScenario]
        public void Initialize()
        {
            DriverFactory.CreateInstance();
            //Create dynamic scenario name
            if (ConfigurationManager.AppSettings["Klov"].ToString() == "true")
            {
                scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            }

        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            if (ConfigurationManager.AppSettings["Klov"].ToString() == "true")
            {
                var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();


                if (ScenarioContext.Current.TestError == null)
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }

        }
        [AfterScenario]
        public void ExitTest()
        {
            DriverFactory.QuitInstace();
        }

    }
}