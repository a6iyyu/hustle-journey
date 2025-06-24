
public class TextStyle
{
    public static readonly TextStyle Normal = new TextStyle("Normal");
    public static readonly TextStyle Anchor = new TextStyle("Anchor");
    public static readonly TextStyle Breadcrumb = new TextStyle("Breadcrumb");
    public static readonly TextStyle Male = new TextStyle("Male");
    public static readonly TextStyle Female = new TextStyle("Female");
    private readonly string _style;
    public TextStyle(string style)
    {
        _style = style;
    }
    public override string ToString()
    {
        return _style;
    }

}