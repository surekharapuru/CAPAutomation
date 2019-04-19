Feature: googleTest


@Browser_Chrome
@Browser_Firefox
Scenario: Google test
	Given enter google url
	Then the result should be have google screen
@Browser_Firefox
Scenario: Conduent test
	Given enter conduent website url
	Then the result should be have google screen
