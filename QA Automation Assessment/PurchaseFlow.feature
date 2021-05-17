Feature: 
Simple purchase flow for eGifter

@eGifter1
Scenario: purchase flow end to end test
Given I have navigated to the "staging" environment
When I click "Buy Gift Cards" menu option
Then I wait for the gift catalog to load
When I choose the category "Movies&Entertainment"
And I choose the brand "AMC Theatres" from the catalog
And I choose the 50 dollar value
And I add the item to the cart using the "Buy for Myself" button
Then I ensure cart page has loaded correctly and displays the item and the total amount due
When I navigate to the checkout page using the "Proceed To Checkout" button
Then I ensure the page has loaded correctly and a summary of items is shown on the left
When I click the button "Continue as Guest"
Then I ensure payment methods are shown properly
When I choose the "CreditCard" payment method
And I verify my phone number
And I fill out my card information
And I click "Checkout Now"
Then I Ensure that the Order Confirmation page loads and displays the order details properly



