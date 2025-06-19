using SpecFlowTP2API;

namespace SpecFlowTP2.StepDefinitions
{
    [Binding]
    public sealed class ScrutinStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private List<Candidat> _candidats;
        private string _result;
        #region Given
        [Given(@"the poll is closed")]
        public void GivenThePollIsClosed()
        {
            throw new PendingStepException();
        }
        [Given(@"the votes are shown")]
        public void GivenTheVotesAreShown()
        {
            throw new PendingStepException();
        }
        #endregion
        #region When
        [When(@"a candidate has (.*)% or more of the votes")]
        public void WhenACandidateHasOrMoreOfTheVotes(int percent)
        {
            var scrutin = new Scrutin();
        }
        #endregion
        #region Then
        [Then(@"the candidate won")]
        public void ThenTheCandidateWon()
        {
            throw new PendingStepException();
        }
        #endregion
    }
}
