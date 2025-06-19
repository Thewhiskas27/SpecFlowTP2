namespace SpecFlowTP2API;

public class Scrutin
{
    public void addCandidat(List<Candidat> cs, string name)
    {
        var c = new Candidat(name);
        cs.Add(c);
    }
    public int getAllVotes(List<Candidat> cs)
    {
        int votes = 0;
        foreach (var c in cs) { votes += c.votes;}
        return votes;
    }
    public int getVotes (Candidat c) { return c.votes; }
    public List<Candidat> getWinner(List<Candidat> cs)
    {
        Candidat cwinner = null;
        Candidat sec = null;
        List<Candidat> winners = new List<Candidat>();
        winners.Add(cwinner);
        winners.Add(sec);
        int votes = getAllVotes(cs);
        var vcand = 0;
        foreach (var c in cs)
        {
            vcand += c.votes * 100 / votes;
            if (vcand > 50)
            {
                winners.Remove(sec);
                return winners;
            }
        }
    }
}
