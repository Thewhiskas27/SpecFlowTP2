using SpecFlowTP2API.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace SpecFlowTP2API;

public class Scrutin
{
    public void addCandidat(Poll p, string name)
    {
        var c = new Candidat(name);
        p.candidats.Add(c);
    }
    public int getAllVotes(Poll p)
    {
        int votes = 0;
        foreach (var c in p.candidats) { votes += c.votes;}
        return votes;
    }
    public List<PourcentVotes> getPercs(Poll p)
    {
        int votes = getAllVotes(p);
        List<PourcentVotes> pv = new();
        foreach (var c in p.candidats) 
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
                    List<Candidat> candidat = new() { cs[0].c };
                    return candidat;
                }
                else if (pv[0].percent < pv[1].percent)
                {
                    List<Candidat> candidat = new() { cs[1].c };
                    return candidat;
                }
                else return new();
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
    }
}