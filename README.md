# APIProject
*****************************************************************************************************
Framework Design Highlights: -
1.Used RestSharp for API automation
2.Specflow for BDD
3.Model for payload
4.Nunit for Assertion
5.Feature and Step Definition folder
6.Helper Class is created for all common method related API automation l
7.Hooks like beforeScenario, afterScenario etc to initialize log and report
8.Test Data for json
9.Handled serialization and Deserialization for payload (Generic method is created for Deserialization)
10.Used Context injection for object instantiate and data sharing.
11.Manage to run with different Base Url  for endpoints.
*******************************************************************************************************
********************************************************************************************************

Test Case Example: - Here There are two features.

BankSystem.feature – it contains the test case or scenario given in the document 
Scenario-1: A user can create account
            POST Endpoint: https://www.localhost:8080/api/account/create
Scenario-2: A user can delete account
         	DELETE Endpoint: https://www.localhost:8080/api/account/delete/<accountID>
Scenario-3: A user can deposit to an account
        	PUT Endpoint: https://www.localhost:8080/api/account/deposit
Scenario-4: A user can withdraw from an account.
        	PUT Endpoint: https://www.localhost:8080/api/account/withdraw


Using local API given in document, although this test case is not running ,but here all the steps are done. And serialization and Deserialization can be seen  ,add body with POST,PUT  and  DELETE with others validation are there.


Employee.feature – It contains the test case with GET using Dummy API, this test case is running well so end to end flow can be reviewed with test case.
Endpoint -https://dummy.restapiexample.com/api/v1/employee/1

**************************************************************************************************
