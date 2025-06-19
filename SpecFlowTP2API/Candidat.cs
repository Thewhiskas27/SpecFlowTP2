
namespace SpecFlowTP2API;

public class Candidat
{
    static int lastId = 0;
    static int generateId() { return Interlocked.Increment(ref lastId); }
    public int id { get; set; }
    public string name { get; set; }
    public int votes { get; set; }
    public Candidat(string name)
    {
        this.id = generateId();
        this.name = name;
    }
}
