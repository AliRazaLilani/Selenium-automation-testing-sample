using AliRaza.PageClass;
using System;
using TechTalk.SpecFlow;

namespace AliRaza.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        AddToCartClass addToCartClass = new AddToCartClass();

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            addToCartClass.DriverInitiliaze();
            addToCartClass.OpenChromeWindow();
            addToCartClass.MakeSureUserIsLoggedIn();
        }

        [Given(@"Go to the Produt page")]
        public void GivenGoToTheProdutPage()
        {
            addToCartClass.GoToProductPage();
        }

        [When(@"I add the product to the cart")]
        public void WhenIAddTheProductToTheCart()
        {
            addToCartClass.AddProductToCart();
            addToCartClass.VerifyProductAdditionFromAlert();
        }

        [Then(@"I should see the product in the cart")]
        public void ThenIShouldSeeTheProductInTheCart()
        {
            addToCartClass.GoToCartPage();
            addToCartClass.VerifyProductInCart();
            addToCartClass.CloseDriver();
        }
    }
}
