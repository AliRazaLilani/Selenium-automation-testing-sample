using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;


namespace AliRaza
{
    public class LoginPageClass : BaseClass
    {

        public JObject jsonData = JObject.Parse(File.ReadAllText("C:\\Fast\\AST\\21K4203-Final-Project\\data.json"));

        public void GoTOLoginPage()
        {
            string url = jsonData["url"].ToString();
            chromeDriver.Navigate().GoToUrl(url);
        }

        public void ClickOnLoginButton()
        {
            chromeDriver.FindElement(By.CssSelector(Locators.LoginButton)).Click();
        }

        public void ClickOnSignupButton()
        {
            chromeDriver.FindElement(By.CssSelector(Locators.SignupButton)).Click();
        }

        public void LoginMethod()
        {
            string userName = jsonData["username"].ToString();
            string password = jsonData["password"].ToString();

            // wait for the element to be clickable
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(Locators.UserName)));
            

            chromeDriver.FindElement(By.CssSelector(Locators.UserName)).SendKeys(userName);
            chromeDriver.FindElement(By.CssSelector(Locators.Password)).SendKeys(password);

            chromeDriver.FindElement(By.CssSelector(Locators.loginButtonSubmit)).Click();

        }

        public void SignupMethod()
        {
            // usename with timestamp to make it unique
            string userName = jsonData["username"].ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string password = jsonData["password"].ToString();

            // wait for the element to be clickable
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(Locators.SignupUserName)));


            chromeDriver.FindElement(By.CssSelector(Locators.SignupUserName)).SendKeys(userName);
            chromeDriver.FindElement(By.CssSelector(Locators.SignupPassword)).SendKeys(password);

            chromeDriver.FindElement(By.CssSelector(Locators.SignupButtonSubmit)).Click();

        }

        public void LoginMethodWithInvalidCred()
        {
            string userName = jsonData["username"].ToString();
            string password = jsonData["invalidPassword"].ToString();

            // wait for the element to be clickable
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(Locators.UserName)));


            chromeDriver.FindElement(By.CssSelector(Locators.UserName)).SendKeys(userName);
            chromeDriver.FindElement(By.CssSelector(Locators.Password)).SendKeys(password);
            chromeDriver.FindElement(By.CssSelector(Locators.loginButtonSubmit)).Click();

        }

        public void ValidateSuccessfullLogin()
        {
            string logOutText = jsonData["logoutText"].ToString();
            
            // Wait for the element to be visible
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(Locators.logoutInHeaderText)));
            string text = chromeDriver.FindElement(By.CssSelector(Locators.logoutInHeaderText)).Text;
            Assert.AreEqual(text, logOutText);
        }

        public void ValidateSuccessfullSignup()
        {
            string expectedMessage = jsonData["succesfullsignuptext"].ToString();

            // wait for the alert to be present
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            
            // sleep for 2 seconds for visibility
            System.Threading.Thread.Sleep(2000);

            string actualMessage = chromeDriver.SwitchTo().Alert().Text;
            chromeDriver.SwitchTo().Alert().Accept();
            Assert.AreEqual(expectedMessage, actualMessage);
        }


        public void ValidateUnSuccessfullLogin()
        {
            string invalidTextAlert = jsonData["InvalidCredentialsAlertText"].ToString();

            // Wait for the element to be visible
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            try
            {
                IAlert alert = chromeDriver.SwitchTo().Alert();
                string alertText = alert.Text;

                Assert.AreEqual(alertText, invalidTextAlert);

                if (alertText.Contains(invalidTextAlert))
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
            }
            catch (NoAlertPresentException)
            {
                // Handle case when no alert is present
                // You can add logging or further actions here
            }
        }
    }
}