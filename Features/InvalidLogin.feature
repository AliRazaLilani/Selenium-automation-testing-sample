Feature: InvalidLogin

This loads the website and enters invalid login credentials to test the error message.

@tag2
Scenario: Login with invalid credentials
	Given I am on the login page
	When I enter invalid credentials
	Then I should see an error message
