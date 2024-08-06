using System;
using TechTalk.SpecFlow;

namespace AliRaza.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions
    {
        LoginPageClass loginPageClass = new LoginPageClass();

        [Given(@"Open the browser and go to the website")]
        public void GivenOpenTheBrowserAndGoToTheWebsite()
        {
            loginPageClass.DriverInitiliaze();
            loginPageClass.OpenChromeWindow();
            loginPageClass.GoTOLoginPage();
        }

        [Given(@"Click on the login button")]
        public void GivenClickOnTheLoginButton()
        {
            loginPageClass.ClickOnLoginButton();
        }

        [When(@"Enter the valid username and password")]
        public void WhenEnterTheValidUsernameAndPassword()
        {
            loginPageClass.LoginMethod();
        }

        [Then(@"User should be able to login successfully")]
        public void ThenUserShouldBeAbleToLoginSuccessfully()
        {
            loginPageClass.ValidateSuccessfullLogin();
            loginPageClass.CloseDriver();

        }
    }
}
