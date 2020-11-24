using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Transcriber_NunitTest
{
    public class objRepo
    {
        public IWebDriver driver;
        public WebDriverWait driverWait;
        public objRepo(IWebDriver driver){
            this.driver = driver;
            driverWait = new WebDriverWait(this.driver, System.TimeSpan.FromSeconds(20));
        }
        public void clickByLocators(string webElement, string locator){
            
            switch(locator) {
                case "Name":
                driverWait.Until(driver =>driver.FindElement(By.Name(webElement)).Displayed);
                driver.FindElement(By.Name(webElement)).Click();
                break;

                case "Id":
                driverWait.Until(driver =>driver.FindElement(By.Id(webElement)).Displayed);
                driver.FindElement(By.Id(webElement)).Click();
                break;

                case "Xpath":
                driverWait.Until(driver =>driver.FindElement(By.XPath(webElement)).Displayed);
                driver.FindElement(By.XPath(webElement)).Click();
                break;

                case "ClassName":
                driverWait.Until(driver =>driver.FindElement(By.ClassName(webElement)).Displayed);
                driver.FindElement(By.ClassName(webElement)).Click();
                break;

                case "CssSelector":
                driverWait.Until(driver =>driver.FindElement(By.CssSelector(webElement)).Displayed);
                driver.FindElement(By.ClassName(webElement)).Click();
                break;

                default:
                driverWait.Until(driver =>driver.FindElement(By.Name(webElement)).Enabled);
                driver.FindElement(By.Name(webElement)).Click();
                Console.WriteLine("The Type of locator is unavailable");
                break;
            }
        }

        public void enterDataByLocators(string webElement, string locator, string data){
            switch(locator) {
                case "Name":
                driverWait.Until(driver =>driver.FindElement(By.Name(webElement)).Displayed);
                driver.FindElement(By.Name(webElement)).SendKeys(data);
                break;

                case "Id":
                driverWait.Until(driver =>driver.FindElement(By.Id(webElement)).Displayed);
                driver.FindElement(By.Id(webElement)).SendKeys(data);
                break;

                case "Xpath":
                driverWait.Until(driver =>driver.FindElement(By.XPath(webElement)).Displayed);
                driver.FindElement(By.XPath(webElement)).SendKeys(data);
                break;

                case "ClassName":
                driverWait.Until(driver =>driver.FindElement(By.ClassName(webElement)).Displayed);
                driver.FindElement(By.ClassName(webElement)).SendKeys(data);
                break;

                default:
                driver.FindElement(By.Id(webElement)).SendKeys(data);
                Console.WriteLine("The Type of locator is unavailable");
                break;
            }
        }
        public void assertText(string actual, string expected){
            Assert.AreEqual(actual, expected);        
        }

        public string getElementText(IWebElement getElementText){
            driverWait.Until(driver => getElementText.Displayed);
            return getElementText.Text;
        }

        public string addTeam = "//span[contains(text(),'Add Team')]";
        public string loginBtn = "auth0-label-submit";
        public string txtLogin = "email";
        public string txtPassword = "password";
        public string txtTeam = "name";
        public string addTeamBtn = "//span[text()='Add']";
        public string newProjectBtn = "//span[contains(text(),'New Project')]";
        public string txtProjectName = "name";
        public string txtProjectDescription = "description";
        public string txtBoxLang = "lang-bcp47";
        public string txtLanguage = "language";
        public string selectLang = "//ul[contains(@class, 'MuiList-root')]/div[1]";
        public string saveLangBtn = "//p[text()='Save']";
        public string chkBoxTesting = "Testing";
        public string btnAddProj = "//span[text()='Add']";
        public string btnNewProj = "//h2[text()='Auto-Test-Project']";
        public string btnAddSection = "//span[text()='Add Section']";
        public string txtProjectTitle = "//td[@class='set cell selected editing']/input";
        public string txtReference = "//td[contains(@class,'passErr')]/input";
        public string tableCell = "//td[@class='pass cell']";
        public string browserUpload = "//button[@title='Upload Media']";
        public string uploadFile = "upload";
        public string btnUpload = "//span[text()='Upload']";
        public string iconTranscribe = "//button[@title='Transcribe']";
        public string txtTranscriber = "//textarea[1]";
        public string btnSubmit = "//span[text()='Submit']";
        public string iconHome = "//h6[contains(@class,'MuiTypography-root')][1]/../button/span[1]";
        public string drpSetting = "//h5[text()='Auto-Test-Team']/following-sibling::div/button[2]";
        public string drpAdvance = "//p[text()='Advanced']/../following-sibling::div//span[1]";
        public string btnDelete = "//button[@aria-label='Delete']";
        public string popupYes = "//span[text()='Yes']";
        public string clickTeamBtn = "//h5[text()='Auto-Test-Team']/../following-sibling::div/div[1]//div";
        public string imgAvatar = "//img[@class='MuiAvatar-img']";
        public string menuLogout = "//span[text()='Log Out']";
        // public string imgLoad = "//img[@alt='busy']";

        public IWebElement imgLoadElement(){
            return driver.FindElement(By.XPath("//img[@alt='busy']"));
        }
        public IWebElement messageText(){
            return driver.FindElement(By.XPath("//span[@id='message-id']"));
        }
        public IWebElement transcriberStatus(){
            return driver.FindElement(By.XPath("//span[contains(@class,'MuiChip-label')]"));
        }
               
    }
}