Feature: Banksystem 

A short summary of the feature

@tag1
Scenario: Create new Account with valid data
	Given User Perform POST endpoint "api/account/create" to create new account with above details
	When user the response code is 200
	Then Verify no error is returned
    And Verify the success 'Account created successfully' message
    And Verify the account details are correctly returned in the JSON response

Scenario: A user can deposit to an account
	Given User Perform PUT endpoint "account/deposit" to an account with amount "BankSystemDeposit"
	When user the response code is 200
	Then Verify no error is returned
    And Verify the success '1000$ deposited to Account X123 successfully' message
    And Verify the account details are correctly updated as 2000 in the JSON response

Scenario: A user can withdraw from an account
	Given User Perform PUT endpoint "account/withdraw" to an account with amount "BankSystemWithDrawAmount"
	When user the response code is 200
	Then Verify no error is returned
    And Verify the success '1000$ withdrawn from Account X123 successfully' message
    And Verify the account details are correctly updated as 0 in the JSON response

Scenario: A user can delete account
	Given User Perform PUT endpoint "account/withdraw" to an account with amount "BankSystemWithDrawAmount"
	When user the response code is 200
	Then Verify no error is returned
    And Verify the success '1000$ withdrawn from Account X123 successfully' message
    And Verify the account details are correctly updated as 0 in the JSON response