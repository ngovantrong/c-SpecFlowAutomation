Feature: Student Registration
	As a user,
		I should be able to register a student successfully

@register @sanity
Scenario: Register new student from given URL
	Given user navigates to the SM website
	When user enters username and password
		| username | password     |
		| jasonle  | xX0123456789 |
	And user clicks Log On button
	And user verify enterprise search field is displayed
	And user verify page title after logged in is 'Home : CiA Workplace'
	And user search for 'Admissions Messaging'
	And user clicks on function 'Admissions and Enrolments Configuration'
	And user waits until element with text 'Standard Code Types' to be displayed
	And user clicks on element contains text 'Function Settings'
	And user clicks on 'Student Application Registration'
	And user gets the URL for student application registration
	And user navigates to student registration page
	And user input all required info to the form
		| familyName | givenName    | emailPrefix | nationality |
		| autotest   | Student 0833 | autotest    | Vietnamese  |
	And user clicks on Register and Apply button
	Then user verifies student registered successfully