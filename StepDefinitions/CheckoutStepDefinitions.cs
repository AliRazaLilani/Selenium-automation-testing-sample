using AliRaza.PageClass;
using System;
using TechTalk.SpecFlow;

namespace AliRaza.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        CheckoutClass checkoutClass = new CheckoutClass();

        [Given(@"I am logged in for checkout")]
        public void GivenIAmLoggedInForCheckout()
        {
            checkoutClass.DriverInitiliaze();
            checkoutClass.OpenChromeWindow();
            checkoutClass.MakeSureUserIsLoggedIn();
           
        }

        [Given(@"Products are in cart")]
        public void GivenProductsAreInCart()
        {
            checkoutClass.MakeSureCartHasProducts();
        }


        [When(@"I click on checkout button and fill in the required fields")]
        public void WhenIClickOnCheckoutButtonAndFillInTheRequiredFields()
        {
            checkoutClass.ClickOnPlaceOrderButton();
            checkoutClass.FillInRequiredFields();
            checkoutClass.ClickPurchaseButton();
        }

        [Then(@"I should see the order confirmation page")]
        public void ThenIShouldSeeTheOrderConfirmationPage()
        {
            checkoutClass.VerifyOrderConfirmation();
            // sleep for 5 seconds
            System.Threading.Thread.Sleep(5000);
            checkoutClass.CloseDriver();
        }
    }
}
