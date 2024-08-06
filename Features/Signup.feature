Feature: Signup

This loads the website and register the user

@tag5
Scenario: Register a new user
	Given Go to the website
	And Click on the signup button
	When Fill the form with valid data
	Then User should be registered successfully
