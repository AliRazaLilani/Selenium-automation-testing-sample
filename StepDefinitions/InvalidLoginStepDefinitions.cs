using System;
using TechTalk.SpecFlow;

namespace AliRaza.StepDefinitions
{
    [Binding]
    public class InvalidLoginStepDefinitions
    {
        LoginPageClass loginPageClass = new LoginPageClass();

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            loginPageClass.DriverInitiliaze();
            loginPageClass.OpenChromeWindow();
            loginPageClass.GoTOLoginPage();
        }

        [When(@"I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            loginPageClass.ClickOnLoginButton();
            loginPageClass.LoginMethodWithInvalidCred();
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            loginPageClass.ValidateUnSuccessfullLogin();
            loginPageClass.CloseDriver();
        }
    }
}
