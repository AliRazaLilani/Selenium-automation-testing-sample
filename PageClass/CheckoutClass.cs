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
using System.Runtime.CompilerServices;

namespace AliRaza.PageClass
{
    public class CheckoutClass : AddToCartClass
    {
        public JObject jsonData = JObject.Parse(File.ReadAllText("C:\\Fast\\AST\\21K4203-Final-Project\\data.json"));

       

       

        public void MakeSureCartHasProducts()
        {
            GoToProductPage();
            AddProductToCart();
            VerifyProductAdditionFromAlert();
            GoToCartPage();
            VerifyProductInCart();


        }


        public void ClickOnPlaceOrderButton()
        {
            chromeDriver.FindElement(By.CssSelector(Locators.PlaceOrderButton)).Click();
        }

        public void FillInRequiredFields()
        {
            string name = jsonData["name"].ToString();
            string country = jsonData["country"].ToString();
            string city = jsonData["city"].ToString();
            string creditCard = jsonData["creditCard"].ToString();
            string month = jsonData["month"].ToString();
            string year  = jsonData["year"].ToString();

            // wait for the popup to be visible
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(Locators.Name)));

            chromeDriver.FindElement(By.CssSelector(Locators.Name)).SendKeys(name);
            chromeDriver.FindElement(By.CssSelector(Locators.Country)).SendKeys(country);
            chromeDriver.FindElement(By.CssSelector(Locators.City)).SendKeys(city);
            chromeDriver.FindElement(By.CssSelector(Locators.CreditCard)).SendKeys(creditCard);
            chromeDriver.FindElement(By.CssSelector(Locators.Month)).SendKeys(month);
            chromeDriver.FindElement(By.CssSelector(Locators.Year)).SendKeys(year);

        }

        public void ClickPurchaseButton()
        {
            chromeDriver.FindElement(By.CssSelector(Locators.PurchaseButton)).Click();
        }

        public void VerifyOrderConfirmation()
        {
            //Wait for the element to be visible
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Locators.OrderConfirmationText)));

            string expectedText = jsonData["orderConfirmationText"].ToString();
            string text = chromeDriver.FindElement(By.XPath(Locators.OrderConfirmationText)).Text;
            Assert.AreEqual(text, expectedText);

        }




    }
}
