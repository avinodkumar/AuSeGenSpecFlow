Feature: PoCSpecFlowFeature
		Login to linkedin website
		And validate the login

@mytag
Scenario: Login to Linkedin and verifing the login
	Given I am on Linkeding page
		And Login with <UserName> and <Password> into Linkedin	
	When I press Signin button
	Then validating the login
