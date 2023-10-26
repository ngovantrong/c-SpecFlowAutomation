Feature: Chart

@sanity
Scenario: Create an active AR direct debit Debtor Account
	Given user navigates to the FIN website
	When user enters username and password
		| username  | password    |
		| tien phan | Tien_123456 |
	And user clicks Log On button
	And user verify enterprise search field is displayed
	And user search for 'Accounts Receivable'
	And user clicks on role 'Accounts Receivable'
	And user clicks on account type 'Debtor Accounts'
	And user filter and select chart 'ARCH_AR'
	And user adds new account Direct Debit Account
	And user input '900' to field 'Archiving AR (NNN)'
	And user input 'ROL' to field 'Account Manager'
	And user input 'BBA' to field 'Bank Identifier'
	And user input 'AutoTest' to field 'Account Name'
	And user input '012-002' to field 'BSB'
	And user input 'AutoBank' to field 'Account'
	And user clicks Save button
	Then user perform delete new created account data

@sanity
Scenario: Run chart copy process to create new chart
	Given user navigates to the FIN website
	When user enters username and password
		| username  | password    |
		| tien phan | Tien_123456 |
	And user clicks Log On button
	And user verify enterprise search field is displayed
	And user search for 'Financials Process Central'
