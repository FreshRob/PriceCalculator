Feature: BasketTotalFeature
		
Scenario: No Offers
	Given The Basket has 1 Bread
	And The Basket has 1 Butter
	And The Basket has 1 Milk
	Then the total should be 2.95

Scenario: Bread Offer
	Given The Basket has 2 Bread
	And The Basket has 2 Butter
	Then the total should be 3.10

Scenario: Milk Offer
	Given The Basket has 4 Milk
	Then the total should be 3.45

Scenario: Bread and Milk Offer
	Given The Basket has 2 Butter
	And The Basket has 1 Bread
	And The Basket has 8 Milk
	Then the total should be 9.00