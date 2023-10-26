Feature: Login
    As a user, 
        I should be able to login with valid username and password
        I should not be able login with invalid username or password and there is error message popup to me

@login @sanity
Scenario: Login with valid username and password
	Given user navigates to the SM website
	When user enters username and password
		| username | password     |
		| jasonle  | xX0123456789 |
	And user clicks Log On button
	And user verify enterprise search field is displayed
	And user verify page title after logged in is 'Home : CiA Workplace'
	Then user log out from SM website

@login @sanity
Scenario: Login with invalid username and password
	Given user navigates to the SM website
	When user enters username and password
		| username | password |
		| jasonle  | xX01234  |
	And user clicks Log On button
	Then user verify error message displayed 'Invalid user name or password.'