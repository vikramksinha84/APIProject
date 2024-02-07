Feature: Banksystem 

Background:
Given user perform request using Bank BaseUrl


Scenario Outline: Create new Account with valid data
    When Account initial Balance is "<Amount>" 
	And User Perform POST endpoint "api/account/create" to create new account with above details
	Then user the response code is 200
	And Verify no error is returned
    And Verify the success 'Account created successfully' message
    And Verify the account details are correctly returned in the JSON response with initial balance "<Amount>" 
	Examples:
	| Amount	        |
	| 1000              |
	| 500               |

Scenario: A user can deposit to an account
	When User Perform PUT endpoint "account/deposit/X123" to an account with amount "BankSystemDeposit"
	Then user the response code is 200
	And Verify no error is returned
    And Verify the success '1000$ deposited to Account X123 successfully' message
    And Verify the account details are correctly updated as "2000" in the JSON response

Scenario: A user can withdraw from an account
	When User Perform Patch endpoint "account/withdraw/X123" to an account with amount "BankSystemWithDrawAmount"
	Then user the response code is 200
	And Verify no error is returned
    And Verify the success '2000$ withdrawn from Account X123 successfully' message
    And Verify the account details are correctly updated as 0 in the JSON response

Scenario: A user can delete account
	When User Perform DELETE endpoint "delete/{accountID}" to delete an account "X123"
	Then user the response code is 200
	Then Verify no error is returned
    And Verify the success 'Account X123 deleted successfully' message