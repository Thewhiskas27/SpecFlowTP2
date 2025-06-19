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
    public List<Candidat> getWinners(List<Candidat> cs)
    {
        switch (cs.Count)
        {
            case < 2:
                return cs;
            case 2:
                if (cs[0].votes > cs[1].votes) cs.Remove(cs[1]);
                else if (cs[0].votes < cs[1].votes) cs.Remove(cs[0]);
                else cs.Clear();
                return cs;
            default:
                Candidat first = null;
                Candidat sec = null;
                List<Candidat> winners = new List<Candidat> { first, sec };
                int votes = getAllVotes(cs);
                var vcand = 0;
                foreach (var c in cs)
                {
                    if (sec.votes >= c.votes) continue;
                    vcand += c.votes * 100 / votes;
                    if (vcand > 50)
                    {
                        winners.Remove(sec);
                        first = c;
                        return winners;
                    }
                    else
                    {
                        if (c.votes > first.votes)
                        {
                            sec = first;
                            first = c;
                        }
                        else sec = c;
                    }
                }
                return winners;
        }
    }
}