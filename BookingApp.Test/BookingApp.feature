Feature: BookingApp
	In order to reserve a table	for 2 people
	I want to make a booking now

@mytag
Scenario: Make a booking for two people
	Given The the customer has created a booking for 2 people
	When they confirm
	Then the customer should get a confirmation email
