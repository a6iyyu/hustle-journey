public class Needs
{
    private float _satiety;
    private float _energy;
    private float _recreation;
    private float _hygiene;
    private float _bladder;
    private float _social;
    private float _health;
    private float _pain;
    private float _drunkenness;
    private float _discontent;

    // main needs
    public float Satiety
    {
        get => _satiety;
        set => _satiety = Clamp(value);
    }
    public float Energy
    {
        get => _energy;
        set => _energy = Clamp(value);
    }
    public float Recreation
    {
        get => _recreation;
        set => _recreation = Clamp(value);
    }
    public float Hygiene
    {
        get => _hygiene;
        set => _hygiene = Clamp(value);
    }
    public float Bladder
    {
        get => _bladder;
        set => _bladder = Clamp(value);
    }

    // secondary needs
    public float Social
    {
        get => _social;
        set => _social = Clamp(value);
    }
    public float Health
    {
        get => _health;
        set => _health = Clamp(value);
    }

    // negative effects
    public float Pain
    {
        get => _pain;
        set => _pain = Clamp(value);
    }
    public float Drunkenness
    {
        get => _drunkenness;
        set => _drunkenness = Clamp(value);
    }
    public float Discontent
    {
        get => _discontent;
        set => _discontent = Clamp(value);
    }

    private float Clamp(float value)
    {
        if (value < 0) return 0;
        if (value > 20) return 20;
        return value;
    }
}