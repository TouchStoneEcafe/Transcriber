using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Transcriber_NunitTest
{
    public class componentsRM
    {
        IWebDriver driver;
        WebDriverWait waitDriver;
        ExtentReports extent = null;
        Actions act;
        objRepo obj;
        public string trancriberExtentReports = "D:\\ArunSekar\\Transcriber-NunitTest\\TestReports\\Transcriber.html";
        
        public componentsRM(IWebDriver driver){
            this.driver = driver;
            obj = new objRepo(driver);
            act = new Actions(driver);
            waitDriver = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(50));
        }
        
        public void loginTranscriber(string username, string password){
            obj.enterDataByLocators(obj.txtLogin, "Name", username);
            obj.enterDataByLocators(obj.txtPassword, "Name", password);
            obj.clickByLocators(obj.loginBtn, "ClassName");
        }

        public void logoutTranscriber(){
            obj.clickByLocators(obj.imgAvatar, "Xpath");
            obj.clickByLocators(obj.menuLogout, "Xpath");
        }
        public void deleteTeam(){
            obj.clickByLocators(obj.iconHome, "Xpath");
            obj.clickByLocators(obj.drpSetting, "Xpath");
            obj.clickByLocators(obj.drpAdvance, "Xpath");
            obj.clickByLocators(obj.btnDelete, "Xpath");
            obj.clickByLocators(obj.popupYes, "Xpath");
            System.Threading.Thread.Sleep(4000);
        }

        public void addNewTeamToNavigate(){
            obj.clickByLocators(obj.addTeam, "Xpath");
            obj.enterDataByLocators(obj.txtTeam, "Id", "Auto-Test-Team");
            obj.clickByLocators(obj.addTeamBtn, "Xpath");
            obj.clickByLocators(obj.clickTeamBtn, "Xpath");
            //Assert.AreEqual(true, newTeam);
        }

        public void addNewProjectToNavigate(){
            obj.clickByLocators(obj.newProjectBtn, "Xpath");
            obj.enterDataByLocators(obj.txtProjectName, "Id", "Auto-Test-Project");
            obj.enterDataByLocators(obj.txtProjectDescription, "Id", "Auto-Test-Project-Description");
            obj.clickByLocators(obj.txtBoxLang, "Id");
            obj.enterDataByLocators(obj.txtLanguage, "Id", "Eng");
            obj.clickByLocators(obj.selectLang, "Xpath");
            obj.clickByLocators(obj.saveLangBtn, "Xpath");
            obj.clickByLocators(obj.chkBoxTesting, "default");
            obj.clickByLocators(obj.btnAddProj, "Xpath");
            System.Threading.Thread.Sleep(5000);
            obj.clickByLocators(obj.btnNewProj, "Xpath");
        }

        public void addTranscriberSection(){
            obj.clickByLocators(obj.btnAddSection, "Xpath");
            act.DoubleClick(driver.FindElement(By.XPath("//td[@class='set cell']"))).Perform();
            obj.enterDataByLocators(obj.txtProjectTitle, "Xpath", "Title of the Project");
            Console.WriteLine("Before Dobule Cliecked on Book Cell");
            
            act.DoubleClick(driver.FindElement(By.XPath("//td[@class='book pass cell']"))).Build().Perform();
            Console.WriteLine("Dobule Cliecked on Book Cell");
            driver.FindElement(By.XPath("//div[contains(text(),'Select Book')]/following-sibling::div//input")).SendKeys("Luke" + Keys.Enter);
            act.DoubleClick(driver.FindElement(By.XPath("//td[contains(@class,'passErr')]"))).Perform();
            
            obj.enterDataByLocators(obj.txtReference, "Xpath", "1:1-4");
            obj.clickByLocators(obj.tableCell, "Xpath");
            obj.clickByLocators(obj.browserUpload, "Xpath");
            obj.enterDataByLocators(obj.uploadFile, "default", "C:\\Users\\admin\\Downloads\\testAudio.mp3");
            obj.clickByLocators(obj.btnUpload, "Xpath");
            /* componentsRM.waitUntilElementDisappear(obj.imgLoadElement());
            waitDriver.Until(driver => obj.messageText().Displayed);
            componentsRM.waitUntilElementDisappear(obj.messageText()); */
            System.Threading.Thread.Sleep(15000);
            obj.clickByLocators(obj.iconTranscribe, "Xpath");
        }

        public void syncTranscriber(){
            waitDriver.Until(driver => obj.transcriberStatus().Displayed);
            obj.assertText(obj.getElementText(obj.transcriberStatus()), "Transcribe");
            
            obj.enterDataByLocators(obj.txtTranscriber, "Xpath", "Enter Some Text by listening audio file for Testing purpose");
            obj.clickByLocators(obj.btnSubmit, "Xpath");
            System.Threading.Thread.Sleep(5000);
            obj.assertText(obj.getElementText(obj.transcriberStatus()), "Review");
            
            obj.clickByLocators(obj.btnSubmit, "Xpath");
            System.Threading.Thread.Sleep(6000);
            obj.assertText(obj.getElementText(obj.transcriberStatus()), "Ready to Sync");
            System.Threading.Thread.Sleep(4000);
        }

        public static void waitUntilElementDisappear(IWebElement webElement){
            bool loading = false;
            do{
                    try{
                        loading = webElement.Displayed;
                        System.Threading.Thread.Sleep(1000);
                    } catch(Exception e){
                        Console.WriteLine(e.StackTrace);
                    }
                }while(loading == true);

        }
        public ExtentReports setupExtentReports(){
            extent = new ExtentReports();
            var htmlReports = new ExtentHtmlReporter(trancriberExtentReports);
            extent.AttachReporter(htmlReports);
            return extent;
        }
    }
}