Feature: BookingApp
		 In order to check the booking functionality
		 We will create bookings

@mytag
Scenario: Make a booking for two people
	Given The the customer has created a booking for 2 people
	When they confirm with no credit card
	Then the customer should get a confirmation email

@mytag
Scenario: Make a booking for 1 person
	Given The the customer has created a booking for 1 people
	Then the customer should get a not enough people error

@mytag
Scenario: Make a booking outside work hours
	Given The the customer has created a booking outside work hours
	Then the customer should get an outside work hours error

@mytag
Scenario: Make a booking and confirm with credit card
	Given The the customer has created a booking for 10 people
	When they confirm with credit card of ABC
	Then the customer should get a confirmation email

@mytag
Scenario: Make a booking for ten people and confirm without credit card
	Given The the customer has created a booking for 10 people
	When they confirm with no credit card
	Then the customer should get an no credit card error

@mytag
Scenario: Make a booking for ten people and confirm with credit card and then cancel
	Given The the customer has created a booking for 10 people
	When they confirm with credit card of ABC
	And they cancel the booking
	Then the customer should be charged 200 dollars

@mytag
Scenario: Make a booking for ten people with dietary requirement and confirm with credit card and then cancel
	Given The the customer has created a booking for 10 people
	And The booking has dietary requirements
	When they confirm with credit card of ABC
	And they cancel the booking
	Then the customer should be charged 225 dollars
