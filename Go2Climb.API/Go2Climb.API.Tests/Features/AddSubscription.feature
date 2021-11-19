Feature: AddSubscription
	As owner I want to add a new subscription so that my users can subscribe to it 

@subscription-adding
Scenario: Add new subscription to my agency 
	Given the owner wants to add on subscription endpoint
	When owner add a new subscription
	| Name     | Price | Description
	| Freemium | 0     |It's free
	Then the subscription will be added successfully