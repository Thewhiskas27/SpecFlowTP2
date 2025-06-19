using SpecFlowTP2API;
using SpecFlowTP2API.Classes;

namespace SpecFlowTP2.StepDefinitions
{
    [Binding]
    public sealed class ScrutinStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private Poll scrutin;
        private List<Candidat> _cand;
        private List<PourcentVotes> _candidats;
        private string _result;
        private int votes;
        #region Given
        [Given(@"the following candidates")]
        public void GivenTheFollowingCandidates(Table table)
        {
            foreach(var row in table.Rows)
            {
                var cname = row[0];
                if (!string.IsNullOrWhiteSpace(cname)) this._cand.Add(new Candidat(cname));
            }
        }
        [Given(@"the votes are as follow")]
        public void GivenTheVotesAreAsFollow(Table table)
        {
            votes = 0;
            foreach (var row in table.Rows) {
                votes += int.Parse(row[1]);
                Candidat c = new(row[0]);
                if (_cand.Contains(c)) _cand[c.id].votes = c.votes;
                else
                {
                    c.votes = int.Parse(row[1]);
                    _cand.Add(c);
                }
            }
        }

        #endregion
        #region Then
        [Then(@"we have a winner")]
        public void ThenWeHaveAWinner()
        {
            _candidats = Scrutin.getPercs(_cand);
        }
        [Then(@"""([^""]*)"" won")]
        public void ThenWon(string p0)
        {
            decimal e = 0;
            string w = "";
            Poll p = new("SondageTest", _cand, false);
            foreach(var c in _candidats)
            {
                if (e < c.percent)
                {
                    e = c.percent;
                    w = c.c.name;
                }
            }
            _result = $"{w} with {e}% of the votes";
        }
        [Then(@"the following candidates won")]
        public void ThenTheFollowingCandidatesWon(Table table)
        {
            _cand = new();
            foreach (var row in table.Rows) _cand.Add(new Candidat(row[0]));
        }
        [Then(@"we do another poll")]
        public void ThenWeDoAnotherPoll()
        {
            scrutin = new("Deuxième tour", _cand, true);
        }

        [Then(@"noone won")]
        public void ThenNooneWon()
        {
            scrutin.winner = null;
        }
        #endregion
    }
}
