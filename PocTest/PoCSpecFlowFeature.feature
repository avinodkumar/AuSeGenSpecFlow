Feature: PoCSpecFlowFeature
		Login to linkedin website
		And validate the login

@mytag
Scenario Outline: Login to Linkedin and verifing the login
	Given I am on Linkeding page
		And Login with <Email> and <Password> into Linkedin	
	When I press Signin button
	Then validating the <UserName> User name
	
	Examples:
	| Email                       | Password      | UserName	|
	| sreenivasparimi95@gmail.com | Sreenivas007. | Sreenivas	|
	| ravitejaseetha@gmail.com    | teja1234      | Ravi		|