using Assets.App.Scripts.Player;

public class Needs
{
    // main needs
    public Need Satiety { get; set; }
    public Need Energy { get; set; }
    public Need Recreation
    {
        get; set;
    }
    public Need Hygiene
    {
        get; set;
    }
    public Need Bladder
    {
        get; set;
    }

    // secondary needs
    public Need Social
    {
        get; set;
    }
    public Need Health
    {
        get; set;
    }

    // negative effects
    public Need Pain
    {
        get; set;
    }
    public Need Drunkenness
    {
        get; set;
    }
    public Need Discontent
    {
        get; set;
    }
    public Needs()
    {
        // Initialize main needs
        Satiety = new Need(20, 0, 20);
        Energy = new Need(20, 0, 20);
        Recreation = new Need(20, 0, 20);
        Hygiene = new Need(20, 0, 20);
        Bladder = new Need(20, 0, 20);

        // Initialize secondary needs
        Social = new Need(20, 0, 20);
        Health = new Need(20, 0, 20);

        // Initialize negative effects
        Pain = new Need(0, 0, 20);
        Drunkenness = new Need(0, 0, 20);
        Discontent = new Need(0, 0, 20);
    }
    public Need GetNeedByName(string name)
    {
        return name switch
        {
            "Satiety" => Satiety,
            "Energy" => Energy,
            "Recreation" => Recreation,
            "Hygiene" => Hygiene,
            "Bladder" => Bladder,
            "Social" => Social,
            "Health" => Health,
            "Pain" => Pain,
            "Drunkenness" => Drunkenness,
            "Discontent" => Discontent,
            _ => null
        };
    }
}