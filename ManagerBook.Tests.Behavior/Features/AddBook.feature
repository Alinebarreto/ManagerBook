Feature: Add new book
As administrator
I want to register a new book
for a user to borrow

@AddBook
Scenario: Add new book
	Given I have a new book
	And there are 5 book registered
	When it is registered	
	Then it should be available in stock with 6 items left