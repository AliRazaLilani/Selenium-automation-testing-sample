using System;
using TechTalk.SpecFlow;

namespace AliRaza.StepDefinitions
{
    [Binding]
    public class SignupStepDefinitions
    {
        LoginPageClass loginPageClass = new LoginPageClass();

        [Given(@"Go to the website")]
        public void GivenGoToTheWebsite()
        {
            loginPageClass.DriverInitiliaze();
            loginPageClass.OpenChromeWindow();
            loginPageClass.GoTOLoginPage();
        }

        [Given(@"Click on the signup button")]
        public void GivenClickOnTheSignupButton()
        {
            loginPageClass.ClickOnSignupButton();
        }

        [When(@"Fill the form with valid data")]
        public void WhenFillTheFormWithValidData()
        {
            loginPageClass.SignupMethod();
        }

        [Then(@"User should be registered successfully")]
        public void ThenUserShouldBeRegisteredSuccessfully()
        {
            loginPageClass.ValidateSuccessfullSignup();
            loginPageClass.CloseDriver();
        }
    }
}
