Feature: GoCity

Background: 
	Given I am on GoCity homepage

@Regression
Scenario: user video tour 
	When I cick on the video play button
	Then I can see the video playinga nd count greater than '0:00'


@Regression
Scenario: user Navigations
	When I navigate to how it works page
	Then I am on 'How it Works' page
	When I navigate to help page 
	Then I am on 'Help' page
	When I navigate to covid 19 page
	Then I am on 'Go City Traveler Information: COVID-19' page


@Regression
Scenario: Get pass by City name
	When I click city name 'Go Bangkok'
	Then Go 'Bangkok' page is displayed


@Regression
Scenario: Get all inclusive Bankok pass
	When I click city name 'Go Bangkok'
	Then Go 'Bangkok' page is displayed
	When I click on 'Buy'
	Then Go 'Bangkok' page is displayed
	When I click on 'Buy Now' index 1
	And I 'Select' pass of index 0, '-1' of name '2 Day Pass'
	Then Order summary is displayed with pass '2 Day Pass'
	When I click 'Adult' pass quantity index 1
	When I click 'Child (3–12)' pass quantity index 1
	Then I vaidate pass count is '3'
	When I click checkout
	Then 'Review your order' page is displayed
	And the following pass info is displayed:
	| AdultPassName                  | ChildPassName                         | TotalAdultPricePerPass | TotalChildPricePerPass | OrderTotal |
	| 2 Day Pass Adult All-Inclusive | 2 Day Pass Child (3–12) All-Inclusive | ฿7000                  | ฿3000                  | ฿10000     |

	When I select day 24 from the current date
	And I click on Continue to payment
	And I enter all the required informations
	
	





