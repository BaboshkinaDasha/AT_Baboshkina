Feature: CreateNewProduct
	As a user
	I want to create a new product

Scenario: Create new product
	Given I login to "http://localhost:5000/"
	When I click on All Products button
	And I click on Create New button
	And I enter values "Fanta", "Beverages", "Exotic Liquids", "40", "50", "20", "0", "10", "true" and click btn
	Then Edit form close
