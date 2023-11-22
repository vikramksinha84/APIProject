Feature: Banksystem 

A short summary of the feature

@tag1
Scenario: Create new Account with valid data
    # Below Data is fetching from json not taking as step
    #Given Account Initial Balance is $1000
    #And   Account name is "Rajesh Mittal"
    #And   Address is "Ahmedabad, Gujarat"
	Given User Perform POST endpoint "api/account/create" to create new account with above details
	Then Verify the response code is 200
	And  Verify no error is returned
    And Verify the success 'Account created successfully' message
    And Verify the account details are correctly returned in the JSON response

