Feature: LoginFeature

This loads the website and login the user.

@tag1
Scenario: Login with valid credentials
	Given Open the browser and go to the website
	And Click on the login button
	When Enter the valid username and password
	Then User should be able to login successfully
	
