public class Needs
{
    private int _satiety;
    private int _energy;
    private int _recreation;
    private int _hygiene;
    private int _bladder;
    private int _social;
    private int _health;
    private int _pain;
    private int _drunkenness;
    private int _discontent;

    // main needs
    public int Satiety
    {
        get => _satiety;
        set => _satiety = Clamp(value);
    }
    public int Energy
    {
        get => _energy;
        set => _energy = Clamp(value);
    }
    public int Recreation
    {
        get => _recreation;
        set => _recreation = Clamp(value);
    }
    public int Hygiene
    {
        get => _hygiene;
        set => _hygiene = Clamp(value);
    }
    public int Bladder
    {
        get => _bladder;
        set => _bladder = Clamp(value);
    }

    // secondary needs
    public int Social
    {
        get => _social;
        set => _social = Clamp(value);
    }
    public int Health
    {
        get => _health;
        set => _health = Clamp(value);
    }

    // negative effects
    public int Pain
    {
        get => _pain;
        set => _pain = Clamp(value);
    }
    public int Drunkenness
    {
        get => _drunkenness;
        set => _drunkenness = Clamp(value);
    }
    public int Discontent
    {
        get => _discontent;
        set => _discontent = Clamp(value);
    }

    private int Clamp(int value)
    {
        if (value < 0) return 0;
        if (value > 20) return 20;
        return value;
    }
}