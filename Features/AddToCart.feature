Feature: AddToCart

When a user is logged in , add product to the cart

@tag3
Scenario: Add product to the cart
	 Given I am logged in
	 And Go to the Produt page
	 When I add the product to the cart
	 Then I should see the product in the cart
