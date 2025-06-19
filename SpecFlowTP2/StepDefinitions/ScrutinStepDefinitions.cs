using SpecFlowTP2API;
using SpecFlowTP2API.Classes;

namespace SpecFlowTP2.StepDefinitions
{
    [Binding]
    public sealed class ScrutinStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private Poll scrutin;
        private List<PourcentVotes> _candidats;
        private string _result;
        #region Given
        [Given(@"the poll is closed")]
        public void GivenThePollIsClosed(Poll s)
        {

        }
        [Given(@"the votes are shown")]
        public void GivenTheVotesAreShown()
        {

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
        public void ThenTheCandidateWon(Candidat c)
        {
            this._result.Should().Be(c.name);
        }
        #endregion
    }
}
