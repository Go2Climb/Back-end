Feature: AddAgency
	As Agency Owner I want to create my account in the web application for my business to grow

@agency-adding
Scenario: Create new Agency 
	Given I want to create a new Agency 
	When I create a new Agency 
	| Name     | Email              | PhoneNumber | Description | Location     | Ruc      |
	| Go2Climb | Go2Climb@gmail.com | 987654321   | New Agency  | Av. JD House | 98765432 |
	Then the agency will be created successfully