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
using System.Security.Policy;

namespace AliRaza.PageClass
{
    public class AddToCartClass : LoginPageClass
    {
            public JObject jsonData = JObject.Parse(File.ReadAllText("C:\\Fast\\AST\\21K4203-Final-Project\\data.json"));

        public void MakeSureUserIsLoggedIn()
        {
            GoTOLoginPage();
            ClickOnLoginButton();
            LoginMethod();
            ValidateSuccessfullLogin();
        }

        public void GoToProductPage()
        {
            chromeDriver.FindElement(By.CssSelector(Locators.ProductLink)).Click();
        }

        public void AddProductToCart()
        {
            // wait for the element to be clickable
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(Locators.AddToCartButton)));
            
            chromeDriver.FindElement(By.CssSelector(Locators.AddToCartButton)).Click();
        }

        public void VerifyProductAdditionFromAlert()
        {
            string expectedMessage = jsonData["productAddedToCartAlert"].ToString();
            
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            string actualMessage = chromeDriver.SwitchTo().Alert().Text;
            chromeDriver.SwitchTo().Alert().Accept();
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        public void GoToCartPage()
        {
            chromeDriver.FindElement(By.CssSelector(Locators.CartLink)).Click();
        }

        public void VerifyProductInCart()
        {
            // total of cart should be more than 0

            // Wait for the element to be visible
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(Locators.CartTotalText)));

            string total = chromeDriver.FindElement(By.CssSelector(Locators.CartTotalText)).Text;

            Assert.AreNotEqual(total, "0.00");
        }
    }
}
