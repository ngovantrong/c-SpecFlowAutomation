Feature: Login
    As a user, 
        I should be able to login with valid username and password

@login @sanity
Scenario: Login with valid username and password
	Given user navigates to the FIN website
	When user enters username and password
		| username  | password    |
		| tien phan | Tien_123456 |
	And user clicks Log On button
	And user verify enterprise search field is displayed
	And user verify page title after logged in is 'Home : CiA Workplace'
	Then user log out from FIN website