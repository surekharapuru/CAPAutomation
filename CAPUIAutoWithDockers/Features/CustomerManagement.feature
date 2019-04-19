Feature: To verify CustomerManagement module

@Browser_Chrome
@Browser_Firefox
Scenario: Verify Customer Management screen
	Given I navigate to Home page
	When Click CustomerMnagement tab
	Then "Customer Management" screen displayed

@Browser_Chrome
Scenario: Add new customer
	Given I navigate to Home page
	When I add a customer with below data
	| Name     | Description                         | IsolationLevel | Size  |
	| TestName | This is a test description for test | Cluster        | Large |
	Then I verify customer data is added as "true"
