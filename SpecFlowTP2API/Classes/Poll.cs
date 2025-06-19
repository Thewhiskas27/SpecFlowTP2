namespace SpecFlowTP2API.Classes;

public class Poll
{
    public string label { get; set; }
    public List<Candidat> candidats { get; set; }
    public bool IsOpen { get; set; }
    public Candidat? winner { get; set; }
    public Poll(string label, List<Candidat> candidats, bool isOpen)
    {
        this.label = label;
        this.candidats = candidats;
        IsOpen = isOpen;
    }
}