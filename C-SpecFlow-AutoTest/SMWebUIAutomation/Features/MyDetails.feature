Feature: My Details
	As a student user,
		I should be able to add contacts and view contact details

@sanity
Scenario: Add new contact with other contact type
	Given user navigates to the SM student website
	When user enters username and password for student login
		| username | password   |
		| 15023979 | Iamfine456 |
	And user clicks Log On button
	And user verify enterprise search field is displayed
	And user verify page title after logged in is 'Home : CiA Workplace'
	And user clicks on My Details
	And user clicks on Contacts section
	And user clicks on Add button
	And user clicks on 'Add other contact'
	And user selects Contact Type as 'Guardian'
	And user input Contact Name as 'UI Automation Test'
	And user clicks on Save button
	Then user verifies new contact is saved successfully