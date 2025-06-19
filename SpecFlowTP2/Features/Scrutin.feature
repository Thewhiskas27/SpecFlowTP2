Feature: Scrutin

Scenario: Two candidates win
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

	Scenario: Tie
	Given the following candidates
	| name       |
	| candidate1 |
	| candidate2 |
	And the votes are as follow
	| name       | votecount |
	| candidate1 | 3         |
	| candidate2 | 3         |
	Then noone won

Scenario: Normal multiple candidates
	Given the following candidates
	| name       |
	| candidate1 |
	| candidate2 |
	| candidate3 |
	| candidate4 |
	And the votes are as follow
	| name       | votecount |
	| candidate1 | 2         |
	| candidate2 | 1         |
	| candidate3 | 5         |
	| candidate4 | 3         |
	Then the following candidates won
	| name       |
	| candidate3 |
	| candidate4 |
	And we do another poll

Scenario: Absolute Majority
	Given the following candidates
	| name       |
	| candidate1 |
	| candidate2 |
	| candidate3 |
	| candidate4 |
	And the votes are as follow
	| name       | votecount |
	| candidate1 | 2         |
	| candidate2 | 5         |
	| candidate3 | 12        |
	Then we have a winner
	And "Candidate3" won