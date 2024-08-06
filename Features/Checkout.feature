Feature: Checkout

Checkout with products in cart

@tag4
Scenario: User checks out with products in cart
	Given I am logged in for checkout
	And Products are in cart
	When I click on checkout button and fill in the required fields
	Then I should see the order confirmation page
