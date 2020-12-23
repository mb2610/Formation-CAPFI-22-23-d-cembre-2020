Feature: Hear Shout
	Shouts have a range of approximately 1000m

Scenario Outline: In range shout is heard
	Given Sean is at <Sean-location>
    And Lucy is at [0, 0]
    When Sean shouts
    Then Lucy should hear <What-Lucy-heard>

	Examples: Some examples
		| Sean-location |	What-Lucy-heard |
		| [0, 900]		|	Sean			|
		| [800, 800]	|	nothing			|

Scenario: Not hear own shout
    Given Sean is at [800, 800]
    When Sean shouts
    Then Sean should hear nothing

Scenario: Out of range shout is not heard
    Given Sean is at [0, 1000]
    And Lucy is at [0, 0]
    When Sean shouts
    Then Lucy should hear nothing