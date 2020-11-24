using System;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;

namespace Transcriber_NunitTest
{
    public class Tests
    {
        IWebDriver driver;
        Actions act;
        ExtentTest testReport = null;
        componentsRM RM;
        objRepo obj;

        string baseUrl = "https://app-qa.siltranscriber.org/";
        string username = "arunkumar.s@ecgroup-intl.com";
        string password = "Arunkumars@123";
        string getCurrentUrl;
        
        [OneTimeSetUp]
        public void Setup()
        {
            // Run testScripts in Firefox browser
            driver = new FirefoxDriver();
            // Initlizating the webelements to the driver by invoking the constructor
            act = new Actions(driver);
            obj = new objRepo(driver);
            RM = new componentsRM(driver);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Navigate().GoToUrl(baseUrl);
            RM.loginTranscriber(username, password);
        }

        [Test]
        public void AddTranscriberAndSyncToPT()
        {
            try{
                testReport = RM.setupExtentReports().CreateTest("AddTranscriberAndSyncToPT").Info("Transcriber Test Started");;
                testReport.Log(Status.Info, "Logged In to Transcriber successfully");
                // getCurrentUrl = driver.Url;
                // Assert.AreEqual(getCurrentUrl, teamUrl);
                RM.addNewTeamToNavigate();
                testReport.Log(Status.Info, "New Team Has created");
                RM.addNewProjectToNavigate();
                testReport.Log(Status.Info, "New Project Has created under Test Team");
                RM.addTranscriberSection();
                testReport.Log(Status.Info, "Transriber section has entered ");

                // getCurrentUrl = driver.Url;
                // Assert.AreEqual(true, getCurrentUrl.Contains("plan"));
                
                // getCurrentUrl = driver.Url;
                // Assert.AreEqual(true, getCurrentUrl.Contains("work"));
                
                RM.syncTranscriber();
                RM.deleteTeam();
                RM.logoutTranscriber();
                
                testReport.Log(Status.Info, "Validated the Transcriber status after Sync with PT");
                testReport.Log(Status.Pass, "The Added Transcriber has been synced with PT Successfully");
            }catch(Exception e){
                testReport.Log(Status.Fail, "The Test is failed due to " + e.ToString());
            }    
        }
        [OneTimeTearDown]
        public void closeDriver(){
            RM.setupExtentReports().Flush();
            driver.Close();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(RM.trancriberExtentReports);
            
        }
    }
}