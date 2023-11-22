Feature: Employee

A short summary of the feature

@tag1
Scenario: Get new Account with valid data
	Given user perform the GET operation for emdpoit "api/v1/employee/1"
	 When User executes the GET request for authscheduler
	 Then user should get 200 status code
