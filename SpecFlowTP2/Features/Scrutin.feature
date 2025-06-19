Feature: Scrutin

@mytag
Scenario: Absolute Majority
	Given the poll is closed
	And the votes are shown
	When a candidate has 50% or more of the votes
	Then the candidate won