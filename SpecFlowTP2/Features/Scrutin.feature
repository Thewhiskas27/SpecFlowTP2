Feature: Scrutin

Scenario: Absolute Majority
	Given the following candidates
	| name       |
	| candidate1 |
	| candidate2 |
	And the votes are as follow
	| name       | votecount |
	| candidate1 | 3         |
	| candidate2 | 1         |
	Then we have a winner
	And "Candidate1" won