using static System.Net.Mime.MediaTypeNames;

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
    public List<PourcentVotes> getPercs(List<Candidat> cs)
    {
        int votes = getAllVotes(cs);
        List<PourcentVotes> pv = new();
        foreach (var c in cs) 
        { pv.Add(new PourcentVotes(c, c.votes * 100 / votes)); }
        return pv;
    }
    public List<Candidat> getWinners(List<PourcentVotes> pv)
    {
        PourcentVotes first = null;
        PourcentVotes second = null;
        List<PourcentVotes> cs = new() { first, second };
        switch (pv.Count)
        {
            case < 2:
                return new();
            case 2:
                if (pv[0].percent > pv[1].percent)
                {
                    first = pv[0];
                    cs.Remove(second);
                }
                else if (pv[0].percent < pv[1].percent)
                {
                    first = pv[1];
                    cs.Remove(second);
                }
                else return new();
                List<Candidat> candidat = new() { cs[0].c };
                return candidat;
            default:
                foreach (var p in pv)
                {
                    if (p.percent > 50)
                    {
                        first = p;
                        cs.Remove(second);
                        break;
                    }
                    if (p.percent > first.percent)
                    {
                        second = first;
                        first = p;
                    }
                    if (p.percent > second.percent) second = p;
                }
                List<Candidat> candidats = new() { first.c, second.c };
                return candidats;
        }
        /*switch (cs.Count)
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
                List<Candidat> winners = new() { first, sec };
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
        }*/
    }
}